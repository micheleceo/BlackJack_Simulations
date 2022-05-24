using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public interface IActor
    {

        /// <summary>
        /// Creazione nuova mano
        /// </summary>
        /// <param name="f_split">In caso di split segna il flag</param>
        public void NewHand();


        /// <summary>
        /// Distribuzione dell carta
        /// </summary>
        /// <param name="handID">Mano a cui assegnare la carta</param>
        /// <param name="card">Carta da aggiungere</param>
        public void GiveCard(string card, int handID = 0);


    }
}
