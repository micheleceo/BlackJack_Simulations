using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public abstract class ACounter
    {
        public Shoe _shoe { get; set; }
        public ACounter(Shoe shoe)
        {
            _shoe = shoe;
        }

        public int RunningCounter { get; set; }

        public float TrueCounter { get; set; }

        public float RemainingDecks { get; set; }
       
        public int AceCounter { get; set; }

        public int TenCounter { get; set; }
        /// <summary>
        /// Calculate bet for the counter method
        /// </summary>
        /// <param name="flatBet"></param>
        /// <returns></returns>
        public abstract float CalculateBet(float flatBet);
        /// <summary>
        /// Calculate increment for the counter method
        /// </summary>
        /// <param name="cardFace"></param>
        /// <returns></returns>
        public abstract int CalulateIncrement(string cardFace);
        /// <summary>
        /// Update RunningCount and Truecounter
        /// </summary>
        /// <param name="cardFace"></param>
        public void UpdateMainCounters(string cardFace)
        {
            RemainingDecks = (float)_shoe.cards.Count / (float)Costanti.N_CARTE_MAZZO;
            RunningCounter += CalulateIncrement(cardFace);
            UpdateTrueCounter();
        }
        /// <summary>
        /// Update TrueCounter
        /// </summary>
        public abstract void UpdateTrueCounter();
        /// <summary>
        /// Update SideCounters
        /// </summary>
        /// <param name="cardValue"></param>
        public void UpdateSideCounters(string cardValue)
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
