using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Prism.Commands;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／オーバーレイカスタムウィンドウビューモデル
    /// </summary>
    public class OverlayCustomWindowViewModel : _ViewModel, IDisposable
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

        #region #- [Command] DelegateCommand.CloseEventCommand - ＜ウィンドウ終了イベントコマンド＞ -----
        /// <summary> ウィンドウ終了イベントコマンド＜コマンド＞ </summary>
        private DelegateCommand _CloseEventCommand;
        /// <summary> ウィンドウ終了イベントコマンド＜コマンド＞ </summary>
        public DelegateCommand CloseEventCommand
        {
            get { return _CloseEventCommand = _CloseEventCommand ?? new DelegateCommand(this._CloseEventExecute); }
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

        public void Dispose()
        {
            this.OverlayViewComponent = null;
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Method] CanExecute,Execute @ CloseEventCommand - ＜ウィンドウ終了イベントコマンド＞ -----

        /// <summary> コマンド実行＜ウィンドウ終了イベントコマンド＞ </summary>
        private void _CloseEventExecute()
        {
        }

        #endregion 
    }

    public class PredefinedColor
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
