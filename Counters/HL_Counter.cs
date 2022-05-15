using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.CountingStrategy
{
    public class HL_Counter : ACounter
    {
       public HL_Counter(Shoe shoe) : base(shoe) { }

       public override int CalulateIncrement(string cardValue) 
       {
            int increment = 0;
            switch (cardValue)
            {
                case "A":
                    {
                        increment = -1;
                        AceCounter++;
                        break;
                    }
                    
                case "10":
                case "J":
                case "Q":
                case "K":
                    {
                        increment = -1;
                        TenCounter++;
                        break;
                    }
                    
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                    increment = 1;
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
            TrueCounter = ((float)RunningCounter / RemainingDecks);
            UpddateSideCounters(cardFace);
        }
    }
}
