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

        #region #- [Command] DelegateCommand.Test_TimelineTextLoadCommand - ＜[テスト]タイムラインテキスト読込＞ -----
        /// <summary> [テスト]タイムラインテキスト読込＜コマンド＞ </summary>
        private DelegateCommand<string> _Test_TimelineTextLoadCommand;
        /// <summary> [テスト]タイムラインテキスト読込＜コマンド＞ </summary>
        public DelegateCommand<string> Test_TimelineTextLoadCommand
        {
            get { return _Test_TimelineTextLoadCommand = _Test_TimelineTextLoadCommand ?? new DelegateCommand<string>(this._Test_TimelineTextLoadExecute); }
        }
        #endregion 


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／テスト用メインウィンドウ／コンストラクタ
        /// </summary>
        public TestWindowViewModel()
        {
            this.TimelineComponent = new TimelineComponent();
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

            MainWindowView view = new MainWindowView();
            var vm = view.DataContext as MainWindowViewModel;
            if(vm != null)
            {
                vm.TimelineComponent = this.TimelineComponent;
            }

            view.Show();

            return;
        }

        #endregion 
    }
}
