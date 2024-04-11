using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{
    internal static class CalcService
    {
        /// <summary>
        /// 計算結果を返す
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ope"></param>
        /// <returns></returns>
        internal static decimal Calc(decimal preResult, decimal value, string preOperator)
        {
            if (preOperator.Equals("+"))
            {
                // 足し算
                preResult = preResult + value;
            }
            else if (preOperator.Equals("-"))
            {
                // 引き算
                preResult = preResult - value;
            }
            else if (preOperator.Equals("×"))
            {
                // 掛け算
                preResult = preResult * value;
            }
            else if (preOperator.Equals("÷"))
            {
                // 割り算
                preResult = preResult / value;
            }

            return preResult;

        }
    }
}
