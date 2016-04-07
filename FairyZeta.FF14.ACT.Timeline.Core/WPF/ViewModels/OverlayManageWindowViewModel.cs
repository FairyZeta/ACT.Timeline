using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／オーバーレイ管理ウィンドウビューモデル
    /// </summary>
    public class OverlayManageWindowViewModel : _ViewModels
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

        #region #- [Property] OverlayManageComponent.OverlayViewComponent - ＜オーバーレイ管理コンポーネント＞ -----
        /// <summary> オーバーレイ管理コンポーネント </summary>
        private OverlayManageComponent _OverlayManageComponent;
        /// <summary> オーバーレイ管理コンポーネント </summary>
        public OverlayManageComponent OverlayManageComponent
        {
            get { return this._OverlayManageComponent; }
            set
            {
                if (this._OverlayManageComponent == value) return;

                this._OverlayManageComponent = value;
                base.OnPropertyChanged("OverlayManageComponent");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ管理ウィンドウビューモデル／コンストラクタ
        /// </summary>
        public OverlayManageWindowViewModel()
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
