using BlackJack.CountingStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single extraction data
            var se_data = new SingleExstractionData();

            // Statistic data
            var stat_data = new StatisticData();

            //Creazione del CSV per singola estrazione
            FileCSV fileCSV = new FileCSV("Data.csv");
            fileCSV.WriteHeader(";", se_data);

            //Creazione della coda di carte
           // Queue<string> cardQueue = new Queue<string>();
            

            //Ciclo sugli shoe
            for (int nShoes=1; nShoes<= Costanti.N_SHOES; nShoes++)
            {
                   // Statistic data
                   se_data = new SingleExstractionData();

                   // Creazione shoe
                   var shoe = new Shoe(Costanti.N_MAZZI_PER_SHOE, Costanti.N_MAZZI_DA_ESTRARRE_PER_SHOE);
                   shoe.Shuffle();
                   
                   //Creazione dei counter
                   var hl_counter = new HL_Counter(shoe);
                   var rapc_counter = new RAPC_Counter(shoe);

                   se_data.ShoeNumber = nShoes;

                   //Ciclo delle estrazioni per shoe
                   for (int n = 1; n <= Costanti.N_CARTE_DA_ESTRARRE_PER_SHOE; n++)
                   {
                       if (n % Costanti.N_CARTE_MAZZO == 0)
                        se_data.deckNumber++;

                        //Prendi una carta
                        se_data.Card = shoe.GetCard();
                        
                        //Aggiornamento counter HL
                        hl_counter.UpdateCounters(se_data.Card);
                        se_data.HL_RunningCounter = hl_counter.RunningCounter;
                        se_data.HL_TrueCounter = hl_counter.TrueCounter;
                        stat_data.memory.HL_TrueCountersequence.Add(hl_counter.TrueCounter);

                        //Aggiornamento counter RAPC
                        rapc_counter.UpdateCounters(se_data.Card);
                        se_data.RAPC_RunningCounter = rapc_counter.RunningCounter;
                        se_data.RAPC_TrueCounter = rapc_counter.TrueCounter;
                        stat_data.memory.RAPC_TrueCounterSequence.Add(rapc_counter.TrueCounter);

                        fileCSV.WriteData(se_data);
                   }

            }

            fileCSV.Close();

            WriteStatistic(stat_data);

            Shoe testShoe = new Shoe(Costanti.N_MAZZI_PER_SHOE, Costanti.N_MAZZI_DA_ESTRARRE_PER_SHOE);
            testShoe.Shuffle();
            SimulatePlay(testShoe.cards);          
        }


        private static void SimulatePlay(Queue<string> cardSequence)
        {
            int intialCardQueue = cardSequence.Count;
            int numeroGiocate = 0;

            while (cardSequence.Count >= 20)
            {
                #region DISTRIBUZIONE INIZIALE
                numeroGiocate++;
                Console.WriteLine($"\nMano {numeroGiocate}");
                var player = new Player();
                player.NewHand();
                var dealer = new Dealer();
                dealer.NewHand();

                //Carta al player
                player.GiveCard(cardSequence.Dequeue());

                //Carta al dealer
                string dealerFirstCard = cardSequence.Dequeue();
                dealer.GiveCard(dealerFirstCard);

                //Carta al player
                player.GiveCard(cardSequence.Dequeue());

                //Carta al dealer
                dealer.GiveCard(cardSequence.Dequeue());
                #endregion DISTRIBUZIONE INZIZIALE


                #region GIOCATA PLAYER

                Console.WriteLine("DEALER: " + dealerFirstCard);
                player.WriteResult();

                //Giocata player
                if (!Util.CheckBlackJack(dealer.hand))
                {
                    int dealerFirstCardPoint = Util.PointOf(dealerFirstCard);
                    for (int playerhandID = 0; playerhandID < player.hands.Count; playerhandID++)
                    {
                        var playerHand = player.hands[playerhandID];
                        string response="";
                        while ( !playerHand.f_bust &&
                                response!="STAND" &&
                                !playerHand.f_double)
                        {
                            response = player.Ask(playerhandID, dealerFirstCardPoint);

                            if (response == "HIT")
                                player.GiveCard(cardSequence.Dequeue(),playerhandID);

                            else if (response == "DOUBLE DOWN")
                            {
                                //Check del double
                                if (playerHand.Cards.Count == 2)
                                {
                                    playerHand.Puntata *= 2;
                                    playerHand.f_double = true;
                                }
                                //Se non si può raddoppiare
                                player.GiveCard(cardSequence.Dequeue(), playerhandID);
                            }
                            else if (response == "SPLIT")
                            {
                                //Controllo aggiuntivo
                                if (playerHand.Cards.Count == 2 && playerHand.f_coppia)
                                {
                                    //Creo nuova mano e sposto la carta da una mano all'altra
                                    player.NewHand(true);
                                    playerHand.f_split = true;
                                    player.GiveCard(player.hands[playerhandID].Cards[1], playerhandID);
                                    playerHand.Cards.RemoveAt(playerHand.Cards.Count - 1);
                                    player.GiveCard( cardSequence.Dequeue(),playerhandID);
                                    player.GiveCard(cardSequence.Dequeue(), playerhandID);
                                }
                            }

                            player.WriteResult();
                            Console.WriteLine(response);
                            
                        }
                    }


                    player.WriteResult();

                    #endregion GIOCATA PLAYER


                    #region GIOCATA DEALER

                    //Giocata dealer

                    //Supponiamo che abbia controllato prima il blackjack
                    //Controllo che il player non abbia fatto tutti blackjack o bust
                    int countEnded = 0;
                    foreach (Hand playerHand in player.hands)
                    {
                        if (Util.CheckBlackJack(playerHand) || playerHand.f_bust)
                            countEnded++;
                    }

                  
                    string dealerAction = "";
                    if (countEnded != player.hands.Count)
                        while (dealer.hand.punteggio.Value < 21 &&
                               !dealer.hand.f_bust &&
                               dealerAction != "STAND")
                        {
                            dealerAction = dealer.ApplicaRegole();
                            if (dealerAction == "HIT")
                                dealer.GiveCard(cardSequence.Dequeue());
                        }

                    dealer.WriteResult();

                    #endregion GIOCATA DEALER

                    //Risultato della mano
                    CheckTheWinner(player, dealer);

                    // Console.ReadKey();     
                }
            }
        }

        static void CheckTheWinner(Player player, Dealer dealer)
        {
            var dealerHand = dealer.hand;
            var punteggioDealer = dealerHand.punteggio.Value;

                foreach (Hand playerHand in player.hands)
                {
                    var punteggioPlayer = playerHand.punteggio.Value;

                    //Risultato partita
                    if (punteggioPlayer > 21)
                    {
                        Player.ManiVinte--;
                        Player.TotVincita -= playerHand.Puntata;
                        Console.WriteLine($"Il dealer vince, tot= {Player.TotVincita}");
                    }

                    else if (punteggioDealer > 21)
                    {
                        Player.ManiVinte++;
                        Player.TotVincita += playerHand.Puntata;
                        Console.WriteLine($"Il player vince, tot= {Player.TotVincita}");
                    }

                    else if (Util.CheckBlackJack(playerHand))
                    {
                        Player.CounterBlackJack++;
                        if (Util.CheckBlackJack(dealerHand))
                        {
                            Player.ManiVinte++;
                            Player.TotVincita += (float)playerHand.Puntata * (float)1.5;
                            Console.WriteLine($"Il player vince, tot= {Player.TotVincita}");
                        }
                        else
                        {
                            Dealer.CounterBlackJack++;
                            Console.WriteLine($"Pareggio, tot= {Player.TotVincita}");
                        }
                    }

                    else if (punteggioPlayer > punteggioDealer)
                    {
                        Player.ManiVinte++;
                        Player.TotVincita += playerHand.Puntata;
                        Console.WriteLine($"Il player vince, tot= {Player.TotVincita}");
                    }

                    else if (punteggioPlayer < punteggioDealer)
                    {
                        Player.ManiVinte--;
                        Player.TotVincita -= playerHand.Puntata;
                        Console.WriteLine($"Il dealer vince, tot= {Player.TotVincita}");
                    }

                    else
                    {
                        Player.ManiPareggiate++;
                        Console.WriteLine($"Pareggio, tot = { Player.TotVincita}");
                    }
                }
           
        }



        private static void WriteStatistic(StatisticData stat_data)
        {

            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"HL TrueCounter -" +
                                  $" MIN: {stat_data.memory.HL_TrueCountersequence.Min()}" +
                                  $" MAX: {stat_data.memory.HL_TrueCountersequence.Max()}");
            statistics.AppendLine($"RAPC TrueCounter -" +
                                  $" MIN: {stat_data.memory.RAPC_TrueCounterSequence.Min()}" +
                                  $" MAX: {stat_data.memory.RAPC_TrueCounterSequence.Max()}");

            File.WriteAllText("Stat.log", statistics.ToString());

        }


    }
}
