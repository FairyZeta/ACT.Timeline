using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／メインウィンドウビューモデル
    /// </summary>
    public class OverlayWindowViewModel : _ViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] CommonComponent.CommonComponent - ＜共通コンポーネント＞ -----
        /// <summary> 共通コンポーネント </summary>
        private CommonComponent _CommonComponent;
        /// <summary> 共通コンポーネント </summary>
        public CommonComponent CommonComponent
        {
            get { return this._CommonComponent; }
            set
            {
                if (this._CommonComponent == value) return;

                this._CommonComponent = value;
                base.OnPropertyChanged("CommonComponent");
            }
        }
        #endregion

        #region #- [Property] TimelineComponent.TimelineComponent - ＜タイムラインコンポーネント＞ -----
        /// <summary> タイムラインコンポーネント </summary>
        private TimelineComponent _TimelineComponent;
        /// <summary> タイムラインコンポーネント </summary>
        public TimelineComponent TimelineComponent
        {
            get { return this._TimelineComponent; }
            set
            {
                if (this._TimelineComponent == value) return;

                this._TimelineComponent = value;
                base.OnPropertyChanged("TimelineComponent");
            }
        }
        #endregion

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

        /// <summary> タイムライン／メインウィンドウビューモデル／コンストラクタ
        /// </summary>
        public OverlayWindowViewModel()
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
