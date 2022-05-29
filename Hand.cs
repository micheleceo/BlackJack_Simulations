using System.Collections.Generic;

namespace BlackJackSimul
{
    public class Hand
    {
        public Hand(float flatBet=0)
        {
            HL_Bet = flatBet;
            RAPC_Bet = flatBet;
            FlatBet = flatBet;
        }

        public List<string> Cards = new List<string> { };
        public Point punteggio;
        public string Result { get; set; } = "";

        public float FlatBetResult { get; set; } = 0;
        public float FlatBet { get; set; } = 0;

        public float HL_BetResult { get; set; } = 0;
        public float HL_Bet { get; set; } = 0;

        public float RAPC_BetResult { get; set; } = 0;
        public float RAPC_Bet { get; set; } = 0;

        public bool f_double { get; set; } = false;

        public bool f_coppia { get; set; } = false;

        public bool f_bust { get; set; } = false;

        public bool f_splitted{ get; set; } = false;

        public void AddCard(string card)
        {
            Cards.Add(card);
            Analize();
        }

        public void Analize()
        {
            //Azzero il punteggio
            punteggio = new Point();

            //Ordinamento carte con assi alla fine
            List<int> CardValue = new List<int>();
            foreach(string card in Cards)
                CardValue.Add(Util.PointOf(card));
            CardValue.Sort();

            //Controllo se ho una coppia (che non sia già uno split)
            if (CardValue.Count == 2 && CardValue[0] == CardValue[1] && !f_splitted)
                f_coppia = true;
            else
                f_coppia = false;

            //Calcolo del punteggio
            foreach (int value in CardValue)
            {
                punteggio.Value += value;

                //Controllo del punteggio soft
                if(value == 11)
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

    public class Point
    {
       public int Value { get; set; } = 0;
       public bool f_soft { get; set; } = false;

    }
}

