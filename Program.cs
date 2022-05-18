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
            Config conf = new Config();
            try
            {
                conf = JsonConvert.DeserializeObject<Config>(File.ReadAllText("Configuration.json"));
            }
            catch
            {
                Console.WriteLine("Configuration.json file not found");
            }
           
            //    File.WriteAllText("Configuration.json", JsonConvert.SerializeObject(conf, Formatting.Indented));

            Simulation simulation = new Simulation(conf);
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
