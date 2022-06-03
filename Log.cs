using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public class Log
    {
        public static void Write(string text)
        {
            if (Configs.f_print_hands_on_console)
                Console.Write(text);
        }

        public static void WriteLine(string text)
        {
            if (Configs.f_print_hands_on_console)
                Console.WriteLine(text);
        }

    }
}
