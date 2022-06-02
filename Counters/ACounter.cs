using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public abstract class ACounter
    {
        public Shoe Shoe { get; set; }
        public ACounter(Shoe shoe)
        {
            Shoe = shoe;
        }

        /// <summary>
        /// Running Counter
        /// </summary>
        public int RunningCounter { get; set; }
        /// <summary>
        /// True Counter
        /// </summary>
        abstract public float TrueCounter { get;}
        /// <summary>
        /// Ace Counter
        /// </summary>
        public int AceCounter { get; set; }
        /// <summary>
        /// Ten Counter
        /// </summary>
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
        /// Update Running Count
        /// </summary>
        /// <param name="cardFace"></param>
        public void UpdateCounters(string cardFace)
        {
            RunningCounter += CalulateIncrement(cardFace);
        }
      
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
