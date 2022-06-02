using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public static class CardDeck
    {
        public static List<string> Create()
        {
            List<string> cardDeck = new List<string>();
            for (int j = 1; j <= Costanti.N_SEMI; j++)
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

    }
}
