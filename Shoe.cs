using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    /// <summary>
    /// Gestione dello shoe e dei mazzi da estrarre
    /// </summary>
    public class Shoe
    {
        /// <summary>
        /// Remaining decks number in the shoe
        /// </summary>
        public float RemainingDecks
        {
            get
            {
                return RemaningCards / (float)Costanti.N_CARTE_MAZZO;
            }
        }
        /// <summary>
        /// Remaining cards number in the shoe
        /// </summary>
        private int RemaningCards
        {
            get
            {
                return cards.Count;
            }
        }

        /// <summary>
        /// Temporary remaining decks number in the shoe
        /// </summary>
        public float Temp_RemainingDecks
        {
            get
            {
                return Temp_RemaningCards / (float)Costanti.N_CARTE_MAZZO;
            }
        }

        /// <summary>
        /// Temporary remaining cards number in the shoe
        private int Temp_RemaningCards
        {
            get
            {
                return temp_cards.Count;
            }
        }

        private Random rand = new Random();

        /// <summary>
        /// Temporary list of sorted cards
        /// </summary>
        private List<string> temp_cards = new List<string>();
        /// <summary>
        /// Cards queue of the shuffled shoes
        /// </summary>
        public Queue<string> cards = new Queue<string>();

        /// <summary>
        /// Inizializzazione del session deck
        /// </summary>
        /// <param name="deckNumber"></param>
        /// <param name="deckToUse"></param>
        public Shoe(int totDeckNumber, int totdeckNumberToUse, List<string> deck)
        {
            temp_cards = new List<string>();
           
            for (int k = 1; k <= totDeckNumber; k++)
                temp_cards.AddRange(deck);
        }

        /// <summary>
        /// Resituisce dallo shoe una lista casuale delle carte pari
        /// al numero di azzi da giocare
        /// </summary>
        /// <returns></returns>
        public void Shuffle()
        {
            //Mischia le carte e le mette in una coda
            while (temp_cards.Count>0)
                cards.Enqueue(ChooseRandomCard());
        }
                   

        /// <summary>
        /// Pesca una carta dalla lista delle carte ordinate
        /// </summary>
        /// <returns></returns>
        public string ChooseRandomCard()
        {
            //Seleziono un indice random dal mazzo
            var card_index = rand.Next(0, temp_cards.Count - 1);
            //Pesco la carta con l'indice scelto
            var card_face = temp_cards[card_index];
            //Elimino la carta da mazzo
            temp_cards.RemoveAt(card_index);
            return card_face;
        }

        /// <summary>
        /// Prendi una carta dallo shoe
        /// </summary>
        /// <returns></returns>
        public string GetCard()
        {
            cards.TryDequeue(out var card);
            return card;
        }

        #region TempCards
        public int TempCard_GetIndex(string cardFace)
        {
            return temp_cards.IndexOf(cardFace);
        }


        public void TempCard_Remove(int index)
        {
            temp_cards.RemoveAt(index);
        }

        #endregion TempCard


    }
}
