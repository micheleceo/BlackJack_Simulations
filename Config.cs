using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{

    public class Config
    {
        public int ShoeDeckTotalNumber { get; set; } = 8;
        public int ShoeDeckToExtractNumber { get; set; } = 4;
        public int SimulationTotalShoes { get; set; } = 100;
        public bool f_dealer_Soft17_hit { get; set; } = false;
        public bool f_console { get; set; } = false;
    }



}
