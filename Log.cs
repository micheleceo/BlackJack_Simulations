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
        public void Write(string text)
        {
            if (Costanti.f_console)
                Console.Write(text);
        }

        public void WriteLine(string text)
        {
            if (Costanti.f_console)
                Console.WriteLine(text);
        }

    }
}
