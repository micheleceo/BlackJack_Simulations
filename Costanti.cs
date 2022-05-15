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
        //Definizione Shoe
        public const int N_MAZZI_PER_SHOE = 8;
        public const int N_MAZZI_DA_ESTRARRE_PER_SHOE = 4;
        public const int N_CARTE_DA_ESTRARRE_PER_SHOE = 4 * N_CARTE_MAZZO;
        //Iterazioni simulazione
        public const int N_SHOES = 1000;

        //Console
        public const bool f_console = false;
        public const bool f_txtLog = true;
    }
}
