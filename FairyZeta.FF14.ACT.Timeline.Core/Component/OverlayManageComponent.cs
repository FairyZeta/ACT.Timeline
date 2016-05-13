using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using Prism.Commands;
using FairyZeta.Framework;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using System.Windows.Data;
using System.Windows;

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

        #region #- [Property] OverlayViewComponent.ControlOverlayViewComponent - ＜オーバーレイ操作用コンポーネント＞ -----
        /// <summary> オーバーレイ操作用コンポーネント </summary>
        private OverlayViewComponent _ControlOverlayViewComponent;
        /// <summary> オーバーレイ操作用コンポーネント </summary>
        public OverlayViewComponent ControlOverlayViewComponent
        {
            get { return this._ControlOverlayViewComponent; }
            set
            {
                if (this._ControlOverlayViewComponent == value) return;

                this._ControlOverlayViewComponent = value;
                base.OnPropertyChanged("ControlOverlayViewComponent");
            }
        }
        #endregion
        #region #- [Property] OverlayDataModel.ControlOverlayDataModel - ＜オーバーレイ操作用データモデル＞ -----
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
                base.OnPropertyChanged("ControlOverlayDataModel");
            }
        }
        #endregion

        /// <summary> オーバーレイ管理モジュール
        /// </summary>
        public OverlayManageModule OverlayManageModule { get; private set; }
        /// <summary> アプリケーション汎用タイマーモジュールモジュール
        /// </summary>
        public AppCommonTimerModule AppCommonTimerModule { get; private set; }

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
        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayCustomWindoOpenCommand - ＜オーバーレイカスタムウインドウオープンコマンド＞ -----
        /// <summary> オーバーレイカスタムウインドウオープンコマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayCustomWindoOpenCommand;
        /// <summary> オーバーレイカスタムウインドウオープンコマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayCustomWindoOpenCommand
        {
            get { return _OverlayCustomWindoOpenCommand = _OverlayCustomWindoOpenCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayCustomWindoOpenExecute, this._CanOverlayCustomWindoOpenExecute); }
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

        #region #- [Command] DelegateCommand.ImportModalVisibleCommand - ＜オーバーレイインポートモーダル表示コマンド＞ -----
        /// <summary> オーバーレイインポートモーダル表示コマンド＜コマンド＞ </summary>
        private DelegateCommand _ImportModalVisibleCommand;
        /// <summary> オーバーレイインポートモーダル表示コマンド＜コマンド＞ </summary>
        public DelegateCommand ImportModalVisibleCommand
        {
            get { return _ImportModalVisibleCommand = _ImportModalVisibleCommand ?? new DelegateCommand(this._ImportModalVisibleExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand.ImportDownloadVisibleCommand - ＜オーバーレイインポートダウンロード表示コマンド＞ -----
        /// <summary> オーバーレイインポートダウンロード表示コマンド＜コマンド＞ </summary>
        private DelegateCommand _ImportDownloadVisibleCommand;
        /// <summary> オーバーレイインポートダウンロード表示コマンド＜コマンド＞ </summary>
        public DelegateCommand ImportDownloadVisibleCommand
        {
            get { return _ImportDownloadVisibleCommand = _ImportDownloadVisibleCommand ?? new DelegateCommand(this._ImportDownloadVisibleExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<ImportType?>.OverlayImportCommand - ＜オーバーレイインポートコマンド＞ -----
        /// <summary> オーバーレイインポートコマンド＜コマンド＞ </summary>
        private DelegateCommand<ImportType?> _OverlayImportCommand;
        /// <summary> オーバーレイインポートコマンド＜コマンド＞ </summary>
        public DelegateCommand<ImportType?> OverlayImportCommand
        {
            get { return _OverlayImportCommand = _OverlayImportCommand ?? new DelegateCommand<ImportType?>(this._OverlayImportExecute); }
        }
        #endregion 

        #region #- [Command] DelegateCommand<OverlayViewComponent>.OverlayExportCommand - ＜オーバーレイエクスポートコマンド＞ -----
        /// <summary> オーバーレイエクスポートコマンド＜コマンド＞ </summary>
        private DelegateCommand<OverlayViewComponent> _OverlayExportCommand;
        /// <summary> オーバーレイエクスポートコマンド＜コマンド＞ </summary>
        public DelegateCommand<OverlayViewComponent> OverlayExportCommand
        {
            get { return _OverlayExportCommand = _OverlayExportCommand ?? new DelegateCommand<OverlayViewComponent>(this._OverlayExportExecute); }
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
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.OverlayManageDataModel = new OverlayManageDataModel();
            this.OverlayManageModule = new OverlayManageModule();
            this.AppCommonTimerModule = new AppCommonTimerModule();

            return true;
        }

        /// <summary> コンポーネントのセットアップを実行します。
        /// </summary>
        /// <param name="pAllOverlayOpen"> セットアップ後にビューを表示する場合 True </param>
        /// <returns> 正常終了時 True </returns>
        public bool SetupComponent(bool pAllOverlayOpen)
        {
            // 保存されているオーバーレイをロードしてセットアップ
            this.OverlayManageModule.OverlayDataModelLoad(base.CommonDataModel, this.TimelineComponent, this.OverlayManageDataModel);

            // オーバーレイが0件時に自動作成
            if (this.OverlayManageDataModel.OverlayViewComponentCollection.Count == 0)
            {
                OverlayDataModel controlModel = new OverlayDataModel();
                controlModel.OverlayWindowData.OverlayName = "TimelineControl";
                controlModel.OverlayWindowData.OverlayType = OverlayType.TimelineControl;
                this.OverlayManageModule.AddNewOverlay(base.CommonDataModel, controlModel, this.TimelineComponent, this.OverlayManageDataModel, false);

                OverlayDataModel timelineModel = new OverlayDataModel();
                timelineModel.OverlayWindowData.OverlayName = "StandardTimeline";
                timelineModel.OverlayWindowData.OverlayType = OverlayType.StandardTimeline;
                this.OverlayManageModule.AddNewOverlay(base.CommonDataModel, timelineModel, this.TimelineComponent, this.OverlayManageDataModel, false);

            }

            // オーバーレイセットアップを実行
            foreach (var overlay in this.OverlayManageDataModel.OverlayViewComponentCollection)
            {
                overlay.ComponenSetupt();
            }

            // 必要であれば全てオープン
            if (pAllOverlayOpen)
            {
                this.OverlayManageModule.ShowOverlay(base.CommonDataModel, this.TimelineComponent, this.OverlayManageDataModel.OverlayViewComponentCollection);
            }

            return true;
        }

        /// <summary> 自動実行系の処理を開始します。
        /// </summary>
        /// <returns> 正常に開始した場合 True </returns>
        public bool AutoProcessStart()
        {
            // オーバーレイ自動管理の開始
            this.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.OverlayAutoSaveEvent);
            //this.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.OverlayAutoHideEvent);
            this.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.OverlayAutoTopMostEvent);
            this.AppCommonTimerModule.SecTimer01.Start();

            return true;
        }

        /// <summary> 自動実行系の処理を終了します。
        /// </summary>
        /// <returns> 正常に終了した場合 True </returns>
        public bool AutoProcessEnd()
        {
            // オーバーレイ自動管理の終了
            this.AppCommonTimerModule.SecTimer01.Stop();
            this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.OverlayAutoSaveEvent);
            //this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.OverlayAutoHideEvent);
            this.AppCommonTimerModule.SecTimer01.Tick -= new EventHandler(this.OverlayAutoTopMostEvent);

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [TimerEvent] オーバーレイデータの自動セーブを実行します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void OverlayAutoSaveEvent(object o, EventArgs e)
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

        /// <summary> [TimerEvent] オーバーレイを自動的に最前面に移動します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void OverlayAutoTopMostEvent(object o, EventArgs e)
        {
            foreach(var comp in this.OverlayManageDataModel.OverlayViewComponentCollection)
            {
                comp.OverlayDataModel.OverlayWindowData.TopMost = false;
                comp.OverlayDataModel.OverlayWindowData.TopMost = true;
            }
        }

        /// <summary> [TimerEvent] 一時的にオーバーレイを非表示にする必要があるかを判定します。
        /// </summary>
        /// <param name="o"> タイマーオブジェクト </param>
        /// <param name="e"> タイマーイベント </param>
        public void OverlayAutoHideEvent(object o, EventArgs e)
        {

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
                    this.OverlayManageModule.AddNewOverlay(base.CommonDataModel, this.ControlOverlayDataModel, this.TimelineComponent, this.OverlayManageDataModel, false);
                    break;
                case "Delete":
                    this.OverlayManageModule.DeleteOverlay(this.ControlOverlayViewComponent, base.CommonDataModel, this.OverlayManageDataModel);
                    break;
                default:
                    break;
            }

            this.OverlayManageDataModel.OverlayManageData.Clear();
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
            if (para == null) return;

            if (para.OverlayDataModel.OverlayWindowData.WindowVisibility)
            {
                this.OverlayManageModule.ShowOverlay(base.CommonDataModel, this.TimelineComponent, para);
            }
            else
            {
                WindowsServices.WindowCloseSendMessage(para.OverlayDataModel.OverlayWindowData.WindowIntPtr);
                para.OverlayDataModel.OverlayWindowData.WindowIntPtr = IntPtr.Zero;
            }

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
                WindowsServices.SetWindowExTransparent(para.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
            else
            {
                WindowsServices.InitWindowExTransparent(para.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ OverlayCustomWindoOpenCommand - ＜オーバーレイカスタムウインドウオープンコマンド＞ -----
        /// <summary> 実行可能確認＜オーバーレイカスタムウインドウオープンコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanOverlayCustomWindoOpenExecute(OverlayViewComponent para)
        {
            return true;
        }

        /// <summary> コマンド実行＜オーバーレイカスタムウインドウオープンコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayCustomWindoOpenExecute(OverlayViewComponent para)
        {
            this.OverlayManageModule.ShowCustomWindow(base.CommonDataModel, para);
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
            this.ControlOverlayViewComponent = para;
            this.ControlOverlayDataModel = para.OverlayDataModel;
            this.OverlayManageModule.CreateOverlayTypeCollection(this.ControlOverlayDataModel);

            // --- モーダルを開く
            this.OverlayManageDataModel.OverlayManageData.ModalBaseVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.OverlayDeleteModalVisibility = true;
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ ImportModalVisibleCommand - ＜オーバーレイインポートモーダル表示コマンド＞ -----
        /// <summary> コマンド実行＜オーバーレイインポートモーダル表示コマンド＞ </summary>
        private void _ImportModalVisibleExecute()
        {
            this.OverlayManageDataModel.OverlayManageData.ModalBaseVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.OverlayImportModalVisibility = true;

            this.OverlayManageDataModel.OverlayManageData.ImportMenuVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.ImportDownloadButtonVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.ImportCloseButtonVisibility = true;
        }
        #endregion 
        
        #region #- [Method] Execute @ ImportDownloadVisibleCommand - ＜オーバーレイインポートダウンロード表示コマンド＞ -----
        /// <summary> コマンド実行＜オーバーレイインポートダウンロード表示コマンド＞ </summary>
        private void _ImportDownloadVisibleExecute()
        {
            this.OverlayManageDataModel.OverlayManageData.ImportMenuVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.ImportDownloadVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.ImportDownloadButtonVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.ImportURL = "http://";
        }
        #endregion 

        #region #- [Method] Execute @ OverlayImportCommand - ＜オーバーレイインポートコマンド＞ -----
        /// <summary> コマンド実行＜オーバーレイインポートコマンド＞ </summary>
        private async void _OverlayImportExecute(ImportType? para)
        {
            if (!para.HasValue)
                return;

            if (this.OverlayManageDataModel.OverlayManageData.ImportResultVisibility)
                return;

            this.OverlayManageDataModel.OverlayManageData.ImportMenuVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.NowImportVisibility = true;
            this.OverlayManageDataModel.OverlayManageData.ImportCloseButtonVisibility = false;
            this.OverlayManageDataModel.OverlayManageData.ImportDownloadButtonVisibility = false;

            switch(para.Value)
            { 
                case ImportType.File:

                    try
                    {
                        if(this.OverlayManageModule.ImportOverlay(base.CommonDataModel, this.TimelineComponent, this.OverlayManageDataModel))
                        {
                            this.OverlayManageDataModel.OverlayManageData.ImportResult = ImportResult.Success;
                            this.OverlayManageDataModel.OverlayManageData.ImportMsg = string.Format("Import Complete.");

                        }
                        else
                        {
                            this.OverlayManageDataModel.OverlayManageData.ImportResult = ImportResult.Cancel;
                            this.OverlayManageDataModel.OverlayManageData.ImportMsg = string.Format("Import Cancel.");
                        }
                    }
                    catch (Exception e)
                    {
                        this.ImportErrorHandler(e);
                    }
                    finally
                    {
                        this.OverlayManageDataModel.OverlayManageData.ImportResultVisibility = true;
                        this.OverlayManageDataModel.OverlayManageData.ImportCloseButtonVisibility = true;
                    }
                    
                    return;

                case ImportType.Web:

                    var task = Task.Run(() =>
                        {
                            try
                            {
                                if (!this.OverlayManageModule.DownloadOverlay(base.CommonDataModel, this.OverlayManageDataModel.OverlayManageData.ImportURL))
                                {

                                    this.OverlayManageDataModel.OverlayManageData.ImportResult = ImportResult.Failure;
                                    this.OverlayManageDataModel.OverlayManageData.ImportMsg = string.Format("[ERROR] {0}", "Network Not Available.");
                                    return false;
                                }
                            }
                            catch (Exception e)
                            {
                                this.ImportErrorHandler(e);
                                return false;
                            }

                            return true;
                        });

                    await task;

                    try
                    {
                        if (!task.Result)
                            return;

                        this.OverlayManageModule.ImportOverlay(base.CommonDataModel, this.TimelineComponent, this.OverlayManageDataModel, base.CommonDataModel.ApplicationData.GetTempOverlayFullPath);

                        this.OverlayManageDataModel.OverlayManageData.ImportResult = ImportResult.Success;
                        this.OverlayManageDataModel.OverlayManageData.ImportMsg = string.Format("Import Complete.");
                            
                    }
                    catch (Exception e)
                    {
                        this.ImportErrorHandler(e);
                    }
                    finally
                    {
                        if(File.Exists(base.CommonDataModel.ApplicationData.GetTempOverlayFullPath))
                        {
                            File.Delete(base.CommonDataModel.ApplicationData.GetTempOverlayFullPath);
                        }

                        this.OverlayManageDataModel.OverlayManageData.ImportResultVisibility = true;
                        this.OverlayManageDataModel.OverlayManageData.ImportCloseButtonVisibility = true;
                    }

                    return;
                        
            }
            
        }

        /// <summary> インポートエラー時の処理
        /// </summary>
        /// <param name="e"> 発生した例外 </param>
        private void ImportErrorHandler(Exception e)
        {
            string msg = string.Format("Overlay Import Error: {0}", e.Message);

            this.OverlayManageDataModel.OverlayManageData.ImportResult = ImportResult.Failure;
            this.OverlayManageDataModel.OverlayManageData.ImportMsg = string.Format("[ERROR] {0}", e.Message);
            
        }

        #endregion




        #region #- [Method] Execute @ OverlayExportCommand - ＜オーバーレイエクスポートコマンド＞ -----
        /// <summary> コマンド実行＜オーバーレイエクスポートコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _OverlayExportExecute(OverlayViewComponent para)
        {
            this.OverlayManageModule.ExportOverlay(base.CommonDataModel, para.OverlayDataModel);
        }
        #endregion 
    }
}
