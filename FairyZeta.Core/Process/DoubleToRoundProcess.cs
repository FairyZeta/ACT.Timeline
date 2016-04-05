using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FairyZeta.Core.Process
{
    /// <summary> FairyZeta／double型用の切りｘｘプロセス
    /// </summary>
    public class DoubleToRoundProcess
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FairyZeta／Double型用の切りｘｘプロセス／コンストラクタ
        /// </summary>
        public DoubleToRoundProcess()
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

        /// <summary> double型(Null可能)を指定した精度の数値に切り上げします。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に切り上げられた数値。</returns>
        public Nullable<double> ToRoundUp(Nullable<double> value, int iDigits)
        {
            if (!value.HasValue) return null;

            return this.ToRoundUp(value.Value, iDigits);
        }

        /// <summary> double型を指定した精度の数値に切り上げします。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に切り上げられた数値。</returns>
        public double ToRoundUp(double value, int iDigits)
        {
            double dValue = value;
            double dCoef = System.Math.Pow(10, iDigits);

            double result = dValue > 0 ? System.Math.Ceiling(dValue * dCoef) / dCoef :
                                System.Math.Floor(dValue * dCoef) / dCoef;

            return result;
        }

        /// <summary> double型(Null可能)を指定した精度の数値に切り上げします。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に切り上げられた数値。</returns>
        public Nullable<double> ToRoundDown(Nullable<double> value, int iDigits)
        {
            if (!value.HasValue) return null;

            return this.ToRoundDown(value.Value, iDigits);
        }

        /// <summary> double型を指定した精度の数値に切り捨てします。
        /// </summary>
        /// <param name="value">丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">戻り値の有効桁数の精度。</param>
        /// <returns>iDigits に等しい精度の数値に切り捨てられた数値。</returns>
        public double ToRoundDown(double value, int iDigits)
        {
            double dValue = value;
            double dCoef = System.Math.Pow(10, iDigits);

            double result = dValue > 0 ? System.Math.Floor(dValue * dCoef) / dCoef :
                                System.Math.Ceiling(dValue * dCoef) / dCoef;

            return result;
        }



      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
