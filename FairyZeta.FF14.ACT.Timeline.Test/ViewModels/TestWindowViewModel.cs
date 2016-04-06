using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Test.ViewModels
{
    /// <summary> タイムライン／テスト用メインウィンドウ
    /// </summary>
    public class TestWindowViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineComponent TimelineComponent { get; private set; }
        public OverlayViewComponent ViewControlComponent { get; private set; }

        #region #- [Command] DelegateCommand.Test_TimelineTextLoadCommand - ＜[テスト]タイムラインテキスト読込＞ -----
        /// <summary> [テスト]タイムラインテキスト読込＜コマンド＞ </summary>
        private DelegateCommand<string> _Test_TimelineTextLoadCommand;
        /// <summary> [テスト]タイムラインテキスト読込＜コマンド＞ </summary>
        public DelegateCommand<string> Test_TimelineTextLoadCommand
        {
            get { return _Test_TimelineTextLoadCommand = _Test_TimelineTextLoadCommand ?? new DelegateCommand<string>(this._Test_TimelineTextLoadExecute); }
        }
        #endregion 

        
        #region #- [Command] DelegateCommand.ShowOverlayManageCommand - ＜オーバーレイ管理ウィンドウ表示コマンド＞ -----
        /// <summary> オーバーレイ管理ウィンドウ表示コマンド＜コマンド＞ </summary>
        private DelegateCommand _ShowOverlayManageCommand;
        /// <summary> オーバーレイ管理ウィンドウ表示コマンド＜コマンド＞ </summary>
        public DelegateCommand ShowOverlayManageCommand
        {
            get { return _ShowOverlayManageCommand = _ShowOverlayManageCommand ?? new DelegateCommand(this._ShowOverlayManageExecute); }
        }
        #endregion ---------- /


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／テスト用メインウィンドウ／コンストラクタ
        /// </summary>
        public TestWindowViewModel()
        {
            this.TimelineComponent = new TimelineComponent();
            this.ViewControlComponent = new Core.Component.OverlayViewComponent();
            Globals.ResourceRoot = @"D:\TestTimeline";
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Method] Execute @ Test_TimelineTextLoadCommand - ＜サマリ＞ -----

        /// <summary> コマンド実行＜[テスト]タイムラインテキスト読込＞ </summary>
        private void _Test_TimelineTextLoadExecute(string para)
        {
            var timeline = TimelineLoader.LoadFromFile(para);
            this.TimelineComponent.TimelineCreateModule.CreateTimelineDataModel(timeline, this.TimelineComponent.TimelineDataModel);

            OverlayWindowView view = new OverlayWindowView();
            
            view.Topmost = true;
            var vm = view.DataContext as OverlayWindowViewModel;
            if(vm != null)
            {
                vm.TimelineComponent = this.TimelineComponent;
                vm.ViewControlComponent = this.ViewControlComponent;
            }

            view.Show();

            return;
        }

        #endregion 

        #region #- [Method] Execute @ ShowOverlayManageCommand - ＜オーバーレイ管理ウィンドウ表示コマンド＞ -----

        /// <summary> コマンド実行＜オーバーレイ管理ウィンドウ表示コマンド＞ </summary>
        private void _ShowOverlayManageExecute()
        {
            OverlayManageWindowView window = new OverlayManageWindowView();

            window.Width = 800;
            window.Height = 300;

            var vm = window.DataContext as OverlayManageWindowViewModel;
            if (vm != null)
            {
                vm.OverlayManageComponent = new OverlayManageComponent();
            }

            window.Show();
        }

        #endregion 
    }
}
