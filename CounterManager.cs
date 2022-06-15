using BlackJackSimul.CountingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public class CountersManager
    {
        public Shoe Shoe;

        public HL_Counter hl_counter  { get; set; }

        public RAPC_Counter rapc_counter  { get; set; }

        public int AceCounter { get; set; }

        public int TenCounter { get; set; }

        public float TenIndex
        {
            get { return (Configs.ShoeDeckTotalNumber * 52 - 3.25f * TenCounter) / (float)Shoe.RemaningCards; }
        }

        public float AcenIndex
        {
            get { return ( Configs.ShoeDeckTotalNumber * 52 - 13 * AceCounter) / (float)Shoe.RemaningCards; }
        }


        public CountersManager(Shoe shoe)
        {
            Shoe = shoe;
            hl_counter = new HL_Counter(shoe);
            rapc_counter = new RAPC_Counter(shoe);
        }

        public void UpdateAllCounters(string cardFace)
        {
            UpdateMainCounters(cardFace);
            UpdateSideCounters(cardFace);
        }

        private void UpdateMainCounters(string cardFace)
        {
            hl_counter.UpdateCounters(cardFace);
            rapc_counter.UpdateCounters(cardFace);
        }

        private void UpdateSideCounters(string cardFace)
        {
            switch (cardFace)
            {
                case "A":
                    {
                        AceCounter++;
                        break;
                    }

                case "10":
                case "J":
                case "Q":
                case "K":
                    {
                        TenCounter++;
                        break;
                    }

                default:
                    break;
            }
        }

        internal void SetCountersBets(Hand hand)
        {
            hand.HL_Bet = hl_counter.CalculateBet(hand.FlatBet);
            hand.RAPC_Bet = rapc_counter.CalculateBet(hand.FlatBet);
        }

    }//end of class
}//end of namespace
