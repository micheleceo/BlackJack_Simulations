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

      

        public static float TotVincita = 0;


        public override void NewHand(bool f_split = false)
        {
            hands.Add(new Hand());
        }

        public string Ask(int handID, int enemyPoint)
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
            string response = "";
            BasicStrategyL basic = new BasicStrategyL();

            response = basic.ApplyStrategy(hand,dealerFirstCard);

            if (response == "DOUBLE DOWN" && ( hand.Cards.Count != 2 || hand.f_split))
                response = "HIT";

            return response;
        }


        string ApplicaStrategiaDummy()
        {
            string response = "";

            //Strategia base
            if (hands[0].punteggio.Value <= 16)
                response = "HIT";
            else if (hands[0].punteggio.Value >= 17 && hands[0].punteggio.Value <= 21)
                response = "STAND";
            else
                response = "SBALLATO";

            return response;
        }

        
        public void WriteResult()
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

        public void WriteHandResult(Hand hand)
        {
            if(Costanti.f_console)
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
