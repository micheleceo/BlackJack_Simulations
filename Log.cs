using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Log
    {
        //public void Log()
        //{
        //    if(Costanti.f_txtLog)


        //}
        // private FileStream fs = File.Create("Giocate");


        // StringBuilder statistics = new StringBuilder();

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


        //    statistics.AppendLine($"HL TrueCounter -" +
        //                              $" MIN: {stat_data.memory.HL_TrueCountersequence.Min()}" +
        //                              $" MAX: {stat_data.memory.HL_TrueCountersequence.Max()}");
        //        statistics.AppendLine($"RAPC TrueCounter -" +
        //                              $" MIN: {stat_data.memory.RAPC_TrueCounterSequence.Min()}" +
        //                              $" MAX: {stat_data.memory.RAPC_TrueCounterSequence.Max()}");

        //        File.WriteAllText("Stat.log", statistics.ToString());
        //}
    }
}
