using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／オーバーレイカスタムウィンドウビューモデル
    /// </summary>
    public class OverlayCustomWindowViewModel : _ViewModels
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] OverlayViewComponent.OverlayViewComponent - ＜オーバーレイ表示コンポーネント＞ -----
        /// <summary> オーバーレイ表示コンポーネント </summary>
        private OverlayViewComponent _OverlayViewComponent;
        /// <summary> オーバーレイ表示コンポーネント </summary>
        public OverlayViewComponent OverlayViewComponent
        {
            get { return this._OverlayViewComponent; }
            set
            {
                if (this._OverlayViewComponent == value) return;

                this._OverlayViewComponent = value;
                base.OnPropertyChanged("OverlayViewComponent");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイカスタムウィンドウビューモデル／コンストラクタ
        /// </summary>
        public OverlayCustomWindowViewModel()
            : base()
        {
            this.initViewModel();
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

    }
}
