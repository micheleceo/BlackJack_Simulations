using BlackJackSimul.CountingStrategy;
using BlackJackSimul.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlackJackSimul
{
    class Program
    {
        static void Main(string[] args)
        {

           // var conf = new Config();
           // File.WriteAllText("Configuration.json", JsonConvert.SerializeObject(conf, Formatting.Indented));

            Config conf = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Configuration.json"));
            string configJa = JsonConvert.SerializeObject(conf, Formatting.Indented);

            Simulation simulation = new Simulation(Costanti.N_SHOES, Costanti.N_MAZZI_PER_SHOE, Costanti.N_MAZZI_DA_ESTRARRE_PER_SHOE);
            simulation.Start();

        }

        //private static void WriteStatistic(StatisticData stat_data)
        //{

        //    StringBuilder statistics = new StringBuilder();
        //    statistics.AppendLine($"HL TrueCounter -" +
        //                          $" MIN: {stat_data.memory.HL_TrueCountersequence.Min()}" +
        //                          $" MAX: {stat_data.memory.HL_TrueCountersequence.Max()}");
        //    statistics.AppendLine($"RAPC TrueCounter -" +
        //                          $" MIN: {stat_data.memory.RAPC_TrueCounterSequence.Min()}" +
        //                          $" MAX: {stat_data.memory.RAPC_TrueCounterSequence.Max()}");

        //    File.WriteAllText("Stat.log", statistics.ToString());

        //}


    }
}
