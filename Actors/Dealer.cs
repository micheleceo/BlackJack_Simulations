using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Dealer : IActor
    {
        public Hand hand; 
        //Regole da applicare
        public bool f_hit_soft17 = false;
        public bool regola2 = true;
       
        static public int CounterBlackJack { get; set; }

        public void NewHand(bool f_split = false)
        {
            hand = new Hand();
        }

        public void GiveCard(string card, int handID=0)
        {
            hand.AddCard(card);
        }

        public string ApplicaRegole()
        {
            var punteggio = hand.punteggio.Value;
            string response = "";

            //TODO: implementare soft 17

            if (punteggio <= 16)
                response = "HIT";
            else if (punteggio >= 17 && punteggio < 21)
                response = "STAND";
            else
                response = "AFFANGUL";

            return response;
        }

        public void WriteResult()
        {
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
