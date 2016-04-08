using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        #region #- [Property] OverlayDataModel.AddOverlayDataModel - ＜オーバーレイ操作用データモデル＞ -----
        /// <summary> オーバーレイ操作用データモデル  </summary>
        private OverlayDataModel _ControlOverlayDataModel;
        /// <summary> オーバーレイ操作用データモデル  </summary>
        public OverlayDataModel ControlOverlayDataModel
        {
            get { return this._ControlOverlayDataModel; }
            set
            {
                if (this._ControlOverlayDataModel == value) return;

                this._ControlOverlayDataModel = value;
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
        #region #- [Command] DelegateCommand<bool?>.OverlayControlEnterCommand - ＜オーバーレイ操作確定コマンド＞ -----
        /// <summary> オーバーレイ操作確定コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _OverlayControlEnterCommand;
        /// <summary> オーバーレイ操作確定コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> OverlayControlEnterCommand
        {
            get { return _OverlayControlEnterCommand = _OverlayControlEnterCommand ?? new DelegateCommand<string>(this._OverlayControlEnterExecute, this._CanOverlayControlEnterExecute); }
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

        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayDeleteCommand - ＜オーバーレイ削除コマンド＞ -----
        /// <summary> オーバーレイ削除コマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayDeleteCommand;
        /// <summary> オーバーレイ削除コマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayDeleteCommand
        {
            get { return _OverlayDeleteCommand = _OverlayDeleteCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayDeleteExecute, this._CanOverlayDeleteExecute); }
        }
        #endregion 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ管理コンポーネント／コンストラクタ
        /// </summary>
        public OverlayManageComponent(TimelineComponent pComponent, CommonDataModel pCommonDataModel)
            : base(pCommonDataModel)
        {
            this.TimelineComponent = pComponent;
            this.initComponent();

            this.OverlayManageModule.OverlayDataModelLoad(base.CommonDataModel, this.TimelineComponent, this.OverlayManageDataModel);
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

        /// <summary> [TimerEvent] オーバーレイデータの自動セーブを実行します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void OverlayAutoSave(object o, ElapsedEventArgs e)
        {
            if (this.CommonDataModel.ApplicationData == null) return;

            var targets = this.OverlayManageDataModel.OverlayViewComponentCollection.Where(d => d.OverlayDataModel.SaveChangedTarget);
            if (targets.Count() == 0) return;
            
            List<OverlayDataModel> dataModelList = new List<OverlayDataModel>();
            foreach(var item in targets)
            {
                dataModelList.Add(item.OverlayDataModel);
            }

            this.OverlayManageModule.OverlayDataModelSave(this.CommonDataModel.ApplicationData, dataModelList);
        }

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
            this.ControlOverlayDataModel = new OverlayDataModel();
            this.OverlayManageModule.CreateOverlayTypeCollection(this.ControlOverlayDataModel);

            // --- モーダルを開く
            this.OverlayManageDataModel.OverlayManageData.ModalBaseVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.NowOverlayAddModalVisibility = true;
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayControlEnterCommand - ＜オーバーレイ操作確定コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイ操作確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayControlEnterExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイ操作確定コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayControlEnterExecute(string para)
        {
            switch (para)
            {
                case "Add":
                    this.OverlayManageModule.AddNewOverlay(this.OverlayManageDataModel, this.ControlOverlayDataModel, this.TimelineComponent, base.CommonDataModel);
                    break;
                case "Delete":

                    break;
                default:
                    break;
            }

            this.OverlayManageDataModel.OverlayManageData.ModalBaseVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.NowOverlayAddModalVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.OverlayDeleteModalVisibility = false;
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
        
        #region #- [Method] CanExecute,Execute @ OverlayDeleteCommand - ＜オーバーレイ削除コマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイ削除コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayDeleteExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイ削除コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayDeleteExecute(OverlayViewComponent para)
        {
            // --- 追加用データ生成
            this.ControlOverlayDataModel = new OverlayDataModel();
            this.OverlayManageModule.CreateOverlayTypeCollection(this.ControlOverlayDataModel);

            // --- モーダルを開く
            this.OverlayManageDataModel.OverlayManageData.ModalBaseVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.OverlayDeleteModalVisibility = true;
        }
        #endregion 
    }
}
