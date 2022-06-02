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
                        Console.WriteLine("Carta non trovata");
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
                        Console.WriteLine($"Carta {cardFace} non trovata");

                }
                else Console.WriteLine($"Non posso togliere {cardFace}, il troucounter andrebbe a {trueCounter + trueIncrement}");

            }
           
        }

    }
}
