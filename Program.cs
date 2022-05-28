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

    


    }
}
