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

        public float RemainingDecks { get; set; }
       
        public Shoe _shoe{ get; set; }
        public ACounter(Shoe shoe)
        {
            _shoe = shoe;
        }
        public int AceCounter { get; set; }

        public int TenCounter { get; set; }

        public abstract float CalculateBet(float defaultBet);


        public abstract int CalulateIncrement(string cardFace);

        public void UpdateMainCounters(string cardFace)
        {
            RemainingDecks = (float)_shoe.cards.Count / (float)Costanti.N_CARTE_MAZZO;
            RunningCounter += CalulateIncrement(cardFace);
            UpdateTrueCounter();
        }

        public void UpdateRemainigDecks()
        {
            
        }
        public abstract void UpdateTrueCounter();

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
