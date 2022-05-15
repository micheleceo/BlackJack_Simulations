using BlackJackSimul.CountingStrategy;
using BlackJackSimul.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
    {
    public class Simulation
    {
        FileCSV playFile;
        PlayRecord playRecord = new PlayRecord();
        static Log log = new Log();

        int ShoeNumber { get; set; } = 0;
        int MazziPerShoe { get; set; } = 0;
        int MazziDaEstrarrePerShoe { get; set; } = 0;
        int PlayNumber { get; set; } = 0;
        Shoe shoe { get; set; }

        public Simulation(int _shoeNumber, int _nMazziPerShoe, int _nMazziDaEstrarePerShoe)
        {
            ShoeNumber = _shoeNumber;
            MazziPerShoe = _nMazziPerShoe;
            MazziDaEstrarrePerShoe = _nMazziDaEstrarePerShoe;
        }

        public void Start()
        {
            playFile = new FileCSV("PlayFile.csv");
            playFile.WriteHeader(";", playRecord);

            for (int nShoe = 1; nShoe <= ShoeNumber; nShoe++)
            {
                shoe = new Shoe(MazziPerShoe, MazziDaEstrarrePerShoe);
                shoe.Shuffle();
                playRecord.ShoeID = nShoe;
                Play(shoe);
            }

            playFile.Close();
        }

        private void Play(Shoe shoe)
        {
            //Creazione dei counter
            var hl_counter = new HL_Counter(shoe);
            var rapc_counter = new RAPC_Counter(shoe);

            Queue<string> cardSequence = shoe.cards;

            while (cardSequence.Count >= MazziDaEstrarrePerShoe*Costanti.N_CARTE_MAZZO)
            {
                playRecord.PlayID++;
                playRecord.CardSequence = "";

                #region DISTRIBUZIONE INIZIALE

                var player = new Player();
                player.NewHand();
                var dealer = new Dealer();
                dealer.NewHand();

                //Estrazione delle prime quattro carte
                var playerFirstCard = cardSequence.Dequeue();
                var dealerFirstCard = cardSequence.Dequeue();
                var playerSeconCard = cardSequence.Dequeue();
                var dealerSeconCard = cardSequence.Dequeue();

                //Distribuisci carta al player
                player.GiveCard(playerFirstCard);

                //Distribuisci carta al dealer
                dealer.GiveCard(dealerFirstCard);

                //Distribuisci carta al player
                player.GiveCard(playerSeconCard);

                //Distribuisci carta al dealer
                dealer.GiveCard(dealerSeconCard);

                #endregion DISTRIBUZIONE INZIZIALE


                Console.ForegroundColor = ConsoleColor.White;
                log.Write($"\nShoe {playRecord.ShoeID} \t Mano {playRecord.PlayID} \t");
                log.WriteLine($"DEALER: { dealerFirstCard}");


                #region GIOCATA PLAYER

                //Giocata player
                if (!Util.CheckBlackJack(dealer.hand))
                {
                    int dealerFirstCardPoint = Util.PointOf(dealerFirstCard);
                    for (int playerhandID = 0; playerhandID < player.hands.Count; playerhandID++)
                    {
                        var playerHand = player.hands[playerhandID];
                        string response = "";

                        if (Costanti.f_console)
                            if (playerhandID > 0)
                                log.WriteLine("---");
                        player.WriteHandResult(playerHand);

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
                                    player.GiveCard(secondHandSecondCard, playerhandID + 1);

                                }
                            }

                            if (Costanti.f_console)
                            {
                                log.WriteLine(response);
                                if (response == "SPLIT")
                                    log.WriteLine("---");
                            }

                            player.WriteHandResult(playerHand);

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
                        log.WriteLine(dealerAction);
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

                foreach (string card in dealer.hand.Cards)
                {
                    playRecord.CardSequence += card + ",";
                    hl_counter.UpdateCounters(card);
                    rapc_counter.UpdateCounters(card);
                    playRecord.HL_RunningCounter = hl_counter.RunningCounter;
                    playRecord.HL_TrueCounter = hl_counter.TrueCounter;
                    playRecord.RAPC_RunningCounter = rapc_counter.RunningCounter;
                    playRecord.RAPC_TrueCounter = rapc_counter.TrueCounter;
                }
                   
                foreach (Hand hand in player.hands)
                    foreach (string card in hand.Cards)
                    {
                        playRecord.CardSequence += card + ",";
                        hl_counter.UpdateCounters(card);
                        rapc_counter.UpdateCounters(card);
                        playRecord.HL_RunningCounter = hl_counter.RunningCounter;
                        playRecord.HL_TrueCounter = hl_counter.TrueCounter;
                        playRecord.RAPC_RunningCounter = rapc_counter.RunningCounter;
                        playRecord.RAPC_TrueCounter = rapc_counter.TrueCounter;
                    }

                if(cardSequence.Count < MazziDaEstrarrePerShoe * Costanti.N_CARTE_MAZZO)
                {
                    playRecord.HL_RunningCounter = 0;
                    playRecord.HL_TrueCounter = 0;
                    playRecord.RAPC_RunningCounter = 0;
                    playRecord.RAPC_TrueCounter = 0;
                }

                playFile.WriteData(playRecord);
                       

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
                    log.WriteLine($"Il dealer vince");
                }

                else if (punteggioDealer > 21)
                {
                    Player.ManiVinte++;
                    Player.TotVincita += playerHand.Puntata;
                    log.WriteLine($"Il player vince");
                }

                else if (Util.CheckBlackJack(playerHand))
                {
                    Player.CounterBlackJack++;
                    if (!Util.CheckBlackJack(dealerHand))
                    {
                        Player.ManiVinte++;
                        Player.TotVincita += (float)playerHand.Puntata * (float)1.5;
                        log.WriteLine($"Il player vince");
                    }
                    else
                    {
                        Dealer.CounterBlackJack++;
                        if (Costanti.f_console)
                            log.WriteLine($"Push");
                    }
                }

                else if (punteggioPlayer > punteggioDealer)
                {
                    Player.ManiVinte++;
                    Player.TotVincita += playerHand.Puntata;
                    log.WriteLine($"Il player vince");
                }

                else if (punteggioPlayer < punteggioDealer)
                {
                    Player.ManiVinte--;
                    Player.TotVincita -= playerHand.Puntata;
                    log.WriteLine($"Il dealer vince");
                }

                else
                {
                    Player.ManiPareggiate++;
                    log.WriteLine($"Push");
                }
            }

            Console.ResetColor();
            log.WriteLine($"Saldo player: {Player.TotVincita}");

        }

    }
}
