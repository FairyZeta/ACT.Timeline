using Advanced_Combat_Tracker;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using FairyZeta.FF14.ACT.Timeline.Core.Forms;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    /// <summary> タイムライン／コア
    /// </summary>
    public class TimelineCore
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プラグインタブに追加されるスクリーンスペース
        /// </summary>
        public TabPage ScreenSpace { get; private set; }
        /// <summary> プラグイン一覧に表示されるステータスメッセージ
        /// </summary>
        public Label StatusText { get; private set; }
        /// <summary> プラグインまでのディレクトリパス
        /// </summary>
        public string PuluginDirectoryPath { get; private set; }

        /// <summary> ActTabに表示されているタブページのビューモデル
        /// </summary>
        private PluginApplicationViewModel pluginApplicationViewModel;

        public TimelineController Controller { get; private set; }

        private ACTTabPageControl tabPageControl;
        //public TimelineView TimelineView { get; private set; }

        public PluginSettings Settings { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／コア／コンストラクタ
        /// </summary>
        public TimelineCore(TabPage pluginScreenSpace, Label pluginStatusText, string pPuluginDirectoryPath)
        {
            this.ScreenSpace = pluginScreenSpace;
            this.StatusText = pluginStatusText;
            Globals.PluginDllDirectoryPath = pPuluginDirectoryPath;

            this.initCore();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コアの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initCore()
        {
            try
            {
                // ロガー生成
                Globals.CreateLogger();
                // DI log writer
                Globals.WriteLogImpl = (str) => { ActGlobals.oFormActMain.WriteInfoLog(String.Format("act_timeline: {0}", str)); };


                //this.StatusText.Text = "Loading Sprache.dll";
#if DEBUG
                // Sprache.dll is already injected by libZ in Release builds.
                //Assembly.LoadFrom("Sprache.dll");
#endif
                //this.StatusText.Text = "Sprache.dll Load Success!";

#if DEBUG
                // See Issue #1
                // Control.CheckForIllegalCrossThreadCalls = true;
#endif

                //Controller = new TimelineController();

                //TimelineView = new TimelineView(Controller);
                //TimelineView.Show();
                //TimelineView.DoubleClick += TimelineView_DoubleClick;

                //TimelineAutoLoader = new TimelineAutoLoader(this);
                //TimelineAutoLoader.Start();
                
                this.SetupTab();
                this.pluginApplicationViewModel = tabPageControl.PluginApplicationView.DataContext as PluginApplicationViewModel;
                this.pluginApplicationViewModel.ApplicationSetup();

                this.CreateInjectButton(this.pluginApplicationViewModel.CommonComponent);

                //SetupUpdateChecker();

                StatusText.Text = "Plugin Started.";
                Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("Plugin Load End.", Globals.ProjectName);
            }
            catch (Exception e)
            {
                if (StatusText != null)
                    StatusText.Text = "Plugin Init Failed: " + e.Message;
                Globals.ErrLogger.WriteStackTrace(e);

                return false;
            }
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> Actからプラグインが切り離されたときの処理
        /// </summary>
        public void DeInitPlugin()
        {
            // ACT本体搭載のチェックボックスを削除
            if (this.pluginApplicationViewModel.CommonComponent.CommonDataModel.FormActMainControlData.ActCheckBox != null)
                ActGlobals.oFormActMain.Controls.Remove(this.pluginApplicationViewModel.CommonComponent.CommonDataModel.FormActMainControlData.ActCheckBox);

            // コンポーネントの自動処理停止
            this.pluginApplicationViewModel.ApplicationExit();

            //if (TimelineAutoLoader != null)
            //    TimelineAutoLoader.Stop();
            
            //if (TimelineView != null)
            //    TimelineView.Close();

            if (Controller != null)
                Controller.Stop();

            //ActGlobals.oFormActMain.OnCombatEnd -= CombatEnd;
            ActGlobals.oFormActMain.UpdateCheckClicked -= CheckForUpdate;

            if (StatusText != null)
                StatusText.Text = "Plugin Exited.";
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
    
        /// <summary> Actタブに表示される画面のセットアップを実行します。
        /// </summary>
        private void SetupTab()
        {
            ScreenSpace.Text = "FZ.Timeline";

            tabPageControl = new ACTTabPageControl();
            ScreenSpace.Controls.Add(tabPageControl);
            ScreenSpace.Resize += screenSpace_Resize;
            screenSpace_Resize(this, null);


            tabPageControl.Show();
        }

        /// <summary> タブページリサイズイベントを登録します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void screenSpace_Resize(object sender, EventArgs e)
        {
            tabPageControl.Location = new System.Drawing.Point(0, 0);
            tabPageControl.Size = ScreenSpace.Size;
        }

        /// <summary> ACT本体に表示されるチェックボックスを生成します。
        /// </summary>
        private void CreateInjectButton(Component.CommonComponent pCommonComponent)
        {
            Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("Start CreateInjectButton.");
            pCommonComponent.CommonDataModel.FormActMainControlData.ActCheckBox = new CheckBox();
            CheckBox pCheckBox = pCommonComponent.CommonDataModel.FormActMainControlData.ActCheckBox;
            Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("Start CheckBox Setting.");
            pCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            pCheckBox.Name = "checkBoxShowView";
            pCheckBox.Size = new System.Drawing.Size(90, 24);
            pCheckBox.Text = "Show Timeline";
            pCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            pCheckBox.UseVisualStyleBackColor = true;
            pCheckBox.Checked = pCommonComponent.CommonDataModel.PluginSettingsData.ActCheckBoxValue;
            pCheckBox.CheckedChanged += pCommonComponent.ActCheckBoxCheckedChanged;

            Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("Start Resize Setting.");
            var formMain = ActGlobals.oFormActMain;
            formMain.Resize += formMain_Resize;
            formMain.Controls.Add(pCheckBox);
            formMain.Controls.SetChildIndex(pCheckBox, 0);

            formMain_Resize(this, null);
            Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write("End CreateInjectButton.");
        }

        /// <summary> チェックボックスリサイズ（配置変更）イベントを登録します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void formMain_Resize(object sender, EventArgs e)
        {
            if (this.pluginApplicationViewModel == null)
                return;

            var mainFormSize = ActGlobals.oFormActMain.Size;
            this.pluginApplicationViewModel.CommonComponent.CommonDataModel.FormActMainControlData.ActCheckBox.Location = new Point(mainFormSize.Width - 435, 0);
 
        }


        void SetupUpdateChecker()
        {
            ActGlobals.oFormActMain.UpdateCheckClicked += new FormActMain.NullDelegate(CheckForUpdate);
            if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed())
                CheckForUpdate();
        }

        void CheckForUpdate()
        {
            var myVersion = typeof(TimelineCore).Assembly.GetName().Version.ToString();
            var updateChecker = new UpdateChecker(myVersion);
            updateChecker.PerformCheckOnNewThread();
        }

    }
}
