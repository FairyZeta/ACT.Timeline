using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FairyZeta.Core.Process
{
    /// <summary> FairyZeta／double型用の四捨五入プロセス
    /// </summary>
    public class DoubleToAdjustProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FairyZeta／double型用の四捨五入プロセス／コンストラクタ
        /// </summary>
        public DoubleToAdjustProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> double型(Null可能)を指定した精度の数値に四捨五入します。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に四捨五入された数値。</returns>
        public Nullable<double> ToHalfAdjust(Nullable<double> value, int iDigits)
        {
            if (!value.HasValue) return null;

            return this.ToHalfAdjust(value.Value, iDigits);
        }

        /// <summary> double型を指定した精度の数値に四捨五入します。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に四捨五入された数値。</returns>
        public double ToHalfAdjust(double value, int iDigits)
        {
            double dValue = Convert.ToDouble(value);
            double dCoef = System.Math.Pow(10, iDigits);

            double result = dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
                                System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;

            return result;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
