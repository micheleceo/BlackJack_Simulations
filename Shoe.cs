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
        /// Numero di mazzi di cui è composto lo shoe
        /// </summary>
        private int TotDeckNumber { get; }
        /// <summary>
        /// Numero di carte totali
        /// </summary>
        public int TotCardNumber { get; }

        private Random rand = new Random();

        public List<string> temp_cards = new List<string>();
        public Queue<string> cards = new Queue<string>();

        /// <summary>
        /// Inizializzazione del session deck
        /// </summary>
        /// <param name="deckNumber"></param>
        /// <param name="deckToUse"></param>
        public Shoe(int totDeckNumber, int totdeckNumberToUse, List<string> deck)
        {
            TotDeckNumber = totDeckNumber;
            TotCardNumber = TotDeckNumber * Costanti.N_CARTE_MAZZO;

            temp_cards = new List<string>();
            for (int k = 1; k <= TotDeckNumber; k++)
                temp_cards.AddRange(deck);
                //for (int j = 1; j <= Costanti.N_SEMI; j++)
                //{
                //    temp_cards.Add("A");
                //    for (int c = 2; c <= 10; c++)
                //        temp_cards.Add(c.ToString());
                //    temp_cards.Add("J");
                //    temp_cards.Add("Q");
                //    temp_cards.Add("K");
                //}
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

    }
}
