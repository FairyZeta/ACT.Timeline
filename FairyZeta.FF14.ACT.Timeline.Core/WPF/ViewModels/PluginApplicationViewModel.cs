using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Advanced_Combat_Tracker;
using Prism.Commands;
using FairyZeta.Framework;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／プラグインアプリケーションビューモデル 
    /// </summary>
    public class PluginApplicationViewModel : _ViewModel  
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      #region - [Region] - DataModels

        /// <summary> 共通データモデル
        /// </summary>
        public CommonDataModel CommonDataModel { get; private set; }

      #endregion

      #region - [Region] - Components

        /// <summary> 共通コンポーネント
        /// </summary>
        public CommonComponent CommonComponent { get; private set; }
        /// <summary> タイムラインコンポーネント
        /// </summary>
        public TimelineComponent TimelineComponent { get; private set; }
        /// <summary> オーバーレイ管理コンポーネント
        /// </summary>
        public OverlayManageComponent OverlayManageComponent { get; private set; }

      #endregion

      #region - [Region] - Commands
        
        #region #- [Command] DelegateCommand.ShowOverlayManageCommand - ＜オーバーレイ管理ウィンドウ表示コマンド＞ -----
        /// <summary> オーバーレイ管理ウィンドウ表示コマンド＜コマンド＞ </summary>
        private DelegateCommand _ShowOverlayManageCommand;
        /// <summary> オーバーレイ管理ウィンドウ表示コマンド＜コマンド＞ </summary>
        public DelegateCommand ShowOverlayManageCommand
        {
            get { return _ShowOverlayManageCommand = _ShowOverlayManageCommand ?? new DelegateCommand(this._ShowOverlayManageExecute); }
        }
        #endregion

      #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／プラグインアプリケーションビューモデル 
        /// </summary>
        public PluginApplicationViewModel()
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
            this.CommonDataModel = new CommonDataModel();

            this.CommonComponent = new CommonComponent(this.CommonDataModel);
            this.TimelineComponent = new TimelineComponent(this.CommonDataModel);
            this.OverlayManageComponent = new OverlayManageComponent(this.TimelineComponent, this.CommonDataModel);

            return true;
        }

        /// <summary> アプリケーションのセットアップを実行します。
        /// </summary>
        public void ApplicationSetup()
        {
            // ログ削除実行
            Globals.SysLogger.DeleteLogFile();
            Globals.ErrLogger.DeleteLogFile();
            Globals.TimelineLogger.DeleteLogFile();

            // セットアップ開始
            this.CommonComponent.SetupComponent();
            this.TimelineComponent.SetupComponent(true);
            
            switch (this.CommonComponent.CommonDataModel.AppStatusData.AppMode)
            {
                case AppMode.Desing:
                    this.OverlayManageComponent.SetupComponent(false);
                    break;
                case AppMode.Debug:
                case AppMode.Normal:
                case AppMode.NotInitSetup:
                    this.OverlayManageComponent.SetupComponent(true);
                    break;
            }

            // 自動実行系処理の開始
            if (this.CommonComponent.CommonDataModel.AppStatusData.AppMode != AppMode.Desing)
            {
                this.CommonComponent.AutoProcessStart();
                this.TimelineComponent.AutoProcessStart();
                this.OverlayManageComponent.AutoProcessStart();
            }

            // セットアップ終了
            this.CommonDataModel.AppStatusData.AppStatus = AppStatus.NormalMode;
            this.CommonComponent.CommonDataModel.LogDataCollection.Add(
                Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("App Setup End."));
        }

        /// <summary> アプリケーションの終了処理を実行します。
        /// </summary>
        public void ApplicationExit()
        {
            // 自動実行系処理の停止
            this.CommonComponent.AutoProcessEnd();
            this.TimelineComponent.AutoProcessEnd();
            this.OverlayManageComponent.AutoProcessEnd();
            // シャットダウン処理の実行
            this.CommonComponent.ComponentShutdown();
            this.TimelineComponent.ComponentShutdown();
            this.OverlayManageComponent.ComponentShutdown();

        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
        
      #region #- [Method] Execute @ ShowOverlayManageCommand - ＜オーバーレイ管理ウィンドウ表示コマンド＞ -----

        /// <summary> コマンド実行＜オーバーレイ管理ウィンドウ表示コマンド＞ </summary>
        private void _ShowOverlayManageExecute()
        {
            OverlayManageWindow window = new OverlayManageWindow();

            window.Width = 800;
            window.Height = 300;

            var vm = window.DataContext as OverlayManageWindowViewModel;
            if (vm != null)
            {
                vm.OverlayManageComponent = this.OverlayManageComponent;
            }

            window.Show();
        }


      #endregion

    }
}
