using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSimul.StrategiesTables
{
    public class BasicStrategyL_Table
    {
        //basic strategy table in two dimensional array
        public string[,] Response = new string[32, 10];

     

        public BasicStrategyL_Table()
        {
            //18+
            Response[0, 0] = "STAND";
            Response[0, 1] = "STAND";
            Response[0, 2] = "STAND";
            Response[0, 3] = "STAND";
            Response[0, 4] = "STAND";
            Response[0, 5] = "STAND";
            Response[0, 6] = "STAND";
            Response[0, 7] = "STAND";
            Response[0, 8] = "STAND";
            Response[0, 9] = "STAND";

            //17
            Response[1, 1] = "STAND";
            Response[1, 2] = "STAND";
            Response[1, 3] = "STAND";
            Response[1, 4] = "STAND";
            Response[1, 5] = "STAND";
            Response[1, 6] = "STAND";
            Response[1, 0] = "STAND";
            Response[1, 7] = "STAND";
            Response[1, 8] = "STAND";
            Response[1, 9] = "STAND";

            //16
            Response[2, 0] = "STAND";
            Response[2, 1] = "STAND";
            Response[2, 2] = "STAND";
            Response[2, 3] = "STAND";
            Response[2, 4] = "STAND";
            Response[2, 5] = "HIT";
            Response[2, 6] = "HIT";
            Response[2, 7] = "HIT";
            Response[2, 8] = "HIT";
            Response[2, 9] = "HIT";

            //15
            Response[3, 0] = "STAND";
            Response[3, 1] = "STAND";
            Response[3, 2] = "STAND";
            Response[3, 3] = "STAND";
            Response[3, 4] = "STAND";
            Response[3, 5] = "HIT";
            Response[3, 6] = "HIT";
            Response[3, 7] = "HIT";
            Response[3, 8] = "HIT";
            Response[3, 9] = "HIT";

            //14
            Response[4, 0] = "STAND";
            Response[4, 1] = "STAND";
            Response[4, 2] = "STAND";
            Response[4, 3] = "STAND";
            Response[4, 4] = "STAND";
            Response[4, 5] = "HIT";
            Response[4, 6] = "HIT";
            Response[4, 7] = "HIT";
            Response[4, 8] = "HIT";
            Response[4, 9] = "HIT";

            //13
            Response[5, 0] = "STAND";
            Response[5, 1] = "STAND";
            Response[5, 2] = "STAND";
            Response[5, 3] = "STAND";
            Response[5, 4] = "STAND";
            Response[5, 5] = "HIT";
            Response[5, 6] = "HIT";
            Response[5, 7] = "HIT";
            Response[5, 8] = "HIT";
            Response[5, 9] = "HIT";

            //12
            Response[6, 0] = "HIT";
            Response[6, 1] = "HIT";
            Response[6, 2] = "STAND";
            Response[6, 3] = "STAND";
            Response[6, 4] = "STAND";
            Response[6, 5] = "HIT";
            Response[6, 6] = "HIT";
            Response[6, 7] = "HIT";
            Response[6, 8] = "HIT";
            Response[6, 9] = "HIT";

            //11
            Response[7, 0] = "DOUBLE DOWN";
            Response[7, 1] = "DOUBLE DOWN";
            Response[7, 2] = "DOUBLE DOWN";
            Response[7, 3] = "DOUBLE DOWN";
            Response[7, 4] = "DOUBLE DOWN";
            Response[7, 5] = "DOUBLE DOWN";
            Response[7, 6] = "DOUBLE DOWN";
            Response[7, 7] = "DOUBLE DOWN";
            Response[7, 8] = "DOUBLE DOWN";
            Response[7, 9] = "HIT";

            //10
            Response[8, 0] = "DOUBLE DOWN";
            Response[8, 1] = "DOUBLE DOWN";
            Response[8, 2] = "DOUBLE DOWN";
            Response[8, 3] = "DOUBLE DOWN";
            Response[8, 4] = "DOUBLE DOWN";
            Response[8, 5] = "DOUBLE DOWN";
            Response[8, 6] = "DOUBLE DOWN";
            Response[8, 7] = "DOUBLE DOWN";
            Response[8, 8] = "HIT";
            Response[8, 9] = "HIT";

            //9
            Response[9, 0] = "HIT";
            Response[9, 1] = "DOUBLE DOWN";
            Response[9, 2] = "DOUBLE DOWN";
            Response[9, 3] = "DOUBLE DOWN";
            Response[9, 4] = "DOUBLE DOWN";
            Response[9, 5] = "HIT";
            Response[9, 6] = "HIT";
            Response[9, 7] = "HIT";
            Response[9, 8] = "HIT";
            Response[9, 9] = "HIT";

            //8
            Response[10, 0] = "HIT";
            Response[10, 1] = "HIT";
            Response[10, 2] = "HIT";
            Response[10, 3] = "HIT";
            Response[10, 4] = "HIT";
            Response[10, 5] = "HIT";
            Response[10, 6] = "HIT";
            Response[10, 7] = "HIT";
            Response[10, 8] = "HIT";
            Response[10, 9] = "HIT";

            //7
            Response[11, 0] = "HIT";
            Response[11, 1] = "HIT";
            Response[11, 2] = "HIT";
            Response[11, 3] = "HIT";
            Response[11, 4] = "HIT";
            Response[11, 5] = "HIT";
            Response[11, 6] = "HIT";
            Response[11, 7] = "HIT";
            Response[11, 8] = "HIT";
            Response[11, 9] = "HIT";

            //6
            Response[12, 0] = "HIT";
            Response[12, 1] = "HIT";
            Response[12, 2] = "HIT";
            Response[12, 3] = "HIT";
            Response[12, 4] = "HIT";
            Response[12, 5] = "HIT";
            Response[12, 6] = "HIT";
            Response[12, 7] = "HIT";
            Response[12, 8] = "HIT";
            Response[12, 9] = "HIT";

            //5
            Response[13, 0] = "HIT";
            Response[13, 1] = "HIT";
            Response[13, 2] = "HIT";
            Response[13, 3] = "HIT";
            Response[13, 4] = "HIT";
            Response[13, 5] = "HIT";
            Response[13, 6] = "HIT";
            Response[13, 7] = "HIT";
            Response[13, 8] = "HIT";
            Response[13, 9] = "HIT";

            //Soft20
            Response[14, 0] = "STAND";
            Response[14, 1] = "STAND";
            Response[14, 2] = "STAND";
            Response[14, 3] = "STAND";
            Response[14, 4] = "STAND";
            Response[14, 5] = "STAND";
            Response[14, 6] = "STAND";
            Response[14, 7] = "STAND";
            Response[14, 8] = "STAND";
            Response[14, 9] = "STAND";

            //Soft19
            Response[15, 0] = "STAND";
            Response[15, 1] = "STAND";
            Response[15, 2] = "STAND";
            Response[15, 3] = "STAND";
            Response[15, 4] = "STAND";
            Response[15, 5] = "STAND";
            Response[15, 6] = "STAND";
            Response[15, 7] = "STAND";
            Response[15, 8] = "STAND";
            Response[15, 9] = "STAND";

            //Soft18
            Response[16, 0] = "STAND";
            Response[16, 1] = "DOUBLE DOWN";
            Response[16, 2] = "DOUBLE DOWN";
            Response[16, 3] = "DOUBLE DOWN";
            Response[16, 4] = "DOUBLE DOWN";
            Response[16, 5] = "STAND";
            Response[16, 6] = "STAND";
            Response[16, 7] = "HIT";
            Response[16, 8] = "HIT";
            Response[16, 9] = "HIT";

            //Soft17
            Response[17, 0] = "HIT";
            Response[17, 1] = "DOUBLE DOWN";
            Response[17, 2] = "DOUBLE DOWN";
            Response[17, 3] = "DOUBLE DOWN";
            Response[17, 4] = "DOUBLE DOWN";
            Response[17, 5] = "HIT";
            Response[17, 6] = "HIT";
            Response[17, 7] = "HIT";
            Response[17, 8] = "HIT";
            Response[17, 9] = "HIT";

            //Soft16
            Response[18, 0] = "HIT";
            Response[18, 1] = "HIT";
            Response[18, 2] = "DOUBLE DOWN";
            Response[18, 3] = "DOUBLE DOWN";
            Response[18, 4] = "DOUBLE DOWN";
            Response[18, 5] = "HIT";
            Response[18, 6] = "HIT";
            Response[18, 7] = "HIT";
            Response[18, 8] = "HIT";
            Response[18, 9] = "HIT";

            //Soft15
            Response[19, 0] = "HIT";
            Response[19, 1] = "HIT";
            Response[19, 2] = "DOUBLE DOWN";
            Response[19, 3] = "DOUBLE DOWN";
            Response[19, 4] = "DOUBLE DOWN";
            Response[19, 5] = "HIT";
            Response[19, 6] = "HIT";
            Response[19, 7] = "HIT";
            Response[19, 8] = "HIT";
            Response[19, 9] = "HIT";

            //Soft14
            Response[20, 0] = "HIT";
            Response[20, 1] = "HIT";
            Response[20, 2] = "HIT";
            Response[20, 3] = "DOUBLE DOWN";
            Response[20, 4] = "DOUBLE DOWN";
            Response[20, 5] = "HIT";
            Response[20, 6] = "HIT";
            Response[20, 7] = "HIT";
            Response[20, 8] = "HIT";
            Response[20, 9] = "HIT";

            //Soft13
            Response[21, 0] = "HIT";
            Response[21, 1] = "HIT";
            Response[21, 2] = "HIT";
            Response[21, 3] = "DOUBLE DOWN";
            Response[21, 4] = "DOUBLE DOWN";
            Response[21, 5] = "HIT";
            Response[21, 6] = "HIT";
            Response[21, 7] = "HIT";
            Response[21, 8] = "HIT";
            Response[21, 9] = "HIT";

            //CoppiaA
            Response[22, 0] = "SPLIT";
            Response[22, 1] = "SPLIT";
            Response[22, 2] = "SPLIT";
            Response[22, 3] = "SPLIT";
            Response[22, 4] = "SPLIT";
            Response[22, 5] = "SPLIT";
            Response[22, 6] = "SPLIT";
            Response[22, 7] = "SPLIT";
            Response[22, 8] = "SPLIT";
            Response[22, 9] = "SPLIT";

            //Coppia10
            Response[23, 0] = "STAND";
            Response[23, 1] = "STAND";
            Response[23, 2] = "STAND";
            Response[23, 3] = "STAND";
            Response[23, 4] = "STAND";
            Response[23, 5] = "STAND";
            Response[23, 6] = "STAND";
            Response[23, 7] = "STAND";
            Response[23, 8] = "STAND";
            Response[23, 9] = "STAND";

            //Coppia9
            Response[24, 0] = "SPLIT";
            Response[24, 1] = "SPLIT";
            Response[24, 2] = "SPLIT";
            Response[24, 3] = "SPLIT";
            Response[24, 4] = "SPLIT";
            Response[24, 5] = "STAND";
            Response[24, 6] = "SPLIT";
            Response[24, 7] = "SPLIT";
            Response[24, 8] = "STAND";
            Response[24, 9] = "STAND";

            //Coppia8
            Response[25, 0] = "SPLIT";
            Response[25, 1] = "SPLIT";
            Response[25, 2] = "SPLIT";
            Response[25, 3] = "SPLIT";
            Response[25, 4] = "SPLIT";
            Response[25, 5] = "SPLIT";
            Response[25, 6] = "SPLIT";
            Response[25, 7] = "SPLIT";
            Response[25, 8] = "SPLIT";
            Response[25, 9] = "SPLIT";

            //Coppia7
            Response[26, 0] = "SPLIT";
            Response[26, 1] = "SPLIT";
            Response[26, 2] = "SPLIT";
            Response[26, 3] = "SPLIT";
            Response[26, 4] = "SPLIT";
            Response[26, 5] = "SPLIT";
            Response[26, 6] = "HIT";
            Response[26, 7] = "HIT";
            Response[26, 8] = "HIT";
            Response[26, 9] = "HIT";

            //Coppia6
            Response[27, 0] = "SPLIT";
            Response[27, 1] = "SPLIT";
            Response[27, 2] = "SPLIT";
            Response[27, 3] = "SPLIT";
            Response[27, 4] = "SPLIT";
            Response[27, 5] = "HIT";
            Response[27, 6] = "HIT";
            Response[27, 7] = "HIT";
            Response[27, 8] = "HIT";
            Response[27, 9] = "HIT";

            //Coppia5
            Response[28, 0] = "DOUBLE DOWN";
            Response[28, 2] = "DOUBLE DOWN";
            Response[28, 3] = "DOUBLE DOWN";
            Response[28, 4] = "DOUBLE DOWN";
            Response[28, 1] = "DOUBLE DOWN";
            Response[28, 5] = "DOUBLE DOWN";
            Response[28, 6] = "DOUBLE DOWN";
            Response[28, 7] = "DOUBLE DOWN";
            Response[28, 8] = "HIT";
            Response[28, 9] = "HIT";

            //Coppia4
            Response[29, 0] = "HIT";
            Response[29, 1] = "HIT";
            Response[29, 2] = "HIT";
            Response[29, 3] = "SPLIT";
            Response[29, 4] = "SPLIT";
            Response[29, 5] = "HIT";
            Response[29, 6] = "HIT";
            Response[29, 7] = "HIT";
            Response[29, 8] = "HIT";
            Response[29, 9] = "HIT";

            //Coppia3
            Response[30, 0] = "SPLIT";
            Response[30, 1] = "SPLIT";
            Response[30, 2] = "SPLIT";
            Response[30, 3] = "SPLIT";
            Response[30, 4] = "SPLIT";
            Response[30, 5] = "SPLIT";
            Response[30, 6] = "HIT";
            Response[30, 7] = "HIT";
            Response[30, 8] = "HIT";
            Response[30, 9] = "HIT";

            //Coppia2
            Response[31, 0] = "SPLIT";
            Response[31, 1] = "SPLIT";
            Response[31, 2] = "SPLIT";
            Response[31, 3] = "SPLIT";
            Response[31, 4] = "SPLIT";
            Response[31, 5] = "SPLIT";
            Response[31, 6] = "HIT";
            Response[31, 7] = "HIT";
            Response[31, 8] = "HIT";
            Response[31, 9] = "HIT";

        }
    }
}
