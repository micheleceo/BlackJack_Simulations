using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul
{
    /// <summary>
    /// Basic strategy implementation
    /// </summary>
    public class BasicStrategyL
    {
        StrategiesTables.BasicStrategyL_Table strategyTable = new StrategiesTables.BasicStrategyL_Table();  
        
        public string ApplyStrategy(Hand hand,int dealerFirstCardPoint)
        {
            int column = 0;
            int row = 0;

            //Seleziono la colonna
            switch (dealerFirstCardPoint)
            {
                case 2: column = 0; break;
                case 3: column = 1; break;
                case 4: column = 2; break;
                case 5: column = 3; break;
                case 6: column = 4; break;
                case 7: column = 5; break;
                case 8: column = 6; break;
                case 9: column = 7; break;
                case 10: column = 8; break;
                case 11: column = 9; break;
            }

            //Controllo coppia
            if(hand.f_coppia)
            {
                switch (Util.PointOf(hand.Cards[0]))
                {
                    case 2: row = (int)Row.R_C2; break;
                    case 3: row = (int)Row.R_C3; break;
                    case 4: row = (int)Row.R_C4; break;
                    case 5: row = (int)Row.R_C5; break;
                    case 6: row = (int)Row.R_C6; break;
                    case 7: row = (int)Row.R_C7; break;
                    case 8: row = (int)Row.R_C8; break;
                    case 9: row = (int)Row.R_C9; break;
                    case 10: row = (int)Row.R_C10; break;
                    case 11: row = (int)Row.R_CA; break;
                }

                return strategyTable.Response[row, column].ToUpper();

            }

            //Controllo soft
            if (hand.punteggio.f_soft)
            {
                switch (hand.punteggio.Value)
                {
                    case 20: row = (int)Row.R_S20; break;
                    case 19: row = (int)Row.R_S19; break;
                    case 18: row = (int)Row.R_S18; break;
                    case 17: row = (int)Row.R_S17; break;
                    case 16: row = (int)Row.R_S16; break;
                    case 15: row = (int)Row.R_S15; break;
                    case 14: row = (int)Row.R_S14; break;
                    case 13: row = (int)Row.R_S13; break;
                }

                return strategyTable.Response[row, column].ToUpper();
            }


            //Controllo punteggi hard
            switch (hand.punteggio.Value)
            {
                case 21: row = (int)Row.R_H18; break;
                case 20: row = (int)Row.R_H18; break;
                case 19: row = (int)Row.R_H18; break;
                case 18: row = (int)Row.R_H18; break;
                case 17: row = (int)Row.R_H17; break;
                case 16: row = (int)Row.R_H16; break;
                case 15: row = (int)Row.R_H15; break;
                case 14: row = (int)Row.R_H14; break;
                case 13: row = (int)Row.R_H13; break;
                case 12: row = (int)Row.R_H12; break;
                case 11: row = (int)Row.R_H11; break;
                case 10: row = (int)Row.R_H10; break;
                case 9: row = (int)Row.R_H9; break;
                case 8: row = (int)Row.R_H8; break;
                case 7: row = (int)Row.R_H7; break;
                case 6: row = (int)Row.R_H6; break;
                case 5: row = (int)Row.R_H5; break;
            }

            return strategyTable.Response[row, column].ToUpper();
        }

        enum Row
        {
            R_H18,
            R_H17,
            R_H16,
            R_H15,
            R_H14,
            R_H13,
            R_H12,
            R_H11,
            R_H10,
            R_H9,
            R_H8,
            R_H7,
            R_H6,
            R_H5,
            R_S20,
            R_S19,
            R_S18,
            R_S17,
            R_S16,
            R_S15,
            R_S14,
            R_S13,
            R_CA,
            R_C10,
            R_C9,
            R_C8,
            R_C7,
            R_C6,
            R_C5,
            R_C4,
            R_C3,
            R_C2
        }
    }
}