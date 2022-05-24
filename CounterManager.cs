﻿using BlackJackSimul.CountingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    public class CountersManager
    {
        public HL_Counter hl_counter  { get; set; }

        public RAPC_Counter rapc_counter  { get; set; }

        public int AceCounter { get; set; }

        public int TenCounter { get; set; }

        public CountersManager(Shoe shoe)
        {
            hl_counter = new HL_Counter(shoe);
            rapc_counter = new RAPC_Counter(shoe);
        }

        public void UpdateSideCounters(string cardValue)
        {
            switch (cardValue)
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
                    // code block
                    break;
            }

        }

        public void UpdateMainCounters(string cardValue)
        {
            hl_counter.UpdateMainCounters(cardValue);
            rapc_counter.UpdateMainCounters(cardValue);
        }

        public void UpdateAllCounters(string cardValue)
        {
            UpdateMainCounters(cardValue);
            UpdateSideCounters(cardValue);
        }
    }
}