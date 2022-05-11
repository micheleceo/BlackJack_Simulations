using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class StatisticData
    {
        public Memory memory;
        public Results results;

        public StatisticData()
        {
            memory = new Memory();
            results = new Results();
        }

        public class Memory
        {
          
            public List<float> HL_TrueCountersequence = new List<float>();
            public List<float> RAPC_TrueCounterSequence = new List<float>();
        }

        public class Results
        {
            public float Min_HL_TrueCounter { get; set; }
            public float Max_HL_TrueCounter { get; set; }
            public float Min_RAPC_TrueCounter { get; set; }
            public float Max_RAPC_TrueCounter { get; set; }
        }
       
    }
}
