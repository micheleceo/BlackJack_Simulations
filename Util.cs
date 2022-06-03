using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    /// <summary>
    /// Utilities class
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Calculate point value
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static int PointOf(string card)
        {
            int card_point = 0;

            switch (card)
            {
                case "A":
                    card_point = 11;
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    int.TryParse(card, out card_point);
                    break;
                case "J":
                case "Q":
                case "K":
                    card_point = 10;
                    break;
                default:
                    break;
            }

            return card_point;
        }

        /// <summary>
        /// Controllo BlackJack a due carte
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        public static bool CheckBlackJack(Hand hand)
        {
            bool f_BlackJack = false;

            if (hand.Cards.Count == 2 && hand.punteggio.Value == 21 && !hand.f_splitted)
                f_BlackJack = true;

            return f_BlackJack;
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
