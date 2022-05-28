using BlackJackSimul.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackSimul
{
    public class Simulation
    {
        FileCSV playFile;
        PlayRecord playRecord = new PlayRecord();
        static Log log = new Log();
        bool f_OneShot = false;
        Config conf;
        StatisticData stat = new StatisticData();

        Shoe shoe { get; set; }
        
        /// <summary>
        /// Create a new simulation
        /// </summary>
        /// <param name="_shoeNumber"></param>
        /// <param name="_nMazziPerShoe"></param>
        /// <param name="_nMazziDaEstrarePerShoe"></param>
        public Simulation(Config _conf)
        {
            conf = _conf;
        }
        
        /// <summary>
        /// Start simulation
        /// </summary>
        public void Start()
        {
            playFile = new FileCSV("PlayFile.csv");
            playFile.WriteHeader(";", playRecord);

            List<string> deck = CardDeck.Create();

            for (int nShoe = 1; nShoe <= conf.SimulationTotalShoes; nShoe++)
            {
                shoe = new Shoe(conf.ShoeDeckTotalNumber, conf.ShoeDeckToExtractNumber, deck);
                if(conf.ShoeTrueCounter!=0)
                {
                    ShoeEditor.Edit(shoe, (ShoeEditor.CounterType)conf.CounterT, conf.ShoeTrueCounter);
                    f_OneShot = true;
                }
                shoe.Shuffle();
                playRecord.ShoeID = nShoe;
                PlayShoe(shoe, f_OneShot);
            }

            playFile.Close();

            var basic_rtp = 100 + (Player.BasicStake / playRecord.BasicTotalBet) * 100;
            var hl_rtp = 100 + (Player.HL_Stake / playRecord.HL_TotalBet) * 100;
            var rapc_rtp = 100 + (Player.RAPC_Stake / playRecord.RAPC_TotalBet) * 100;
            Console.WriteLine($"\nBASIC RTP: {basic_rtp}% \t HL_RTP: {hl_rtp}% \t RAPC_RTP: {rapc_rtp}%");


        }
        
        /// <summary>
        /// Play shoe
        /// </summary>
        /// <param name="shoe"></param>
        private void PlayShoe(Shoe shoe, bool f_OneShot=false)
        {
            //Creazione dei counter
            var countManager = new CountersManager(shoe);

            Queue<string> cardSequence = shoe.cards;

            while (cardSequence.Count >= conf.ShoeDeckToExtractNumber * Costanti.N_CARTE_MAZZO)
            {
                #region DISTRIBUZIONE INIZIALE

                var player = new Player();
                player.NewHand(conf.FlatBet);
                countManager.SetCountersBets(player.hands[0]);
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


                // Console.ForegroundColor = ConsoleColor.White;
                if(!Costanti.f_print_hands_on_console)
                    Console.Write($"\r Shoe {playRecord.ShoeID}");
                log.Write($"\nShoe {playRecord.ShoeID} \t Mano {playRecord.PlayID} \t");
                log.WriteLine($"DEALER: { dealerFirstCard}");


                //Giocate
                
                if (!Util.CheckBlackJack(dealer.hand))
                {
                    #region GIOCATA PLAYER

                    int dealerFirstCardPoint = Util.PointOf(dealerFirstCard);
                    for (int playerhandID = 0; playerhandID < player.hands.Count; playerhandID++)
                    {
                        var playerHand = player.hands[playerhandID];
                        string response = "";

                        if (Costanti.f_print_hands_on_console)
                            if (playerhandID > 0)
                                log.WriteLine("---");
                        player.WriteHandResult(playerHand);

                        while (!playerHand.f_bust &&
                                response != "STAND" &&
                                !playerHand.f_double)
                        {
                            response = player.AskAction(playerhandID, dealerFirstCardPoint);

                            if (response == "HIT")
                                player.GiveCard(cardSequence.Dequeue(), playerhandID);

                            else if (response == "DOUBLE DOWN")
                            {
                                //Check double
                                if (playerHand.Cards.Count == 2)
                                {
                                    playerHand.FlatBet *= 2;
                                    playerHand.HL_Bet *= 2;
                                    playerHand.RAPC_Bet *= 2;
                                    playerHand.f_double = true;
                                }
                                //Se non si può raddoppiare
                                player.GiveCard(cardSequence.Dequeue(), playerhandID);
                            }
                            else if (response == "SPLIT")
                            {
                                //Check split
                                if (playerHand.Cards.Count == 2 && playerHand.f_coppia)
                                {
                                    //Creo nuova mano e sposto la carta da una mano all'altra
                                    player.NewHand(conf.FlatBet);
                                    countManager.SetCountersBets(player.hands[1]);
                                    //Setto il flag split
                                    foreach (Hand h in player.hands)
                                        h.f_splitted = true;

                                    player.GiveCard(playerHand.Cards[1], playerhandID + 1);
                                    playerHand.Cards.RemoveAt(playerHand.Cards.Count - 1);
                                    var firstHandSecondCard = cardSequence.Dequeue();
                                    var secondHandSecondCard = cardSequence.Dequeue();
                                    player.GiveCard(firstHandSecondCard, playerhandID);
                                    player.GiveCard(secondHandSecondCard, playerhandID + 1);

                                }
                            }

                            if (conf.f_console)
                            {
                                log.WriteLine(response);
                                if (response == "SPLIT")
                                    log.WriteLine("---");
                            }

                        }

                        Player.TotalHands++;
                        Player.Default_TotalBet += playerHand.FlatBet;
                        Player.HL_TotalBet += playerHand.HL_Bet;
                        Player.RAPC_TotalBet += playerHand.RAPC_Bet;
                        player.WriteResult();
                    }

                    #endregion GIOCATA PLAYER


                    #region GIOCATA DEALER

                    //Controllo che il player non abbia blackjack
                    int countBlackJack = 0;
                    foreach (Hand playerHand in player.hands)
                    {
                        if (Util.CheckBlackJack(playerHand))
                            countBlackJack++;
                    }


                    string dealerAction = "";
                    if (countBlackJack != player.hands.Count)
                        while (dealer.hand.punteggio.Value < 21 &&
                               !dealer.hand.f_bust &&
                               dealerAction != "STAND")
                        {
                            dealer.WriteResult();
                            dealerAction = dealer.ApplyRules(conf);
                            log.WriteLine(dealerAction);
                            if (dealerAction == "HIT")
                                dealer.GiveCard(cardSequence.Dequeue());

                        }

                    dealer.WriteResult();


                    #endregion GIOCATA DEALER

                }

                else
                {
                    Player.TotalHands++;
                    Player.Default_TotalBet += player.hands[0].FlatBet;
                    Player.HL_TotalBet += player.hands[0].HL_Bet;
                    Player.RAPC_TotalBet += player.hands[0].RAPC_Bet;
                    player.WriteResult();
                    dealer.WriteResult();
                }

                //Check the results for the play
                CheckTheWinner(player, dealer);

                StringBuilder cardSeq = new StringBuilder();
                cardSeq.Append("D:");

                foreach (string card in dealer.hand.Cards)
                {
                    cardSeq.Append(card + ",");
                    countManager.UpdateAllCounters(card);
                }

                cardSeq.Append("  P:");

                var result = "";
                var bet_result = 0f;
                foreach (Hand playerHand in player.hands)
                {
                    result += playerHand.Result + " ";
                    bet_result += playerHand.FlatBetResult;
                    foreach (string card in playerHand.Cards)
                    {
                        cardSeq.Append(card + ",");
                        countManager.UpdateAllCounters(card);
                    }
                }

                #region UPDATE PLAY RECORD

                playRecord.PlayID++;
                playRecord.Result = result;
                playRecord.FlatBetResult = bet_result;
                playRecord.HL_RunningCounter = countManager.hl_counter.RunningCounter;
                playRecord.HL_TrueCounter = countManager.hl_counter.TrueCounter;
                playRecord.RAPC_RunningCounter = countManager.rapc_counter.RunningCounter;
                playRecord.RAPC_TrueCounter = countManager.rapc_counter.TrueCounter;

                playRecord.BasicTotalBet = Player.Default_TotalBet;
                playRecord.HL_TotalBet = Player.HL_TotalBet;
                playRecord.RAPC_TotalBet = Player.RAPC_TotalBet;
                playRecord.TotalHands = Player.TotalHands;
                playRecord.TotalHWin = Player.TotalHWin;
                playRecord.TotalHLose = Player.TotalHLose;
                playRecord.TotalHPush = Player.TotalHPush;
                playRecord.TotalBlackJack = Player.TotalBlackJack;


                playRecord.CardSequence = cardSeq.ToString();

                playRecord.Flat_PlayerStake = Player.BasicStake;
                playRecord.HL_PlayerStake = Player.HL_Stake;
                playRecord.RAPC_PlayerStake = Player.RAPC_Stake;

                #endregion UPDATE PLAY RECORD


                playFile.WriteLine(playRecord);

                if (f_OneShot)
                    break;

            }

           
        }

        /// <summary>
        /// Check the results
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dealer"></param>
        /// <returns></returns>
        static List<string> CheckTheWinner(Player player, Dealer dealer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var dealerHand = dealer.hand;
            var punteggioDealer = dealerHand.punteggio.Value;
            var results = new List<string>();

            foreach (Hand playerHand in player.hands)
            {
                var punteggioPlayer = playerHand.punteggio.Value;

                //Risultato partita
                if (punteggioPlayer > 21)
                    playerHand.Result = "BUST";
                else if (punteggioDealer > 21)
                    playerHand.Result = "WIN";
                else if (Util.CheckBlackJack(playerHand))
                {
                    if (!Util.CheckBlackJack(dealerHand))
                        playerHand.Result = "WIN_BJ";
                    else
                        playerHand.Result = "PUSH_BJ";
                }
                else if (punteggioPlayer > punteggioDealer)
                    playerHand.Result = "WIN";
                else if (punteggioPlayer < punteggioDealer)
                    playerHand.Result = "LOSE";
                else
                    playerHand.Result = "PUSH";

                //Update counters and log
                switch (playerHand.Result)
                {
                    case "BUST":
                        {
                            Player.TotalHBust++;
                            Player.TotalHLose++;
                            Player.BasicStake -= playerHand.FlatBet;
                            playerHand.FlatBetResult = -playerHand.FlatBet;
                            Player.HL_Stake -= playerHand.HL_Bet;
                            playerHand.HL_BetResult = -playerHand.HL_Bet;
                            Player.RAPC_Stake -= playerHand.RAPC_Bet;
                            playerHand.RAPC_BetResult = -playerHand.RAPC_Bet;
                            log.WriteLine($"Il dealer vince");
                            break;
                        }
                    case "LOSE":
                        {
                            Player.TotalHLose++;
                            Player.BasicStake -= playerHand.FlatBet;
                            playerHand.FlatBetResult = -playerHand.FlatBet;
                            Player.HL_Stake -= playerHand.HL_Bet;
                            playerHand.HL_BetResult = -playerHand.HL_Bet;
                            Player.RAPC_Stake -= playerHand.RAPC_Bet;
                            playerHand.RAPC_BetResult = -playerHand.RAPC_Bet;
                            log.WriteLine($"Il dealer vince");
                            break;
                        }
                    case "WIN":
                        {
                            Player.TotalHWin++;
                            Player.BasicStake += playerHand.FlatBet;
                            playerHand.FlatBetResult = playerHand.FlatBet;
                            Player.HL_Stake += playerHand.HL_Bet;
                            playerHand.HL_BetResult = playerHand.HL_Bet;
                            Player.RAPC_Stake += playerHand.RAPC_Bet;
                            playerHand.RAPC_BetResult = playerHand.RAPC_Bet;
                            log.WriteLine($"Il player vince");
                            break;
                        }
                    case "PUSH":
                        {
                            Player.TotalHPush++;
                            log.WriteLine($"Push");
                            break;
                        }
                    case "WIN_BJ":
                        {
                            Player.TotalBlackJack++;
                            Player.TotalHWin++;
                            Player.BasicStake += playerHand.FlatBet*1.5f;
                            playerHand.FlatBetResult = playerHand.FlatBet*1.5f;
                            Player.HL_Stake += playerHand.HL_Bet*1.5f;
                            playerHand.HL_BetResult = playerHand.HL_Bet * 1.5f; 
                            Player.RAPC_Stake += playerHand.RAPC_Bet * 1.5f; 
                            playerHand.RAPC_BetResult = playerHand.RAPC_Bet * 1.5f; 
                            log.WriteLine($"Il player vince");
                            break;
                        }
                    case "PUSH_BJ":
                        {
                            Player.TotalBlackJack++;
                            Player.TotalHPush++;
                            log.WriteLine($"Push");
                            break;
                        }
                    default: break;

                }

                results.Add(playerHand.Result);


            }
            
            Console.ResetColor();
            log.WriteLine($"Saldo Default player: {Player.BasicStake}");
            log.WriteLine($"Saldo HL player: {Player.HL_Stake}");
            log.WriteLine($"Saldo RAPC player: {Player.RAPC_Stake}");

            return results;

        }

    }
}
