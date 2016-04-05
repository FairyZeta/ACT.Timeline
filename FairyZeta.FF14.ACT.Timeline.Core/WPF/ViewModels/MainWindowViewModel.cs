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
    public class MainWindowViewModel : _ViewModels
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

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／メインウィンドウビューモデル／コンストラクタ
        /// </summary>
        public MainWindowViewModel()
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
