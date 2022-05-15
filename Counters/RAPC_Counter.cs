using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.CountingStrategy
{
    class RAPC_Counter: ACounter
    {
        public RAPC_Counter(Shoe shoe) : base(shoe) { }

        public override int CalulateIncrement(string cardValue)
        {
            int increment = 0;
            switch (cardValue)
            {
                case "A":
                    increment = -4;
                    break;

                case "2":
                    increment = 2;
                    break;
                case "3":
                case "4":
                case "5":
                    increment = 3;
                    break;
                case "6":
                    increment = 4;
                    break;
                case "7":
                    increment = 2;
                    break;
                case "8":
                    increment = -1;
                    break;
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                    increment = -3;
                    break;
                default:
                    // code block
                    break;
            }

            return increment;

       }


        public override void UpdateMainCounters(string cardFace)
        {
            var RemainingDecks = (float)_shoe.cards.Count / (float)Costanti.N_CARTE_MAZZO;
            RunningCounter += CalulateIncrement(cardFace);
            TrueCounter = ((float)RunningCounter / (RemainingDecks*2));
        }
    }
}
