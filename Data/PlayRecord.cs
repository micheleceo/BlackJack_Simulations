using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.Data
{
    public class PlayRecord
    {
        public int ShoeID{ get; set; } = 0;
        public int PlayID { get; set; } = 0;
        public string CardSequence { get; set; }
        public string Result { get; set; }
        public string PlayerStake { get; set; }
        public int HL_RunningCounter { get; set; }
        public float HL_TrueCounter { get; set; }
        public int RAPC_RunningCounter { get; set; }
        public float RAPC_TrueCounter { get; set; }
    }
}
