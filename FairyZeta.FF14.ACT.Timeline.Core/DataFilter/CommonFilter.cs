using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataFilter
{
    /// <summary> タイムライン／汎用フィルタ
    /// </summary>
    public class CommonFilter : _DataFilter
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
    
        /// <summary> タイムライン／汎用フィルタ／コンストラクタ
        /// </summary>
        public CommonFilter()
            : base()
        {
            this.initFilter();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フィルタの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initFilter()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フィルタ表示をリセットします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_Reset(object sender, FilterEventArgs e)
        {
            e.Accepted = true;

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
