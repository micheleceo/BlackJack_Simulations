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
            int numeroGiocate = 0;

            while (cardSequence.Count >= 208   )
            {
                #region DISTRIBUZIONE INIZIALE
                numeroGiocate++;
               
                var player = new Player();
                player.NewHand();
                var dealer = new Dealer();
                dealer.NewHand();

                //Estrazione delle prime quattro carte
                var playerFirstCard = cardSequence.Dequeue();
                var dealerFirstCard = cardSequence.Dequeue();
                var playerSeconCard = cardSequence.Dequeue();
                var dealerSeconCard = cardSequence.Dequeue();

                //Carta al player
                player.GiveCard(playerFirstCard);

                //Carta al dealer
                dealer.GiveCard(dealerFirstCard);

                //Carta al player
                player.GiveCard(playerSeconCard);

                //Carta al dealer
                dealer.GiveCard(dealerSeconCard);
                #endregion DISTRIBUZIONE INZIZIALE


                #region GIOCATA PLAYER
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\nMano {numeroGiocate} \t");
                Console.WriteLine($"DEALER: { dealerFirstCard}");

               



                //Giocata player
                if (!Util.CheckBlackJack(dealer.hand))
                {
                    int dealerFirstCardPoint = Util.PointOf(dealerFirstCard);
                    for (int playerhandID = 0; playerhandID < player.hands.Count; playerhandID++)
                    {
                        var playerHand = player.hands[playerhandID];
                        string response = "";
                        if (playerhandID > 0)
                            Console.WriteLine("---");
                        player.WriteResult(playerHand);

                        while (!playerHand.f_bust &&
                                response != "STAND" &&
                                !playerHand.f_double)
                        {
                            response = player.Ask(playerhandID, dealerFirstCardPoint);

                            if (response == "HIT")
                                player.GiveCard(cardSequence.Dequeue(), playerhandID);

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
                                    //Setto il flag split
                                    playerHand.f_split = true;
                                    player.hands[playerhandID + 1].f_split = true;
                                   
                                    player.GiveCard(playerHand.Cards[1], playerhandID + 1);
                                    playerHand.Cards.RemoveAt(playerHand.Cards.Count - 1);
                                    var firstHandSecondCard = cardSequence.Dequeue();
                                    var secondHandSecondCard = cardSequence.Dequeue();
                                    player.GiveCard(firstHandSecondCard, playerhandID);
                                    player.GiveCard(secondHandSecondCard, playerhandID+1);
                                    
                                }
                            }

                            Console.WriteLine(response);
                            if (response == "SPLIT")
                                Console.WriteLine("---");
                            player.WriteResult(playerHand);

                        }
                     }

                    #endregion GIOCATA PLAYER


                    #region GIOCATA DEALER

                    //Controllo che il player non abbia fatto tutti blackjack o bust
                    int countEnded = 0;
                    foreach (Hand playerHand in player.hands)
                    {
                        if (Util.CheckBlackJack(playerHand))
                            countEnded++;
                    }


                    string dealerAction = "";
                    if (countEnded != player.hands.Count)
                        while (dealer.hand.punteggio.Value < 21 &&
                               !dealer.hand.f_bust &&
                               dealerAction != "STAND")
                        {
                            dealer.WriteResult();
                            dealerAction = dealer.ApplicaRegole();
                            Console.WriteLine(dealerAction);
                            if (dealerAction == "HIT")
                                dealer.GiveCard(cardSequence.Dequeue());

                        }

                    dealer.WriteResult();

                    #endregion GIOCATA DEALER
                }
                else
                {
                    player.WriteResult();
                    dealer.WriteResult();
                }

                //Risultato della mano
                CheckTheWinner(player, dealer);

              //  Console.ReadKey();     
              
            }
        }

        static void CheckTheWinner(Player player, Dealer dealer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.WriteLine($"Il dealer vince");
                }

                    else if (punteggioDealer > 21)
                    {
                        Player.ManiVinte++;
                        Player.TotVincita += playerHand.Puntata;
                        Console.WriteLine($"Il player vince");
                    }

                    else if (Util.CheckBlackJack(playerHand))
                    {
                        Player.CounterBlackJack++;
                        if (!Util.CheckBlackJack(dealerHand))
                        {
                            Player.ManiVinte++;
                            Player.TotVincita += (float)playerHand.Puntata * (float)1.5;
                            Console.WriteLine($"Il player vince");
                    }
                        else
                        {
                            Dealer.CounterBlackJack++;
                            Console.WriteLine($"Pareggio");
                    }
                    }

                    else if (punteggioPlayer > punteggioDealer)
                    {
                        Player.ManiVinte++;
                        Player.TotVincita += playerHand.Puntata;
                        Console.WriteLine($"Il player vince");
                    }

                    else if (punteggioPlayer < punteggioDealer)
                    {
                        Player.ManiVinte--;
                        Player.TotVincita -= playerHand.Puntata;
                        Console.WriteLine($"Il dealer vince");
                    }

                    else
                    {
                        Player.ManiPareggiate++;
                        Console.WriteLine($"Pareggio");
                    }
                }
            
            Console.ResetColor();
            Console.WriteLine($"Saldo player: {Player.TotVincita}");

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
