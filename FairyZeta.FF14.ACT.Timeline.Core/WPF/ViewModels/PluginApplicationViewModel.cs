using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Advanced_Combat_Tracker;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels
{
    /// <summary> タイムライン／プラグインアプリケーションビューモデル 
    /// </summary>
    public class PluginApplicationViewModel : _ViewModels  
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
            // とりあえずロガー生成
            Globals.CreateLogger();

            this.initViewModel();

            if (Application.Current != null)
            {
                Application.Current.Exit += this.ApplicationExitEvent;
            }

            // アプリケーションタイマー開始
            this.CommonComponent.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.OverlayManageComponent.OverlayAutoSaveEvent);
            this.CommonComponent.AppCommonTimerModule.SecTimer01.Tick += new EventHandler(this.CommonComponent.PluginSettingAutoSaveEvent);
            this.CommonComponent.AppCommonTimerModule.SecTimer01.Start();

        }


      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ビューモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initViewModel()
        {
            this.CommonDataModel = new CommonDataModel();

            this.CommonComponent = new CommonComponent(this.CommonDataModel, true);
            this.TimelineComponent = new TimelineComponent(this.CommonDataModel);
            this.OverlayManageComponent = new OverlayManageComponent(this.TimelineComponent, this.CommonDataModel);

            this.CommonDataModel.AppStatusData.AppStatus = AppStatus.NormalMode;

            // セットアップ終了
            this.CommonComponent.CommonDataModel.LogDataCollection.Add(
                Globals.SysLogger.SystemLog.NonState.DEBUG.Write("Component Setup End."));

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> アプリケーション終了時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ApplicationExitEvent(object sender, ExitEventArgs e)
        {
            // タイマーリセット
            this.CommonComponent.AppCommonTimerModule.SecTimer01.Stop();
            this.TimelineComponent.TimelineControlModule.TimerStop(this.TimelineComponent.CommonDataModel, this.TimelineComponent.TimerDataModel, this.TimelineComponent.TimelineDataModel);

            // ビューリセット
            foreach (var data in this.OverlayManageComponent.OverlayManageDataModel.OverlayViewComponentCollection)
            {
                WindowsServices.WindowCloseSendMessage(data.OverlayDataModel.OverlayWindowData.WindowIntPtr);
            }
        }

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
