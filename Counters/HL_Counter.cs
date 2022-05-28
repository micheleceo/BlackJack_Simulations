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

        public override void UpdateTrueCounter()
        {
            TrueCounter = ((float)RunningCounter / RemainingDecks);
        }

        public override float CalculateBet (float defaultBet)
        {
            float methodBet = 0;

            if (TrueCounter < 3)
                methodBet=defaultBet;
            else if  (TrueCounter < 4)
                methodBet = defaultBet*2;
            else if (TrueCounter < 5)
                methodBet = defaultBet*3;
            else if (TrueCounter < 6)
                methodBet = defaultBet*4;
            else if (TrueCounter < 7)
                methodBet = defaultBet * 5;
            else if (TrueCounter < 8)
                methodBet = defaultBet * 6;
            else if (TrueCounter < 9)
                methodBet = defaultBet * 7;
            else
                methodBet= defaultBet * 8;

            return methodBet;
        }
    }
}
