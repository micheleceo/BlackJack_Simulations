using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.CountingStrategy
{
    public class RAPC_Counter: ACounter
    {
        public RAPC_Counter(Shoe shoe) : base(shoe) { }

        public override int CalulateIncrement(string cardFace)
        {
            int increment = 0;
            switch (cardFace)
            {
                case "A":
                    increment = -4;
                    break;
                case "2":
                    increment = 2;
                    break;
                case "3":
                case "4":
                case "6":
                    increment = 3;
                    break;
                case "5":
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

        public override void UpdateTrueCounter()
        {
            TrueCounter = RunningCounter / (RemainingDecks * 2);
        }

        public override float CalculateBet(float defaultBet)
        {
            float methodBet = defaultBet;

         /*   if (TrueCounter < 1.5)
                methodBet = defaultBet;
            else if (TrueCounter < 2)
                methodBet = defaultBet * 2;
            else if (TrueCounter < 2.5)
                methodBet = defaultBet * 3;
            else if (TrueCounter < 3)
                methodBet = defaultBet * 4;
            else if (TrueCounter < 3.5)
                methodBet = defaultBet * 5;
            else if (TrueCounter < 4)
                methodBet = defaultBet * 6;
            else if (TrueCounter < 4.5)
                methodBet = defaultBet * 7;
            else*/ if (TrueCounter > 1.5)
                methodBet = defaultBet * 10;
         //   else if (TrueCounter < 5.5)
          //      methodBet = defaultBet * 9;
        //    else if (TrueCounter < 6)
        //        methodBet = defaultBet * 2;
        //  //  else if (TrueCounter < 6.5)
        //  //      methodBet = defaultBet * 11;
        //    else if (TrueCounter < 7)
        //        methodBet = defaultBet * 4;
        // //   else if (TrueCounter < 7.5)
        //  //      methodBet = defaultBet * 13;
        //    else if (TrueCounter < 8)
        //        methodBet = defaultBet * 5;
        ////    else if (TrueCounter < 8.5)
        ////        methodBet = defaultBet * 15;
        //    else if (TrueCounter < 9)
        //        methodBet = defaultBet * 6;
        //    else
        //        methodBet = defaultBet * 10;

            return methodBet;
        }

    }
}
