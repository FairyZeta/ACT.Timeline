using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using System.Windows.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／オーバーレイ管理コンポーネント
    /// </summary>
    public class OverlayManageComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインコンポーネント（OverlayView引渡し用）
        /// </summary>
        public TimelineComponent TimelineComponent { get; set; }

        /// <summary> オーバーレイ管理データモデル 
        /// </summary>
        public OverlayManageDataModel OverlayManageDataModel { get; private set; }

        #region #- [Property] OverlayDataModel.AddOverlayDataModel - ＜新規オーバーレイ追加用データモデル ＞ -----
        /// <summary> 新規オーバーレイ追加用データモデル  </summary>
        private OverlayDataModel _AddOverlayDataModel;
        /// <summary> 新規オーバーレイ追加用データモデル  </summary>
        public OverlayDataModel AddOverlayDataModel
        {
            get { return this._AddOverlayDataModel; }
            set
            {
                if (this._AddOverlayDataModel == value) return;

                this._AddOverlayDataModel = value;
                base.OnPropertyChanged("AddOverlayDataModel");
            }
        }
        #endregion

        /// <summary> オーバーレイ管理モジュール
        /// </summary>
        public OverlayManageModule OverlayManageModule { get; private set; }

        #region #- [Command] DelegateCommand.OverlayManageClosedCommand - ＜オーバーレイ管理終了コマンド＞ -----
        /// <summary> オーバーレイ管理終了コマンド＜コマンド＞ </summary>
        private DelegateCommand _OverlayManageClosedCommand;
        /// <summary> オーバーレイ管理終了コマンド＜コマンド＞ </summary>
        public DelegateCommand OverlayManageClosedCommand
        {
            get { return _OverlayManageClosedCommand = _OverlayManageClosedCommand ?? new DelegateCommand(this._OverlayManageClosedExecute); }
        }
        #endregion

        #region #- [Command] DelegateCommand.NewOverlayAppendCommand - ＜新規オーバーレイ作成コマンド＞ -----
        /// <summary> 新規オーバーレイ作成コマンド＜コマンド＞ </summary>
        private DelegateCommand _NewOverlayAppendCommand;
        /// <summary> 新規オーバーレイ作成コマンド＜コマンド＞ </summary>
        public DelegateCommand NewOverlayAppendCommand
        {
            get { return _NewOverlayAppendCommand = _NewOverlayAppendCommand ?? new DelegateCommand(this._NewOverlayAppendExecute, this._CanNewOverlayAppendExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand<bool?>.OverlayAddEnterCommand - ＜新規オーバーレイ追加確定コマンド＞ -----
        /// <summary> 新規オーバーレイ追加確定コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _OverlayAddEnterCommand;
        /// <summary> 新規オーバーレイ追加確定コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> OverlayAddEnterCommand
        {
            get { return _OverlayAddEnterCommand = _OverlayAddEnterCommand ?? new DelegateCommand<string>(this._OverlayAddEnterExecute, this._CanOverlayAddEnterExecute); }
        }
        #endregion 
        
        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayViewCommand - ＜オーバーレイ表示切替コマンド＞ -----
        /// <summary> オーバーレイ表示切替コマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayViewChangedCommand;
        /// <summary> オーバーレイ表示切替コマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayViewChangedCommand
        {
            get { return _OverlayViewChangedCommand = _OverlayViewChangedCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayViewChangedExecute, this._CanOverlayViewChangedExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayViewLockCommand - ＜オーバーレイロック切替コマンド＞ -----
        /// <summary> オーバーレイロック切替コマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayViewLockCommand;
        /// <summary> オーバーレイロック切替コマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayViewLockCommand
        {
            get { return _OverlayViewLockCommand = _OverlayViewLockCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayViewLockExecute, this._CanOverlayViewLockExecute); }
        }
        #endregion
        #region #- [Command] DelegateCommand<OverlayViewComponent>.OvarlayCustomWindoOpenCommand - ＜オーバーレイカスタムウインドウオープンコマンド＞ -----
        /// <summary> オーバーレイカスタムウインドウオープンコマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OvarlayCustomWindoOpenCommand;
        /// <summary> オーバーレイカスタムウインドウオープンコマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OvarlayCustomWindoOpenCommand
        {
            get { return _OvarlayCustomWindoOpenCommand = _OvarlayCustomWindoOpenCommand ?? new DelegateCommand<OverlayViewComponent>(this._OvarlayCustomWindoOpenExecute, this._CanOvarlayCustomWindoOpenExecute); }
        }
        #endregion 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ管理コンポーネント／コンストラクタ
        /// </summary>
        public OverlayManageComponent(TimelineComponent pComponent)
            : base()
        {
            this.TimelineComponent = pComponent;
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.OverlayManageDataModel = new OverlayManageDataModel();
            this.OverlayManageModule = new OverlayManageModule();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] CanExecute,Execute @ OverlayManageClosedCommand - ＜オーバーレイ管理終了コマンド＞ -----
        /// <summary> コマンド実行＜オーバーレイ管理終了コマンド＞ </summary>
        private void _OverlayManageClosedExecute()
        {
            this.OverlayManageDataModel.OverlayManageData.OverlayManageWindowClosed = true;
        }
        #endregion ---------- /

        #region #- [Method] CanExecute,Execute @ NewOverlayAppendCommand - ＜新規オーバーレイ作成コマンド＞ -----
        /// <summary> 実行可能確認＜新規オーバーレイ作成コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanNewOverlayAppendExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜新規オーバーレイ作成コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _NewOverlayAppendExecute()
        {
            // --- 追加用データ生成
            this.AddOverlayDataModel = new OverlayDataModel();
            this.OverlayManageModule.CreateOverlayTypeCollection(this.AddOverlayDataModel);

            // --- モーダルを開く
            this.OverlayManageDataModel.OverlayManageData.NowOverlayAddModalVisibility = true;
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayAddEnterCommand - ＜新規オーバーレイ追加確定コマンド＞ -----
        /// <summary> 実行可能確認＜新規オーバーレイ追加確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayAddEnterExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜新規オーバーレイ追加確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayAddEnterExecute(string para)
        {
            switch (para)
            {
                case "Add":
                    break;
                default:
                    this.OverlayManageDataModel.OverlayManageData.NowOverlayAddModalVisibility = false;
                    return;
            }

            // --- 判定後、追加
            OverlayViewComponent component = new OverlayViewComponent();
            component.OverlayDataModel = this.AddOverlayDataModel;
            this.OverlayManageModule.SetDefaultOverlayWindowData(component.OverlayDataModel.OverlayWindowData);
            this.OverlayManageModule.SetDefaultOverlaySettingData(component.OverlayDataModel.OverlayOptionData);

            component.OverlayDataModel.OverlayViewData.TimelineViewSource = new CollectionViewSource() { Source = this.TimelineComponent.TimelineDataModel.TimelineItemCollection };

            this.OverlayManageDataModel.OverlayViewComponentCollection.Add(component);

            this.OverlayManageModule.ShowOverlay(this.TimelineComponent, component);

            this.OverlayManageDataModel.OverlayManageData.NowOverlayAddModalVisibility = false;
        }
        #endregion 

        #region #- [Method] CanExecute,Execute @ OverlayViewCommand - ＜オーバーレイ表示コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイ表示切替コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayViewChangedExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイ表示切替コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayViewChangedExecute(OverlayViewComponent para)
        {

        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayViewLockCommand - ＜オーバーレイロック切替コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイロック切替コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayViewLockExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイロック切替コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayViewLockExecute(OverlayViewComponent para)
        {
            if (para == null) return;

            if(para.OverlayDataModel.OverlayWindowData.WindowLock)
            {
                WindowsServices.SetWindowExTransparent(para.OverlayDataModel.OverlayWindowData.WindowIntPrt);
            }
            else
            {
                WindowsServices.InitWindowExTransparent(para.OverlayDataModel.OverlayWindowData.WindowIntPrt);
            }
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OvarlayCustomWindoOpenCommand - ＜オーバーレイカスタムウインドウオープンコマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイカスタムウインドウオープンコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOvarlayCustomWindoOpenExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイカスタムウインドウオープンコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OvarlayCustomWindoOpenExecute(OverlayViewComponent para)
        {
            this.OverlayManageModule.ShowCustomWindow(para);
        }
        #endregion 

    }
}
