using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    /// <summary>
    /// Create a classic card deck
    /// </summary>
    public static class CardDeck
    {
        //Standard deck
        public const int N_TIPI_CARTE = 13;
        public const int N_SEMI = 4;
        public const int CARD_NUMBER = N_TIPI_CARTE * N_SEMI;

        public static List<string> Create()
        {
            List<string> cardDeck = new();
            for (int j = 1; j <= N_SEMI; j++)
            {
                cardDeck.Add("A");
                for (int c = 2; c <= 10; c++)
                    cardDeck.Add(c.ToString());
                cardDeck.Add("J");
                cardDeck.Add("Q");
                cardDeck.Add("K");
            }
            return cardDeck;
        }

    }//end of class
}//end of namespace
