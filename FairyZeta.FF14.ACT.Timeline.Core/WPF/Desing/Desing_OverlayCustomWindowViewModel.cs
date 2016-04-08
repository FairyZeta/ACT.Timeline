using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Desing
{
    /// <summary> [画面デザイン用] タイムライン／オーバーレイカスタムウィンドウビューモデル
    /// </summary>
    public class Desing_OverlayCustomWindowViewModel : OverlayCustomWindowViewModel
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [画面デザイン用] タイムライン／オーバーレイカスタムウィンドウビューモデル／コンストラクタ
        /// </summary>
        public Desing_OverlayCustomWindowViewModel()
            : base()
        {
            this.initViewModel();
            this.createDesingData_P001();
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デザイン用データ（パターン１）の生成
        /// </summary>
        private void createDesingData_P001()
        {

        }
    }
}
