using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public abstract class ACounter
    {
        public int RunningCounter { get; set; }

        public float TrueCounter { get; set; }
       
        public Shoe _shoe{ get; set; }
        public ACounter(Shoe shoe)
        {
            _shoe = shoe;
        }
        public int AceCounter { get; set; }

        public int TenCounter { get; set; }


        public abstract int CalulateIncrement(string cardFace);

        public abstract void UpdateCounters(string cardFace);

        public void UpddateSideCounters(string cardValue)
        {
            switch (cardValue)
            {
                case "A":
                    {
                        AceCounter++;
                        break;
                    }

                case "10":
                case "J":
                case "Q":
                case "K":
                    {
                        TenCounter++;
                        break;
                    }

            
                default:
                    // code block
                    break;
            }

        }

    }
}
