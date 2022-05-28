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
                        break;
                    }
                    
                case "10":
                case "J":
                case "Q":
                case "K":
                    {
                        increment = -1;
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

        public override void UpdateTrueCounter()
        {
            TrueCounter = RunningCounter / RemainingDecks;
        }

        public override float CalculateBet (float flatBet)
        {
            float methodBet = flatBet;

            if (TrueCounter < 3)
                methodBet=flatBet;
            else if  (TrueCounter < 4)
                methodBet = flatBet*2;
            else if (TrueCounter < 5)
                methodBet = flatBet*3;
            else if (TrueCounter < 6)
                methodBet = flatBet*4;
            else if (TrueCounter < 7)
                methodBet = flatBet * 5;
            else if (TrueCounter < 8)
                methodBet = flatBet * 6;
            else if (TrueCounter < 9)
                methodBet = flatBet * 7;
            else
                methodBet= flatBet * 8;

            return methodBet;
        }
    }
}
