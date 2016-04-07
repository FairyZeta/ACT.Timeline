using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prism.Commands;
using FairyZeta.Framework.Process;
using FairyZeta.FF14.ACT.Timeline.Core;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using FairyZeta.FF14.ACT.Timeline.Test.Views;

namespace FairyZeta.FF14.ACT.Timeline.Test.ViewModels
{
    /// <summary> タイムライン／テスト用メインウィンドウ
    /// </summary>
    public class TestWindowViewModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineComponent TimelineComponent { get; private set; }
        public OverlayViewComponent OverlayViewComponent { get; private set; }
        public OverlayManageComponent OverlayManageComponent { get; private set; }


        private XmlSerializerProcess xmlSerializerProcess;

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

        #region #- [Command] DelegateCommand<string>.DataSevaTestCommand - ＜データ保存テストコマンド＞ -----
        /// <summary> データ保存テストコマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _DataSevaTestCommand;
        /// <summary> データ保存テストコマンド＜コマンド＞ </summary>
        public DelegateCommand<string> DataSevaTestCommand
        {
            get { return _DataSevaTestCommand = _DataSevaTestCommand ?? new DelegateCommand<string>(this._DataSevaTestExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand<string>.DataLoadTestCommand - ＜データロードテスト＞ -----
        /// <summary> データロードテスト＜コマンド＞ </summary>
        private DelegateCommand<string> _DataLoadTestCommand;
        /// <summary> データロードテスト＜コマンド＞ </summary>
        public DelegateCommand<string> DataLoadTestCommand
        {
            get { return _DataLoadTestCommand = _DataLoadTestCommand ?? new DelegateCommand<string>(this._DataLoadTestExecute); }
        }
        #endregion 
        #region #- [Command] DelegateCommand.ShowTestWindowCommand - ＜テストウィンドウオープン＞ -----
        /// <summary> テストウィンドウオープン＜コマンド＞ </summary>
        private DelegateCommand _ShowTestWindowCommand;
        /// <summary> テストウィンドウオープン＜コマンド＞ </summary>
        public DelegateCommand ShowTestWindowCommand
        {
            get { return _ShowTestWindowCommand = _ShowTestWindowCommand ?? new DelegateCommand(this._ShowTestWindowExecute); }
        }
        #endregion 


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／テスト用メインウィンドウ／コンストラクタ
        /// </summary>
        public TestWindowViewModel()
        {
            this.TimelineComponent = new TimelineComponent();
            this.OverlayViewComponent = new OverlayViewComponent();
            this.OverlayManageComponent = new OverlayManageComponent(this.TimelineComponent);

            this.xmlSerializerProcess = new XmlSerializerProcess();

            Globals.ResourceRoot = @"D:\TestTimeline\resources";
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
                vm.OverlayManageComponent = this.OverlayManageComponent;
            }

            window.Show();
        }

        #endregion 

        
        #region #- [Method] CanExecute,Execute @ DataSevaTestCommand - ＜データ保存テストコマンド＞ -----
        /// <summary> コマンド実行＜データ保存テストコマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _DataSevaTestExecute(string para)
        {
            switch(para)
            {
                case "PluginSettings":

                    break;

                case "OverlayDataModel":
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ACT.FairyZeta", "Timeline");
                    Directory.CreateDirectory(path);
                    var data = this.OverlayManageComponent.OverlayManageDataModel.OverlayViewComponentCollection[0];
                    this.xmlSerializerProcess.XmlSave(Path.Combine(path,"Test.xml"), data.OverlayDataModel, false);
                    break;
            }
        }
        #endregion 
        
        #region #- [Method] CanExecute,Execute @ DataLoadTestCommand - ＜データロードテスト＞ -----
        /// <summary> コマンド実行＜データロードテスト＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _DataLoadTestExecute(string para)
        {
            switch (para)
            {
                case "PluginSettings":

                    break;

                case "OverlayDataModel":
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ACT.FairyZeta", "Timeline");
                    var data = this.xmlSerializerProcess.XmlLoad(Path.Combine(path, "Test.xml"), typeof(OverlayDataModel), false);
                    break;
            }

        }
        #endregion

        #region #- [Method] CanExecute,Execute @ ShowTestWindowCommand - ＜テストウィンドウオープン＞ -----
        /// <summary> コマンド実行＜テストウィンドウオープン＞ </summary>
        private void _ShowTestWindowExecute()
        {
            TestWindow window = new TestWindow();

            window.Show();
        }
        #endregion ---------- /
    }
}
