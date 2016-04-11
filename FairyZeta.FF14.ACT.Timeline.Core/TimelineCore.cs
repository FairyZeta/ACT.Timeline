using Advanced_Combat_Tracker;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using FairyZeta.FF14.ACT.Timeline.Core.Forms;

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

        public TimelineController Controller { get; private set; }

        private ACTTabPageControl tabPageControl;
        public TimelineView TimelineView { get; private set; }
        public TimelineAutoLoader TimelineAutoLoader { get; private set; }
        private CheckBox checkBoxShowView;

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
                // DI log writer
                Globals.WriteLogImpl = (str) => { ActGlobals.oFormActMain.WriteInfoLog(String.Format("act_timeline: {0}", str)); };


                this.StatusText.Text = "Loading Sprache.dll";
#if DEBUG
                // Sprache.dll is already injected by libZ in Release builds.
                Assembly.LoadFrom("Sprache.dll");
#endif
                this.StatusText.Text = "Sprache.dll Load Success!";

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

                //Settings = new PluginSettings(this);
                //Settings.AddStringSetting("TimelineTxtFilePath");
                //Settings.AddStringSetting("FontString");
                //Settings.AddIntSetting("TextWidth");
                //Settings.AddIntSetting("BarWidth");
                //Settings.AddIntSetting("OpacityPercentage");

                SetupTab();
                //InjectButton();

                //Settings.Load();

                //SetupUpdateChecker();

                StatusText.Text = "Plugin Started (^^)!";
            }
            catch (Exception e)
            {
                if (StatusText != null)
                    StatusText.Text = "Plugin Init Failed: " + e.Message;
                return false;
            }
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/


      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private void SetupTab()
        {
            ScreenSpace.Text = "FZ.Timeline";

            tabPageControl = new ACTTabPageControl();
            ScreenSpace.Controls.Add(tabPageControl);
            ScreenSpace.Resize += screenSpace_Resize;
            screenSpace_Resize(this, null);

            tabPageControl.Show();
        }

        private void screenSpace_Resize(object sender, EventArgs e)
        {
            tabPageControl.Location = new System.Drawing.Point(0, 0);
            tabPageControl.Size = ScreenSpace.Size;
        }
        

        void TimelineView_DoubleClick(object sender, EventArgs e)
        {
            TimelineView.Hide();
            checkBoxShowView.Checked = false;
        }

        void InjectButton()
        {
            checkBoxShowView = new CheckBox();
            checkBoxShowView.Appearance = System.Windows.Forms.Appearance.Button;
            checkBoxShowView.Name = "checkBoxShowView";
            checkBoxShowView.Size = new System.Drawing.Size(90, 24);
            checkBoxShowView.Text = "Show Timeline";
            checkBoxShowView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkBoxShowView.UseVisualStyleBackColor = true;
            checkBoxShowView.Checked = true;
            checkBoxShowView.CheckedChanged += checkBoxShowView_CheckedChanged;
            Settings.AddControlSetting("TimelineShown", checkBoxShowView);

            var formMain = ActGlobals.oFormActMain;
            formMain.Resize += formMain_Resize;
            formMain.Controls.Add(checkBoxShowView);
            formMain.Controls.SetChildIndex(checkBoxShowView, 0);

            formMain_Resize(this, null);
        }

        void checkBoxShowView_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowView.Checked)
                TimelineView.Show();
            else
                TimelineView.Hide();
        }

        void formMain_Resize(object sender, EventArgs e)
        {
            // update button location
            var mainFormSize = ActGlobals.oFormActMain.Size;
            checkBoxShowView.Location = new Point(mainFormSize.Width - 435, 0);
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

        public void DeInitPlugin()
        {
            if (checkBoxShowView != null)
                ActGlobals.oFormActMain.Controls.Remove(checkBoxShowView);

            if (TimelineAutoLoader != null)
                TimelineAutoLoader.Stop();

            if (Settings != null)
                Settings.Save();

            if (TimelineView != null)
                TimelineView.Close();

            if (Controller != null)
                Controller.Stop();

            //ActGlobals.oFormActMain.OnCombatEnd -= CombatEnd;
            ActGlobals.oFormActMain.UpdateCheckClicked -= CheckForUpdate;

            if (StatusText != null)
                StatusText.Text = "Plugin Exited m(_ _)m";
        }
    }
}
