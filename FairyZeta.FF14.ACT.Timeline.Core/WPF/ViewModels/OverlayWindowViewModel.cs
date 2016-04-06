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
    public class OverlayWindowViewModel : _ViewModels
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

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

        #region #- [Property] ViewControlComponent.ViewControlComponent - ＜ビューコントロールコンポーネント＞ -----
        /// <summary> ビューコントロールコンポーネント </summary>
        private OverlayViewComponent _ViewControlComponent;
        /// <summary> ビューコントロールコンポーネント </summary>
        public OverlayViewComponent ViewControlComponent
        {
            get { return this._ViewControlComponent; }
            set
            {
                if (this._ViewControlComponent == value) return;

                this._ViewControlComponent = value;
                base.OnPropertyChanged("ViewControlComponent");
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
