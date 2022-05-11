using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Utilities class
    /// </summary>
    public static class Util
    {
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

            if (hand.Cards.Count == 2 && hand.punteggio.Value == 21)
                f_BlackJack = true;

            return f_BlackJack;
        }
    }
}
