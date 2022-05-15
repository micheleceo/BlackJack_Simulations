using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.StrategiesTables
{
    public class BasicStrategyAnt_Table
    {
        //basic strategy table in two dimensional array
        public string[,] Table = new string[24, 11];
        public BasicStrategyAnt_Table()
        {
            // somma 8
            Table[0, 0] = "HIT";
            Table[0, 1] = "HIT";
            Table[0, 2] = "HIT";
            Table[0, 3] = "HIT";
            Table[0, 4] = "HIT";
            Table[0, 5] = "HIT";
            Table[0, 6] = "HIT";
            Table[0, 7] = "HIT";
            Table[0, 8] = "HIT";
            Table[0, 9] = "HIT";

            // somma 9
            Table[1, 0] = "HIT";
            Table[1, 1] = "DOUBLE DOWN";
            Table[1, 2] = "DOUBLE DOWN";
            Table[1, 3] = "DOUBLE DOWN";
            Table[1, 4] = "DOUBLE DOWN";
            Table[1, 5] = "HIT";
            Table[1, 6] = "HIT";
            Table[1, 7] = "HIT";
            Table[1, 8] = "HIT";
            Table[1, 9] = "HIT";

            //somma 10
            Table[2, 0] = "DOUBLE DOWN";
            Table[2, 1] = "DOUBLE DOWN";
            Table[2, 2] = "DOUBLE DOWN";
            Table[2, 3] = "DOUBLE DOWN";
            Table[2, 4] = "DOUBLE DOWN";
            Table[2, 5] = "DOUBLE DOWN";
            Table[2, 6] = "DOUBLE DOWN";
            Table[2, 7] = "DOUBLE DOWN";
            Table[2, 8] = "HIT";
            Table[2, 9] = "HIT";

            //somma 11
            Table[3, 0] = "DOUBLE DOWN";
            Table[3, 1] = "DOUBLE DOWN";
            Table[3, 2] = "DOUBLE DOWN";
            Table[3, 3] = "DOUBLE DOWN";
            Table[3, 4] = "DOUBLE DOWN";
            Table[3, 5] = "DOUBLE DOWN";
            Table[3, 6] = "DOUBLE DOWN";
            Table[3, 7] = "DOUBLE DOWN";
            Table[3, 8] = "DOUBLE DOWN";
            Table[3, 9] = "DOUBLE DOWN";

            //somma 12
            Table[4, 0] = "HIT";
            Table[4, 1] = "HIT";
            Table[4, 2] = "STAND";
            Table[4, 3] = "STAND";
            Table[4, 4] = "STAND";
            Table[4, 5] = "HIT";
            Table[4, 6] = "HIT";
            Table[4, 7] = "HIT";
            Table[4, 8] = "HIT";
            Table[4, 9] = "HIT";

            //somma 13
            Table[5, 0] = "STAND";
            Table[5, 1] = "STAND";
            Table[5, 2] = "STAND";
            Table[5, 3] = "STAND";
            Table[5, 4] = "STAND";
            Table[5, 5] = "HIT";
            Table[5, 6] = "HIT";
            Table[5, 7] = "HIT";
            Table[5, 8] = "HIT";
            Table[5, 9] = "HIT";

            //somma 14
            Table[6, 0] = "STAND";
            Table[6, 1] = "STAND";
            Table[6, 2] = "STAND";
            Table[6, 3] = "STAND";
            Table[6, 4] = "STAND";
            Table[6, 5] = "HIT";
            Table[6, 6] = "HIT";
            Table[6, 7] = "HIT";
            Table[6, 8] = "HIT";
            Table[6, 9] = "HIT";

            //somma 15
            Table[7, 0] = "STAND";
            Table[7, 1] = "STAND";
            Table[7, 2] = "STAND";
            Table[7, 3] = "STAND";
            Table[7, 4] = "STAND";
            Table[7, 5] = "HIT";
            Table[7, 6] = "HIT";
            Table[7, 7] = "HIT";
            Table[7, 8] = "HIT";
            Table[7, 9] = "HIT";

            //somma 16
            Table[8, 0] = "STAND";
            Table[8, 1] = "STAND";
            Table[8, 2] = "STAND";
            Table[8, 3] = "STAND";
            Table[8, 4] = "STAND";
            Table[8, 5] = "HIT";
            Table[8, 6] = "HIT";
            Table[8, 7] = "HIT";
            Table[8, 8] = "HIT";
            Table[8, 9] = "HIT";

            //somma 17
            Table[9, 0] = "STAND";
            Table[9, 1] = "STAND";
            Table[9, 2] = "STAND";
            Table[9, 3] = "STAND";
            Table[9, 4] = "STAND";
            Table[9, 5] = "STAND";
            Table[9, 6] = "STAND";
            Table[9, 7] = "STAND";
            Table[9, 8] = "STAND";
            Table[9, 9] = "STAND";

            //soft A-2
            Table[10, 0] = "HIT";
            Table[10, 1] = "HIT";
            Table[10, 2] = "HIT";
            Table[10, 3] = "DOUBLE DOWN";
            Table[10, 4] = "DOUBLE DOWN";
            Table[10, 5] = "HIT";
            Table[10, 6] = "HIT";
            Table[10, 7] = "HIT";
            Table[10, 8] = "HIT";
            Table[10, 9] = "HIT";

            //soft A-3
            Table[11, 0] = "HIT";
            Table[11, 1] = "HIT";
            Table[11, 2] = "HIT";
            Table[11, 3] = "DOUBLE DOWN";
            Table[11, 4] = "DOUBLE DOWN";
            Table[11, 5] = "HIT";
            Table[11, 6] = "HIT";
            Table[11, 7] = "HIT";
            Table[11, 8] = "HIT";
            Table[11, 9] = "HIT";

            //soft A-4
            Table[12, 0] = "HIT";
            Table[12, 1] = "HIT";
            Table[12, 2] = "DOUBLE DOWN";
            Table[12, 3] = "DOUBLE DOWN";
            Table[12, 4] = "DOUBLE DOWN";
            Table[12, 5] = "HIT";
            Table[12, 6] = "HIT";
            Table[12, 7] = "HIT";
            Table[12, 8] = "HIT";
            Table[12, 9] = "HIT";

            //soft A-5
            Table[13, 0] = "HIT";
            Table[13, 1] = "HIT";
            Table[13, 2] = "DOUBLE DOWN";
            Table[13, 3] = "DOUBLE DOWN";
            Table[13, 4] = "DOUBLE DOWN";
            Table[13, 5] = "HIT";
            Table[13, 6] = "HIT";
            Table[13, 7] = "HIT";
            Table[13, 8] = "HIT";
            Table[13, 9] = "HIT";

            //soft A-6
            Table[14, 0] = "HIT";
            Table[14, 1] = "DOUBLE DOWN";
            Table[14, 2] = "DOUBLE DOWN";
            Table[14, 3] = "DOUBLE DOWN";
            Table[14, 4] = "DOUBLE DOWN";
            Table[14, 5] = "HIT";
            Table[14, 6] = "HIT";
            Table[14, 7] = "HIT";
            Table[14, 8] = "HIT";
            Table[14, 9] = "HIT";

            //soft A-7
            Table[15, 0] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[15, 1] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[15, 2] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[15, 3] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[15, 4] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[15, 5] = "STAND";
            Table[15, 6] = "STAND";
            Table[15, 7] = "HIT";
            Table[15, 8] = "HIT";
            Table[15, 9] = "HIT";

            //soft A-8
            Table[16, 0] = "STAND";
            Table[16, 1] = "STAND";
            Table[16, 2] = "STAND";
            Table[16, 3] = "STAND";
            Table[16, 4] = "IF POSSIBLE DOUBLE DOWN ELSE STAND";
            Table[16, 5] = "STAND";
            Table[16, 6] = "STAND";
            Table[16, 7] = "STAND";
            Table[16, 8] = "STAND";
            Table[16, 9] = "STAND";

            //soft A-9
            Table[17, 0] = "STAND";
            Table[17, 1] = "STAND";
            Table[17, 2] = "STAND";
            Table[17, 3] = "STAND";
            Table[17, 4] = "STAND";
            Table[17, 5] = "STAND";
            Table[17, 6] = "STAND";
            Table[17, 7] = "STAND";
            Table[17, 8] = "STAND";
            Table[17, 9] = "STAND";

            //coppia 2
            Table[18, 0] = "SPLIT";
            Table[18, 1] = "SPLIT";
            Table[18, 2] = "SPLIT";
            Table[18, 3] = "SPLIT";
            Table[18, 4] = "SPLIT";
            Table[18, 5] = "SPLIT";
            Table[18, 6] = "HIT";
            Table[18, 7] = "HIT";
            Table[18, 8] = "HIT";
            Table[18, 9] = "HIT";

            //coppia 3
            Table[19, 0] = "SPLIT";
            Table[19, 1] = "SPLIT";
            Table[19, 2] = "SPLIT";
            Table[19, 3] = "SPLIT";
            Table[19, 4] = "SPLIT";
            Table[19, 5] = "SPLIT";
            Table[19, 6] = "HIT";
            Table[19, 7] = "HIT";
            Table[19, 8] = "HIT";
            Table[19, 9] = "HIT";

            //coppia 4
            Table[20, 0] = "HIT";
            Table[20, 1] = "HIT";
            Table[20, 2] = "HIT";
            Table[20, 3] = "SPLIT";
            Table[20, 4] = "SPLIT";
            Table[20, 5] = "HIT";
            Table[20, 6] = "HIT";
            Table[20, 7] = "HIT";
            Table[20, 8] = "HIT";
            Table[20, 9] = "HIT";

            //coppia 5
            Table[21, 0] = "DOUBLE DOWN";
            Table[21, 1] = "DOUBLE DOWN";
            Table[21, 2] = "DOUBLE DOWN";
            Table[21, 3] = "DOUBLE DOWN";
            Table[21, 4] = "DOUBLE DOWN";
            Table[21, 5] = "DOUBLE DOWN";
            Table[21, 6] = "DOUBLE DOWN";
            Table[21, 7] = "DOUBLE DOWN";
            Table[21, 8] = "HIT";
            Table[21, 9] = "HIT";

            //coppia 6
            Table[23, 0] = "SPLIT";
            Table[23, 1] = "SPLIT";
            Table[23, 2] = "SPLIT";
            Table[23, 3] = "SPLIT";
            Table[23, 4] = "SPLIT";
            Table[23, 5] = "HIT";
            Table[23, 6] = "HIT";
            Table[23, 7] = "HIT";
            Table[23, 8] = "HIT";
            Table[23, 9] = "HIT";

            //coppia 7
            Table[24, 0] = "SPLIT";
            Table[24, 1] = "SPLIT";
            Table[24, 2] = "SPLIT";
            Table[24, 3] = "SPLIT";
            Table[24, 4] = "SPLIT";
            Table[24, 5] = "SPLIT";
            Table[24, 6] = "HIT";
            Table[24, 7] = "HIT";
            Table[24, 8] = "HIT";
            Table[24, 9] = "HIT";

            //coppia 8
            Table[25, 0] = "SPLIT";
            Table[25, 1] = "SPLIT";
            Table[25, 2] = "SPLIT";
            Table[25, 3] = "SPLIT";
            Table[25, 4] = "SPLIT";
            Table[25, 5] = "SPLIT";
            Table[25, 6] = "SPLIT";
            Table[25, 7] = "SPLIT";
            Table[25, 8] = "SPLIT";
            Table[25, 9] = "SPLIT";

            //coppia 9
            Table[25, 0] = "SPLIT";
            Table[25, 1] = "SPLIT";
            Table[25, 2] = "SPLIT";
            Table[25, 3] = "SPLIT";
            Table[25, 4] = "SPLIT";
            Table[25, 5] = "STAND";
            Table[25, 6] = "SPLIT";
            Table[25, 7] = "SPLIT";
            Table[25, 8] = "STAND";
            Table[25, 9] = "STAND";

            //coppia 10
            Table[26, 0] = "STAND";
            Table[26, 1] = "STAND";
            Table[26, 2] = "STAND";
            Table[26, 3] = "STAND";
            Table[26, 4] = "STAND";
            Table[26, 5] = "STAND";
            Table[26, 6] = "STAND";
            Table[26, 7] = "STAND";
            Table[26, 8] = "STAND";
            Table[26, 9] = "STAND";

            //coppia A
            Table[27, 0] = "SPLIT";
            Table[27, 1] = "SPLIT";
            Table[27, 2] = "SPLIT";
            Table[27, 3] = "SPLIT";
            Table[27, 4] = "SPLIT";
            Table[27, 5] = "SPLIT";
            Table[27, 6] = "SPLIT";
            Table[27, 7] = "SPLIT";
            Table[27, 8] = "SPLIT";
            Table[27, 9] = "SPLIT";
        }
    }
}
