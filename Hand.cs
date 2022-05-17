using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public class Hand
    {
        public List<string> Cards = new List<string> { };
        public Punteggio punteggio;
        public string Result { get; set; } = "";

        public float BetResult { get; set; } = 0;
        public float Puntata { get; set; } = 1;

        public bool f_double { get; set; } = false;

        public bool f_coppia { get; set; } = false;

        public bool f_bust { get; set; } = false;

        public bool f_split { get; set; } = false;

        public void AddCard(string card)
        {
            Cards.Add(card);
            Analize();
        }

        public void Analize()
        {
            //Azzero il punteggio
            punteggio = new Punteggio();

            //Ordinamento carte con assi alla fine
            List<int> CardValue = new List<int>();
            foreach(string card in Cards)
                CardValue.Add(Util.PointOf(card));
            CardValue.Sort();

            //Controllo se ho una coppia (che non sia già uno split)
            if (CardValue.Count == 2 && CardValue[0] == CardValue[1] && !f_split)
                f_coppia = true;
            else
                f_coppia = false;

            //Calcolo del punteggio
            foreach (int value in CardValue)
            {
                punteggio.Value += value;

                //Controllo del punteggio soft
                if(value ==11)
                {
                    if (punteggio.Value > 21)
                        punteggio.Value -= 10;
                    else
                        punteggio.f_soft = true;

                }
                else if(punteggio.Value > 21)
                    f_bust = true;
            }

        }
    }

    public class Punteggio
    {
       public int Value { get; set; } = 0;
       public bool f_soft { get; set; } = false;

    }
}

