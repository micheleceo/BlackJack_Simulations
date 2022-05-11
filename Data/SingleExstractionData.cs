using BlackJack.CountingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class SingleExstractionData
    {
        public int ShoeNumber { get; set; } = 1;
        public int deckNumber { get; set; } = 1;
        public string Card { get; set; }
        public int HL_RunningCounter { get; set; }
        public float HL_TrueCounter { get; set; }
        public int RAPC_RunningCounter { get; set; }
        public float RAPC_TrueCounter { get; set; }
      
    }
}
