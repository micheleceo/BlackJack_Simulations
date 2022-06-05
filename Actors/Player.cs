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
        /// Hand list can be two in case of split
        /// </summary>
        public List<Hand> hands = new List<Hand>();

        BasicStrategyL basic = new BasicStrategyL();

        public static float BasicStake = 0;
        public static float HL_Stake = 0;
        public static float RAPC_Stake = 0;

        public static float Default_TotalBet = 0;
        public static float HL_TotalBet = 0;
        public static float RAPC_TotalBet = 0;

        public static int TotalHands = 0;

        public static int TotalHWin = 0;

        public static int TotalHLose = 0;

        public static int TotalHBust = 0;

        public static int TotalHPush = 0;


        public override void NewHand(float flatBet)
        {
            hands.Add(new Hand(flatBet));
        }

        public override void GiveCard(string card, int handID = 0)
        {
            hands[handID].AddCard(card);
        }

        public string AskAction(int handID, int dealerFirstCard)
        {
            if (hands[handID].score.Value >= 21)
                return "STAND";
             else
                return ApplicaStrategiaBase(hands[handID],dealerFirstCard);
        }
      
        string ApplicaStrategiaBase(Hand hand,int dealerFirstCard)
        {
            var response = basic.ApplyStrategy(hand,dealerFirstCard);

            //Correct if double down if it is not possible
            if (response == "DOUBLE DOWN" && ( hand.Cards.Count != 2 || hand.f_splitted) )
                response = "HIT";

            return response;
        }

        
        public void WriteResult()
        {
            if (Configs.f_print_hands_on_console)
            {
                foreach (Hand hand in hands)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    StringBuilder actorString = new StringBuilder();
                    actorString.Append((GetType().ToString().ToUpper() + ": ").Split('.')[1]);
                    actorString.Append(string.Join(", ", hand.Cards));
                    actorString.Append(" --> " + hand.score.Value);
                    if (hand.score.Value > 21)
                        actorString.Append(" : SBALLATO");
                    else if (Util.CheckBlackJack(hand))
                        actorString.Append(" : BLACKJACK");
                    Console.WriteLine(actorString);
                }
            }
        }

        public void WriteHandResult(Hand hand)
        {
            if(Configs.f_print_hands_on_console)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                StringBuilder actorString = new StringBuilder();
                actorString.Append((GetType().ToString().ToUpper() + ": ").Split('.')[1]);
                actorString.Append(string.Join(", ", hand.Cards));
                actorString.Append(" --> " + hand.score.Value);
                if (hand.score.Value > 21)
                    actorString.Append(" : SBALLATO");
                else if (Util.CheckBlackJack(hand))
                    actorString.Append(" : BLACKJACK");
                Console.WriteLine(actorString);
            }

        }

    }

}
