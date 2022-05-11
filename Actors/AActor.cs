using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class AActor : IActor
    {
        /// <summary>
        /// Mani vinte
        /// </summary>
        static public int ManiVinte { get; set; }
        /// <summary>
        /// Mani pareggiate
        /// </summary>
        static public int ManiPareggiate { get; set; }
        /// <summary>
        /// Contatore di blackjack
        /// </summary>
        static public int CounterBlackJack { get; set; }

        /// <summary>
        /// Creazione nuova mano
        /// </summary>
        /// <param name="f_split">In caso di split segna il flag</param>
        public abstract void NewHand(bool f_split = false);


        /// <summary>
        /// Distribuzione dell carta
        /// </summary>
        /// <param name="handID">Mano a cui assegnare la carta</param>
        /// <param name="card">Carta da aggiungere</param>
        public abstract void GiveCard(string card, int handID = 0);
    }
}
