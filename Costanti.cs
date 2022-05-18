using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public static class Costanti
    {
        //Costanti caratterustiche delle carte
        public const int N_TIPI_CARTE = 13;
        public const int N_SEMI = 4;
        public const int N_CARTE_MAZZO = N_TIPI_CARTE * N_SEMI;

        //TODO: rendere configurabili
        //Console
        public const bool f_print_hands_on_console = true;
     //   public const bool f_txtLog = true;
    }
}
