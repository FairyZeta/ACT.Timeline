using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Component;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.Core.Forms
{
    public partial class ACTTabPageControl : UserControl
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public CommonDataModel CommonDataModel { get; private set; }
        public TimelineComponent TimelineComponent { get; private set; }

        private TimelineCore timelineCore;

        private PluginApplicationView applicationView;
        private PluginApplicationViewModel applicationViewModel;

        private bool updateFromOverlayMove;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public ACTTabPageControl(TimelineCore pTimelineCore)
        {
            InitializeComponent();

            this.applicationView = this.elementHost.Child as PluginApplicationView;
            this.applicationViewModel = this.applicationView.DataContext as PluginApplicationViewModel;

            this.TimelineComponent = new TimelineComponent(this.CommonDataModel);

            timelineCore = pTimelineCore;
            updateFromOverlayMove = false;

            var settings = timelineCore.Settings;
            settings.AddControlSetting("ResourcesDir", textBoxResourceDir);
            settings.AddControlSetting("MoveOverlayByDrag", checkBoxMoveOverlayByDrag);
            settings.AddControlSetting("ShowOverlayButtons", checkBoxShowOverlayButtons);
            settings.AddControlSetting("PlaySoundByACT", checkBoxPlaySoundByACT);
            settings.AddControlSetting("Autoload", checkBoxAutoloadAfterChangeZone);
            settings.AddControlSetting("AutoShow", checkBoxAutoShow);
            settings.AddControlSetting("AutoHide", checkBoxAutoHide);
            settings.AddControlSetting("ResetTimelineAtCombatEnd", checkBoxResetTimelineCombatEnd);

            timelineCore.TimelineView.Move += TimelineView_Move;
            timelineCore.TimelineView.TimelineFontChanged += TimelineView_TimelineFontChanged;
            timelineCore.TimelineView.ColumnWidthChanged += TimelineView_ColumnWidthChanged;
            timelineCore.TimelineView.OpacityChanged += TimelineView_OpacityChanged;
            timelineCore.Controller.CurrentTimeUpdate += Controller_CurrentTimeUpdate;
            timelineCore.Controller.TimelineUpdate += Controller_TimelineUpdate;
            timelineCore.Controller.PausedUpdate += Controller_PausedUpdate;
            timelineCore.TimelineAutoLoader.ZoneChange += Autoloader_ZoneChange;
            TimelineView_TimelineFontChanged(this, null);
            TimelineView_ColumnWidthChanged(this, null);
            TimelineView_OpacityChanged(this, null);
            Controller_TimelineUpdate(this, null);
            Controller_PausedUpdate(this, null);
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private void Controller_PausedUpdate(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Controller_PausedUpdate(sender, e)));
                return;
            }

            buttonPause.Enabled = !timelineCore.Controller.Paused;
            buttonPlay.Enabled = timelineCore.Controller.Paused;
        }

        public static string FormatMMSS(double time)
        {
            var mm = Math.Floor(time / 60.0);
            var ss = time - mm * 60.0;
            return String.Format("{0:00}:{1:00}", mm, ss);
        }

        private void Controller_TimelineUpdate(object sender, EventArgs e)
        {
            TimelineBaseData timeline = timelineCore.Controller.Timeline;
            if (timeline == null)
                return;

            double endtime = timeline.EndTime;
            labelEndPos.Text = FormatMMSS(endtime);
            trackBar.Maximum = (int)Math.Ceiling(endtime);

            labelLoadedTimeline.Text = timeline.Name;
        }

        private void Controller_CurrentTimeUpdate(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { Controller_CurrentTimeUpdate(sender, e); }));
                return;
            }

            double currtime = timelineCore.Controller.CurrentTime;
            labelCurrPos.Text = FormatMMSS(currtime);

            int currTimeInt = (int)Math.Floor(currtime);
            if (currTimeInt < trackBar.Maximum)
                trackBar.Value = currTimeInt;
        }

        private void TimelineView_Move(object sender, EventArgs e)
        {
            updateFromOverlayMove = true;
            updateFromOverlayMove = false;
        }

        private void buttonResourceDirSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();

            textBoxResourceDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void textBoxResourceDir_TextChanged(object sender, EventArgs e)
        {
            Globals.ResourceRoot = textBoxResourceDir.Text;
            Synchronize();
        }

        private string GenerateDirStatusString()
        {
            if (!Directory.Exists(Globals.ResourceRoot))
            {
                return "Resource dir not found :/";
            }

            string statusText = "Resource dir exists! ";

            if (!Directory.Exists(Globals.SoundFilesRoot))
            {
                statusText += "Sound files dir not found!";
                return statusText;
            }
            statusText += String.Format("Found {0} sound files. ", Globals.NumberOfSoundFilesInResourcesDir());
            
            if (!Directory.Exists(Globals.TimelineTxtsRoot))
            {
                statusText += "Timeline txt files dir not found!";
                return statusText;
            }
            statusText += String.Format("Found {0} timeline txt files.", Globals.TimelineTxtsInResourcesDir.Length);

            return statusText;
        }

        private void Synchronize()
        {
            labelResourceDirStatus.Text = GenerateDirStatusString();
            
            // update timeline list
            listTimelines.Items.Clear();
            foreach (string fullpath in Globals.TimelineTxtsInResourcesDir)
            {
                listTimelines.Items.Add(Path.GetFileName(fullpath));
            }
        }

        private void buttonResourceDirOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Globals.ResourceRoot))
                 System.Diagnostics.Process.Start(Globals.ResourceRoot);
        }

        private void buttonRefreshList_Click(object sender, EventArgs e)
        {
            Synchronize();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string timelineTxtFilePath = (string)listTimelines.SelectedItem;
            timelineCore.Controller.TimelineTxtFilePath = String.Format("{0}/{1}", Globals.TimelineTxtsRoot, timelineTxtFilePath);
        }


        private void checkBoxMoveOverlayByDrag_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineView.MoveByDrag = checkBoxMoveOverlayByDrag.Checked;
        }

        private void trackbar_Scroll(object sender, EventArgs e)
        {
            timelineCore.Controller.CurrentTime = (int)trackBar.Value;
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            timelineCore.Controller.CurrentTime = 0;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            timelineCore.Controller.Paused = true;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            timelineCore.Controller.Paused = false;
        }

        private void checkBoxShowOverlayButtons_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineView.ShowOverlayButtons = checkBoxShowOverlayButtons.Checked;
        }

        private void TimelineView_TimelineFontChanged(object sender, EventArgs e)
        {
            labelCurrentFont.Text = timelineCore.FontString;
        }

        private void buttonFontSelect_Click(object sender, EventArgs e)
        {
            FontDialog fontdialog = new FontDialog();
            fontdialog.Font = timelineCore.TimelineView.TimelineFont;

            if (fontdialog.ShowDialog() != DialogResult.Cancel)
            {
                timelineCore.TimelineView.TimelineFont = fontdialog.Font;
            }
        }

        private void TimelineView_ColumnWidthChanged(object sender, EventArgs e)
        {
            udTextWidth.Value = timelineCore.TimelineView.TextWidth;
            udBarWidth.Value = timelineCore.TimelineView.BarWidth;
        }

        private void udTextWidth_ValueChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineView.TextWidth = (int)udTextWidth.Value;
        }

        private void udBarWidth_ValueChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineView.BarWidth = (int)udBarWidth.Value;
        }

        private void TimelineView_OpacityChanged(object sender, EventArgs e)
        {
            int percentage = (int)(timelineCore.TimelineView.MyOpacity * 100);

            labelCurrOpacity.Text = String.Format("{0}%", percentage);

            percentage = Math.Min(trackBarOpacity.Maximum, percentage);
            percentage = Math.Max(trackBarOpacity.Minimum, percentage);
            trackBarOpacity.Value = percentage;
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            timelineCore.TimelineView.MyOpacity = ((double)trackBarOpacity.Value) / 100;
        }

        private void checkBoxPlaySoundByACT_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineView.PlaySoundByACT = checkBoxPlaySoundByACT.Checked;
        }

        private void checkBoxAutoloadAfterChangeZone_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineAutoLoader.Autoload = checkBoxAutoloadAfterChangeZone.Checked;
        }

        private void checkBoxAutoShow_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineAutoLoader.AutoShow = checkBoxAutoShow.Checked;
        }

        private void checkBoxAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            timelineCore.TimelineAutoLoader.AutoHide = checkBoxAutoHide.Checked;
        }
        private void Autoloader_ZoneChange(object sender, EventArgs e)
        {
            textBoxZonename.Text = timelineCore.TimelineAutoLoader.FindFilename;
        }

        private void checkBoxResetTimelineCombatEnd_CheckedChanged(object sender, EventArgs e)
        {
            Globals.ResetTimelineCombatEnd = checkBoxResetTimelineCombatEnd.Checked;

        }
    }
}
