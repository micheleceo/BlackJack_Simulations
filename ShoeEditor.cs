using BlackJackSimul.CountingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public static class ShoeEditor
    {
        
        public enum CounterType{
            HL_Counter,
            RAPC_Counter
        }
        /// <summary>
        /// Edit the shoe to reach the target counter
        /// </summary>
        /// <param name="shoe">Shoe to edit</param>
        /// <param name="counter">Counter type</param>
        /// <param name="targetTrueCounter">Tragert counter to reach</param>
        public static void Edit(Shoe shoe, CounterType counter, float targetTrueCounter)
        {
            Random rand = new Random();
            var countManager = new CountersManager(shoe);
            string cardFace="";
            float trueIncrement = 0;
            float trueCounter = 0;

            while (Math.Abs(trueCounter - targetTrueCounter) > 0.1f)
            {
                switch (counter)
                {
                    case CounterType.HL_Counter:
                        {
                            cardFace = rand.Next(2, 6+1).ToString();
                            trueIncrement = countManager.hl_counter.CalulateIncrement(cardFace)/shoe.Temp_RemainingDecks;
                            break;
                        }
                    case CounterType.RAPC_Counter:
                        {
                            cardFace = rand.Next(2, 7+1).ToString();
                            trueIncrement = countManager.hl_counter.CalulateIncrement(cardFace)/(shoe.Temp_RemainingDecks * 2);
                            break;
                        }

                    default:
                        Console.WriteLine("Card non found");
                        break;
                }

                if (trueCounter + trueIncrement <= targetTrueCounter + 0.2f)
                {
                    trueCounter += trueIncrement;
                    var index = shoe.TempCard_GetIndex(cardFace);
                    if (shoe.TempCard_GetIndex(cardFace) != -1)
                    {
                        shoe.TempCard_Remove(index);
                        Console.WriteLine($"Removed {cardFace} \t TrueCounter = {trueCounter}");
                    }
                    else
                        Console.WriteLine($"Card {cardFace} not found");

                }
                else Console.WriteLine($"Can't remove {cardFace} because TrueCounter will be {trueCounter + trueIncrement}");

            }
           
        }

    }
}
