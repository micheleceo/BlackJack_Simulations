using BlackJackSimul.CountingStrategy;
using BlackJackSimul.Data;
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
            // Single extraction data
            var se_data = new SingleExstractionData();

            // Statistic data
            var stat_data = new StatisticData();

            //Creazione del CSV per singola estrazione
            FileCSV fileCSV = new FileCSV("Data.csv");
            fileCSV.WriteHeader(";", se_data);

            //Ciclo sugli shoe
            for (int nShoes=1; nShoes<= Costanti.N_SHOES; nShoes++)
            {
                   // Statistic data
                   se_data = new SingleExstractionData();

                   // Creazione shoe
                   var shoe = new Shoe(Costanti.N_MAZZI_PER_SHOE, Costanti.N_MAZZI_DA_ESTRARRE_PER_SHOE);
                   shoe.Shuffle();
                   
                   //Creazione dei counter
                   var hl_counter = new HL_Counter(shoe);
                   var rapc_counter = new RAPC_Counter(shoe);

                   se_data.ShoeNumber = nShoes;

                   //Ciclo delle estrazioni per shoe
                   for (int n = 1; n <= Costanti.N_CARTE_DA_ESTRARRE_PER_SHOE; n++)
                   {
                       if (n % Costanti.N_CARTE_MAZZO == 0)
                        se_data.deckNumber++;

                        //Prendi una carta
                        se_data.Card = shoe.GetCard();
                        
                        //Aggiornamento counter HL
                        hl_counter.UpdateCounters(se_data.Card);
                        se_data.HL_RunningCounter = hl_counter.RunningCounter;
                        se_data.HL_TrueCounter = hl_counter.TrueCounter;
                        stat_data.memory.HL_TrueCountersequence.Add(hl_counter.TrueCounter);

                        //Aggiornamento counter RAPC
                        rapc_counter.UpdateCounters(se_data.Card);
                        se_data.RAPC_RunningCounter = rapc_counter.RunningCounter;
                        se_data.RAPC_TrueCounter = rapc_counter.TrueCounter;
                        stat_data.memory.RAPC_TrueCounterSequence.Add(rapc_counter.TrueCounter);

                        fileCSV.WriteData(se_data);
                   }

            }

            fileCSV.Close();

            WriteStatistic(stat_data);

            Simulation simulation = new Simulation(Costanti.N_SHOES, Costanti.N_MAZZI_PER_SHOE, Costanti.N_MAZZI_DA_ESTRARRE_PER_SHOE);
            simulation.Start();

        }


        private static void WriteStatistic(StatisticData stat_data)
        {

            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"HL TrueCounter -" +
                                  $" MIN: {stat_data.memory.HL_TrueCountersequence.Min()}" +
                                  $" MAX: {stat_data.memory.HL_TrueCountersequence.Max()}");
            statistics.AppendLine($"RAPC TrueCounter -" +
                                  $" MIN: {stat_data.memory.RAPC_TrueCounterSequence.Min()}" +
                                  $" MAX: {stat_data.memory.RAPC_TrueCounterSequence.Max()}");

            File.WriteAllText("Stat.log", statistics.ToString());

        }


    }
}
