using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FairyZeta.Framework.WPF.Controls
{
    /// <summary> FZ／マルチラインボーダー
    /// </summary>
    public class MultiLineBorder : Border
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／マルチラインボーダー／コンストラクタ
        /// </summary>
        public MultiLineBorder()
        {
            this.initControl();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コントロールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initControl()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
