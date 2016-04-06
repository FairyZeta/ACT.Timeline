using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／新規オーバーレイ追加ビューモデル
    /// </summary>
    public class NewOverlayAddWindowViewModel : _ViewModels
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] OverlayManageComponent.OverlayManageComponent - ＜オーバーレイ管理コンポーネント＞ -----
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

        /// <summary> タイムライン／新規オーバーレイ追加ビューモデル／コンストラクタ
        /// </summary>
        public NewOverlayAddWindowViewModel()
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
            this.OverlayManageComponent = new OverlayManageComponent();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
