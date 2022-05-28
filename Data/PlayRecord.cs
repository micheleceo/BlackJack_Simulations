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
        public float FlatBetResult { get; set; }
        public float Flat_PlayerStake { get; set; }
        public float HL_PlayerStake { get; set; }
        public float RAPC_PlayerStake { get; set; }
        public float BasicTotalBet { get; set; }
        public float HL_TotalBet { get; set; }
        public float RAPC_TotalBet { get; set; }

        public int TotalHands { get; set; }
        public int TotalHWin { get; set; }
        public int TotalHLose { get; set; }
        public int TotalHPush { get; set; }
        public int TotalBlackJack { get; set; }
        public int HL_RunningCounter { get; set; }
        public float HL_TrueCounter { get; set; }
        public int RAPC_RunningCounter { get; set; }
        public float RAPC_TrueCounter { get; set; }
    }
}
