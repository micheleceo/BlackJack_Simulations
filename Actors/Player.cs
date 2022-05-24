using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public class Player:AActor, IActor
    {
        /// <summary>
        /// Lista delle mani
        /// </summary>
        public List<Hand> hands = new List<Hand>();

        BasicStrategyL basic = new BasicStrategyL();

        public static float Stake = 0;

        public static float TotalBet = 0;

        public static int TotalHands = 0;

        public static int TotalHWin = 0;

        public static int TotalHLose = 0;

        public static int TotalHBust = 0;

        public static int TotalHPush = 0;


        public override void NewHand()
        {
            hands.Add(new Hand());
        }

        public string AskAction(int handID, int enemyPoint)
        {
            if (hands[handID].punteggio.Value >= 21)
                return "STAND";
             else
                return ApplicaStrategiaBase(hands[handID],enemyPoint);
        }

        public override void GiveCard(string card,int handID=0)
        {
            hands[handID].AddCard(card);
        }

        string ApplicaStrategiaBase(Hand hand,int dealerFirstCard)
        {
            //TODO: Check double and split again

            var response = basic.ApplyStrategy(hand,dealerFirstCard);

            //Correct if double down is not possible
            if (response == "DOUBLE DOWN" && ( hand.Cards.Count != 2 || hand.f_splitted) )
                response = "HIT";

            return response;
        }

        
        public void WriteResult()
        {
            if (Costanti.f_print_hands_on_console)
            {
                foreach (Hand hand in hands)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    StringBuilder actorString = new StringBuilder();
                    actorString.Append((GetType().ToString().ToUpper() + ": ").Split('.')[1]);
                    actorString.Append(string.Join(", ", hand.Cards));
                    actorString.Append(" --> " + hand.punteggio.Value);
                    if (hand.punteggio.Value > 21)
                        actorString.Append(" : SBALLATO");
                    else if (Util.CheckBlackJack(hand))
                        actorString.Append(" : BLACKJACK");
                    Console.WriteLine(actorString);
                }
            }
        }

        public void WriteHandResult(Hand hand)
        {
            if(Costanti.f_print_hands_on_console)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                StringBuilder actorString = new StringBuilder();
                actorString.Append((GetType().ToString().ToUpper() + ": ").Split('.')[1]);
                actorString.Append(string.Join(", ", hand.Cards));
                actorString.Append(" --> " + hand.punteggio.Value);
                if (hand.punteggio.Value > 21)
                    actorString.Append(" : SBALLATO");
                else if (Util.CheckBlackJack(hand))
                    actorString.Append(" : BLACKJACK");
                Console.WriteLine(actorString);
            }

        }

    }

}
