using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class ACounter
    {
        public int RunningCounter { get; set; }

        public float TrueCounter { get; set; }
       
        public Shoe _shoe{ get; set; }
        public ACounter(Shoe shoe)
        {
            _shoe = shoe;
        }

        public abstract int CalulateIncrement(string cardFace);

        public void UpdateCounters(string cardFace)
        {
            var RemainingDecks = (float)_shoe.cards.Count / (float)Costanti.N_CARTE_MAZZO;
            RunningCounter += CalulateIncrement(cardFace);
            TrueCounter = ((float)RunningCounter / RemainingDecks);
          
        }
    }
}
