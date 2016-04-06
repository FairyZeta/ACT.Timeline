﻿namespace FairyZeta.FF14.ACT.Timeline.Core.Forms
{
    partial class ACTTabPageControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonResourceDirSelect = new System.Windows.Forms.Button();
            this.textBoxResourceDir = new System.Windows.Forms.TextBox();
            this.labelResourceDir = new System.Windows.Forms.Label();
            this.groupBoxEnvironment = new System.Windows.Forms.GroupBox();
            this.labelResourceDirStatus = new System.Windows.Forms.Label();
            this.checkBoxPlaySoundByACT = new System.Windows.Forms.CheckBox();
            this.buttonResourceDirOpen = new System.Windows.Forms.Button();
            this.groupBoxTimelines = new System.Windows.Forms.GroupBox();
            this.buttonRefreshList = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.listTimelines = new System.Windows.Forms.ListBox();
            this.groupBoxOverlay = new System.Windows.Forms.GroupBox();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.checkBoxShowOverlayButtons = new System.Windows.Forms.CheckBox();
            this.checkBoxMoveOverlayByDrag = new System.Windows.Forms.CheckBox();
            this.buttonFontSelect = new System.Windows.Forms.Button();
            this.labelBar = new System.Windows.Forms.Label();
            this.udBarWidth = new System.Windows.Forms.NumericUpDown();
            this.udTextWidth = new System.Windows.Forms.NumericUpDown();
            this.labelCurrentFont = new System.Windows.Forms.Label();
            this.labelFont = new System.Windows.Forms.Label();
            this.labelCurrOpacity = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.groupBoxTracker = new System.Windows.Forms.GroupBox();
            this.labelSlash = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.labelEndPos = new System.Windows.Forms.Label();
            this.labelCurrPos = new System.Windows.Forms.Label();
            this.labelLoadedTimeline = new System.Windows.Forms.Label();
            this.labelLoadedTimelineLabel = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.groupBoxAutoLoader = new System.Windows.Forms.GroupBox();
            this.checkBoxResetTimelineCombatEnd = new System.Windows.Forms.CheckBox();
            this.textBoxZonename = new System.Windows.Forms.TextBox();
            this.labeltxt = new System.Windows.Forms.Label();
            this.labelFindFilename = new System.Windows.Forms.Label();
            this.checkBoxAutoHide = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoloadAfterChangeZone = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoShow = new System.Windows.Forms.CheckBox();
            this.groupOverlayManage = new System.Windows.Forms.GroupBox();
            this.groupBoxEnvironment.SuspendLayout();
            this.groupBoxTimelines.SuspendLayout();
            this.groupBoxOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTextWidth)).BeginInit();
            this.groupBoxTracker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBoxAutoLoader.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonResourceDirSelect
            // 
            this.buttonResourceDirSelect.Location = new System.Drawing.Point(435, 39);
            this.buttonResourceDirSelect.Name = "buttonResourceDirSelect";
            this.buttonResourceDirSelect.Size = new System.Drawing.Size(29, 18);
            this.buttonResourceDirSelect.TabIndex = 0;
            this.buttonResourceDirSelect.Text = "...";
            this.buttonResourceDirSelect.UseVisualStyleBackColor = true;
            this.buttonResourceDirSelect.Click += new System.EventHandler(this.buttonResourceDirSelect_Click);
            // 
            // textBoxResourceDir
            // 
            this.textBoxResourceDir.Location = new System.Drawing.Point(11, 39);
            this.textBoxResourceDir.Name = "textBoxResourceDir";
            this.textBoxResourceDir.Size = new System.Drawing.Size(418, 19);
            this.textBoxResourceDir.TabIndex = 1;
            this.textBoxResourceDir.TextChanged += new System.EventHandler(this.textBoxResourceDir_TextChanged);
            // 
            // labelResourceDir
            // 
            this.labelResourceDir.Location = new System.Drawing.Point(8, 15);
            this.labelResourceDir.Name = "labelResourceDir";
            this.labelResourceDir.Size = new System.Drawing.Size(178, 21);
            this.labelResourceDir.TabIndex = 2;
            this.labelResourceDir.Text = "Resources Directory:";
            this.labelResourceDir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBoxEnvironment
            // 
            this.groupBoxEnvironment.Controls.Add(this.labelResourceDirStatus);
            this.groupBoxEnvironment.Controls.Add(this.textBoxResourceDir);
            this.groupBoxEnvironment.Controls.Add(this.checkBoxPlaySoundByACT);
            this.groupBoxEnvironment.Controls.Add(this.labelResourceDir);
            this.groupBoxEnvironment.Controls.Add(this.buttonResourceDirOpen);
            this.groupBoxEnvironment.Controls.Add(this.buttonResourceDirSelect);
            this.groupBoxEnvironment.Location = new System.Drawing.Point(16, 250);
            this.groupBoxEnvironment.Name = "groupBoxEnvironment";
            this.groupBoxEnvironment.Size = new System.Drawing.Size(470, 126);
            this.groupBoxEnvironment.TabIndex = 3;
            this.groupBoxEnvironment.TabStop = false;
            this.groupBoxEnvironment.Text = "Environment";
            // 
            // labelResourceDirStatus
            // 
            this.labelResourceDirStatus.AutoSize = true;
            this.labelResourceDirStatus.Location = new System.Drawing.Point(13, 64);
            this.labelResourceDirStatus.Name = "labelResourceDirStatus";
            this.labelResourceDirStatus.Size = new System.Drawing.Size(109, 12);
            this.labelResourceDirStatus.TabIndex = 3;
            this.labelResourceDirStatus.Text = "Resource Dir Status";
            // 
            // checkBoxPlaySoundByACT
            // 
            this.checkBoxPlaySoundByACT.AutoSize = true;
            this.checkBoxPlaySoundByACT.Checked = true;
            this.checkBoxPlaySoundByACT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlaySoundByACT.Location = new System.Drawing.Point(11, 97);
            this.checkBoxPlaySoundByACT.Name = "checkBoxPlaySoundByACT";
            this.checkBoxPlaySoundByACT.Size = new System.Drawing.Size(123, 16);
            this.checkBoxPlaySoundByACT.TabIndex = 3;
            this.checkBoxPlaySoundByACT.Text = "Play sound by ACT";
            this.checkBoxPlaySoundByACT.UseVisualStyleBackColor = true;
            this.checkBoxPlaySoundByACT.CheckedChanged += new System.EventHandler(this.checkBoxPlaySoundByACT_CheckedChanged);
            // 
            // buttonResourceDirOpen
            // 
            this.buttonResourceDirOpen.Location = new System.Drawing.Point(379, 63);
            this.buttonResourceDirOpen.Name = "buttonResourceDirOpen";
            this.buttonResourceDirOpen.Size = new System.Drawing.Size(85, 20);
            this.buttonResourceDirOpen.TabIndex = 0;
            this.buttonResourceDirOpen.Text = "Open Folder";
            this.buttonResourceDirOpen.UseVisualStyleBackColor = true;
            this.buttonResourceDirOpen.Click += new System.EventHandler(this.buttonResourceDirOpen_Click);
            // 
            // groupBoxTimelines
            // 
            this.groupBoxTimelines.Controls.Add(this.buttonRefreshList);
            this.groupBoxTimelines.Controls.Add(this.buttonLoad);
            this.groupBoxTimelines.Controls.Add(this.listTimelines);
            this.groupBoxTimelines.Location = new System.Drawing.Point(15, 128);
            this.groupBoxTimelines.Name = "groupBoxTimelines";
            this.groupBoxTimelines.Size = new System.Drawing.Size(470, 116);
            this.groupBoxTimelines.TabIndex = 4;
            this.groupBoxTimelines.TabStop = false;
            this.groupBoxTimelines.Text = "Timelines";
            // 
            // buttonRefreshList
            // 
            this.buttonRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshList.Location = new System.Drawing.Point(375, 82);
            this.buttonRefreshList.Name = "buttonRefreshList";
            this.buttonRefreshList.Size = new System.Drawing.Size(89, 25);
            this.buttonRefreshList.TabIndex = 1;
            this.buttonRefreshList.Text = "Refresh List";
            this.buttonRefreshList.UseVisualStyleBackColor = true;
            this.buttonRefreshList.Click += new System.EventHandler(this.buttonRefreshList_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(376, 18);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(89, 25);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // listTimelines
            // 
            this.listTimelines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listTimelines.FormattingEnabled = true;
            this.listTimelines.ItemHeight = 12;
            this.listTimelines.Location = new System.Drawing.Point(12, 18);
            this.listTimelines.Name = "listTimelines";
            this.listTimelines.Size = new System.Drawing.Size(355, 88);
            this.listTimelines.TabIndex = 0;
            this.listTimelines.DoubleClick += new System.EventHandler(this.buttonLoad_Click);
            // 
            // groupBoxOverlay
            // 
            this.groupBoxOverlay.Controls.Add(this.trackBarOpacity);
            this.groupBoxOverlay.Controls.Add(this.checkBoxShowOverlayButtons);
            this.groupBoxOverlay.Controls.Add(this.checkBoxMoveOverlayByDrag);
            this.groupBoxOverlay.Controls.Add(this.buttonFontSelect);
            this.groupBoxOverlay.Controls.Add(this.labelBar);
            this.groupBoxOverlay.Controls.Add(this.udBarWidth);
            this.groupBoxOverlay.Controls.Add(this.udTextWidth);
            this.groupBoxOverlay.Controls.Add(this.labelCurrentFont);
            this.groupBoxOverlay.Controls.Add(this.labelFont);
            this.groupBoxOverlay.Controls.Add(this.labelCurrOpacity);
            this.groupBoxOverlay.Controls.Add(this.labelOpacity);
            this.groupBoxOverlay.Location = new System.Drawing.Point(16, 382);
            this.groupBoxOverlay.Name = "groupBoxOverlay";
            this.groupBoxOverlay.Size = new System.Drawing.Size(470, 224);
            this.groupBoxOverlay.TabIndex = 5;
            this.groupBoxOverlay.TabStop = false;
            this.groupBoxOverlay.Text = "Overlay";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(159, 113);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 1;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(234, 45);
            this.trackBarOpacity.TabIndex = 4;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 1;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // checkBoxShowOverlayButtons
            // 
            this.checkBoxShowOverlayButtons.AutoSize = true;
            this.checkBoxShowOverlayButtons.Checked = true;
            this.checkBoxShowOverlayButtons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowOverlayButtons.Location = new System.Drawing.Point(235, 193);
            this.checkBoxShowOverlayButtons.Name = "checkBoxShowOverlayButtons";
            this.checkBoxShowOverlayButtons.Size = new System.Drawing.Size(159, 16);
            this.checkBoxShowOverlayButtons.TabIndex = 3;
            this.checkBoxShowOverlayButtons.Text = "Show mini button controls.";
            this.checkBoxShowOverlayButtons.UseVisualStyleBackColor = true;
            this.checkBoxShowOverlayButtons.CheckedChanged += new System.EventHandler(this.checkBoxShowOverlayButtons_CheckedChanged);
            // 
            // checkBoxMoveOverlayByDrag
            // 
            this.checkBoxMoveOverlayByDrag.AutoSize = true;
            this.checkBoxMoveOverlayByDrag.Checked = true;
            this.checkBoxMoveOverlayByDrag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMoveOverlayByDrag.Location = new System.Drawing.Point(11, 193);
            this.checkBoxMoveOverlayByDrag.Name = "checkBoxMoveOverlayByDrag";
            this.checkBoxMoveOverlayByDrag.Size = new System.Drawing.Size(233, 16);
            this.checkBoxMoveOverlayByDrag.TabIndex = 3;
            this.checkBoxMoveOverlayByDrag.Text = "Move by drag && right doubleclick to hide.";
            this.checkBoxMoveOverlayByDrag.UseVisualStyleBackColor = true;
            this.checkBoxMoveOverlayByDrag.CheckedChanged += new System.EventHandler(this.checkBoxMoveOverlayByDrag_CheckedChanged);
            // 
            // buttonFontSelect
            // 
            this.buttonFontSelect.Location = new System.Drawing.Point(375, 160);
            this.buttonFontSelect.Name = "buttonFontSelect";
            this.buttonFontSelect.Size = new System.Drawing.Size(85, 20);
            this.buttonFontSelect.TabIndex = 0;
            this.buttonFontSelect.Text = "Select Font";
            this.buttonFontSelect.UseVisualStyleBackColor = true;
            this.buttonFontSelect.Click += new System.EventHandler(this.buttonFontSelect_Click);
            // 
            // labelBar
            // 
            this.labelBar.AutoSize = true;
            this.labelBar.Location = new System.Drawing.Point(251, 82);
            this.labelBar.Name = "labelBar";
            this.labelBar.Size = new System.Drawing.Size(25, 12);
            this.labelBar.TabIndex = 2;
            this.labelBar.Text = "Bar:";
            this.labelBar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // udBarWidth
            // 
            this.udBarWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udBarWidth.Location = new System.Drawing.Point(286, 80);
            this.udBarWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udBarWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udBarWidth.Name = "udBarWidth";
            this.udBarWidth.Size = new System.Drawing.Size(80, 19);
            this.udBarWidth.TabIndex = 1;
            this.udBarWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udBarWidth.ValueChanged += new System.EventHandler(this.udBarWidth_ValueChanged);
            // 
            // udTextWidth
            // 
            this.udTextWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udTextWidth.Location = new System.Drawing.Point(159, 80);
            this.udTextWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udTextWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udTextWidth.Name = "udTextWidth";
            this.udTextWidth.Size = new System.Drawing.Size(80, 19);
            this.udTextWidth.TabIndex = 1;
            this.udTextWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udTextWidth.ValueChanged += new System.EventHandler(this.udTextWidth_ValueChanged);
            // 
            // labelCurrentFont
            // 
            this.labelCurrentFont.AutoSize = true;
            this.labelCurrentFont.Location = new System.Drawing.Point(45, 164);
            this.labelCurrentFont.Name = "labelCurrentFont";
            this.labelCurrentFont.Size = new System.Drawing.Size(85, 12);
            this.labelCurrentFont.TabIndex = 0;
            this.labelCurrentFont.Text = "CurrentFontInfo";
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(8, 164);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(30, 12);
            this.labelFont.TabIndex = 0;
            this.labelFont.Text = "Font:";
            // 
            // labelCurrOpacity
            // 
            this.labelCurrOpacity.AutoSize = true;
            this.labelCurrOpacity.Location = new System.Drawing.Point(399, 117);
            this.labelCurrOpacity.Name = "labelCurrOpacity";
            this.labelCurrOpacity.Size = new System.Drawing.Size(21, 12);
            this.labelCurrOpacity.TabIndex = 0;
            this.labelCurrOpacity.Text = "??%";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(8, 117);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(46, 12);
            this.labelOpacity.TabIndex = 0;
            this.labelOpacity.Text = "Opacity:";
            // 
            // groupBoxTracker
            // 
            this.groupBoxTracker.Controls.Add(this.labelSlash);
            this.groupBoxTracker.Controls.Add(this.buttonPause);
            this.groupBoxTracker.Controls.Add(this.buttonPlay);
            this.groupBoxTracker.Controls.Add(this.buttonRewind);
            this.groupBoxTracker.Controls.Add(this.labelEndPos);
            this.groupBoxTracker.Controls.Add(this.labelCurrPos);
            this.groupBoxTracker.Controls.Add(this.labelLoadedTimeline);
            this.groupBoxTracker.Controls.Add(this.labelLoadedTimelineLabel);
            this.groupBoxTracker.Controls.Add(this.trackBar);
            this.groupBoxTracker.Location = new System.Drawing.Point(15, 12);
            this.groupBoxTracker.Name = "groupBoxTracker";
            this.groupBoxTracker.Size = new System.Drawing.Size(470, 111);
            this.groupBoxTracker.TabIndex = 6;
            this.groupBoxTracker.TabStop = false;
            this.groupBoxTracker.Text = "Tracker";
            // 
            // labelSlash
            // 
            this.labelSlash.AutoSize = true;
            this.labelSlash.BackColor = System.Drawing.Color.Transparent;
            this.labelSlash.Location = new System.Drawing.Point(423, 36);
            this.labelSlash.Name = "labelSlash";
            this.labelSlash.Size = new System.Drawing.Size(11, 12);
            this.labelSlash.TabIndex = 4;
            this.labelSlash.Text = "/";
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(110, 77);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(57, 24);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(166, 77);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(57, 24);
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.Location = new System.Drawing.Point(10, 77);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(87, 24);
            this.buttonRewind.TabIndex = 5;
            this.buttonRewind.Text = "<< Rewind";
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // labelEndPos
            // 
            this.labelEndPos.AutoSize = true;
            this.labelEndPos.Location = new System.Drawing.Point(433, 43);
            this.labelEndPos.Name = "labelEndPos";
            this.labelEndPos.Size = new System.Drawing.Size(31, 12);
            this.labelEndPos.TabIndex = 3;
            this.labelEndPos.Text = "00:00";
            this.labelEndPos.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelCurrPos
            // 
            this.labelCurrPos.AutoSize = true;
            this.labelCurrPos.Location = new System.Drawing.Point(392, 28);
            this.labelCurrPos.Name = "labelCurrPos";
            this.labelCurrPos.Size = new System.Drawing.Size(31, 12);
            this.labelCurrPos.TabIndex = 3;
            this.labelCurrPos.Text = "00:00";
            // 
            // labelLoadedTimeline
            // 
            this.labelLoadedTimeline.AutoSize = true;
            this.labelLoadedTimeline.Location = new System.Drawing.Point(103, 15);
            this.labelLoadedTimeline.Name = "labelLoadedTimeline";
            this.labelLoadedTimeline.Size = new System.Drawing.Size(130, 12);
            this.labelLoadedTimeline.TabIndex = 2;
            this.labelLoadedTimeline.Text = "-- No active timeline --";
            // 
            // labelLoadedTimelineLabel
            // 
            this.labelLoadedTimelineLabel.AutoSize = true;
            this.labelLoadedTimelineLabel.Location = new System.Drawing.Point(9, 15);
            this.labelLoadedTimelineLabel.Name = "labelLoadedTimelineLabel";
            this.labelLoadedTimelineLabel.Size = new System.Drawing.Size(90, 12);
            this.labelLoadedTimelineLabel.TabIndex = 1;
            this.labelLoadedTimelineLabel.Text = "Loaded Timeline:";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(6, 36);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(388, 45);
            this.trackBar.TabIndex = 0;
            this.trackBar.TickFrequency = 30;
            this.trackBar.Scroll += new System.EventHandler(this.trackbar_Scroll);
            // 
            // groupBoxAutoLoader
            // 
            this.groupBoxAutoLoader.Controls.Add(this.checkBoxResetTimelineCombatEnd);
            this.groupBoxAutoLoader.Controls.Add(this.textBoxZonename);
            this.groupBoxAutoLoader.Controls.Add(this.labeltxt);
            this.groupBoxAutoLoader.Controls.Add(this.labelFindFilename);
            this.groupBoxAutoLoader.Controls.Add(this.checkBoxAutoHide);
            this.groupBoxAutoLoader.Controls.Add(this.checkBoxAutoloadAfterChangeZone);
            this.groupBoxAutoLoader.Controls.Add(this.checkBoxAutoShow);
            this.groupBoxAutoLoader.Location = new System.Drawing.Point(491, 10);
            this.groupBoxAutoLoader.Name = "groupBoxAutoLoader";
            this.groupBoxAutoLoader.Size = new System.Drawing.Size(278, 132);
            this.groupBoxAutoLoader.TabIndex = 7;
            this.groupBoxAutoLoader.TabStop = false;
            this.groupBoxAutoLoader.Text = "Autoload";
            // 
            // checkBoxResetTimelineCombatEnd
            // 
            this.checkBoxResetTimelineCombatEnd.AutoSize = true;
            this.checkBoxResetTimelineCombatEnd.Location = new System.Drawing.Point(9, 108);
            this.checkBoxResetTimelineCombatEnd.Name = "checkBoxResetTimelineCombatEnd";
            this.checkBoxResetTimelineCombatEnd.Size = new System.Drawing.Size(178, 16);
            this.checkBoxResetTimelineCombatEnd.TabIndex = 10;
            this.checkBoxResetTimelineCombatEnd.Text = "Reset Timeline at combat end";
            this.checkBoxResetTimelineCombatEnd.UseVisualStyleBackColor = true;
            this.checkBoxResetTimelineCombatEnd.CheckedChanged += new System.EventHandler(this.checkBoxResetTimelineCombatEnd_CheckedChanged);
            // 
            // textBoxZonename
            // 
            this.textBoxZonename.Location = new System.Drawing.Point(6, 29);
            this.textBoxZonename.Name = "textBoxZonename";
            this.textBoxZonename.ReadOnly = true;
            this.textBoxZonename.Size = new System.Drawing.Size(229, 19);
            this.textBoxZonename.TabIndex = 7;
            // 
            // labeltxt
            // 
            this.labeltxt.AutoSize = true;
            this.labeltxt.Location = new System.Drawing.Point(241, 31);
            this.labeltxt.Name = "labeltxt";
            this.labeltxt.Size = new System.Drawing.Size(21, 12);
            this.labeltxt.TabIndex = 9;
            this.labeltxt.Text = ".txt";
            // 
            // labelFindFilename
            // 
            this.labelFindFilename.AutoSize = true;
            this.labelFindFilename.Location = new System.Drawing.Point(7, 17);
            this.labelFindFilename.Name = "labelFindFilename";
            this.labelFindFilename.Size = new System.Drawing.Size(77, 12);
            this.labelFindFilename.TabIndex = 8;
            this.labelFindFilename.Text = "Find Filename";
            // 
            // checkBoxAutoHide
            // 
            this.checkBoxAutoHide.AutoSize = true;
            this.checkBoxAutoHide.Location = new System.Drawing.Point(9, 88);
            this.checkBoxAutoHide.Name = "checkBoxAutoHide";
            this.checkBoxAutoHide.Size = new System.Drawing.Size(117, 16);
            this.checkBoxAutoHide.TabIndex = 6;
            this.checkBoxAutoHide.Text = "Auto hide timeline";
            this.checkBoxAutoHide.UseVisualStyleBackColor = true;
            this.checkBoxAutoHide.CheckedChanged += new System.EventHandler(this.checkBoxAutoHide_CheckedChanged);
            // 
            // checkBoxAutoloadAfterChangeZone
            // 
            this.checkBoxAutoloadAfterChangeZone.AutoSize = true;
            this.checkBoxAutoloadAfterChangeZone.Location = new System.Drawing.Point(9, 50);
            this.checkBoxAutoloadAfterChangeZone.Name = "checkBoxAutoloadAfterChangeZone";
            this.checkBoxAutoloadAfterChangeZone.Size = new System.Drawing.Size(164, 16);
            this.checkBoxAutoloadAfterChangeZone.TabIndex = 4;
            this.checkBoxAutoloadAfterChangeZone.Text = "Autoload after change zone";
            this.checkBoxAutoloadAfterChangeZone.UseVisualStyleBackColor = true;
            this.checkBoxAutoloadAfterChangeZone.CheckedChanged += new System.EventHandler(this.checkBoxAutoloadAfterChangeZone_CheckedChanged);
            // 
            // checkBoxAutoShow
            // 
            this.checkBoxAutoShow.AutoSize = true;
            this.checkBoxAutoShow.Location = new System.Drawing.Point(9, 69);
            this.checkBoxAutoShow.Name = "checkBoxAutoShow";
            this.checkBoxAutoShow.Size = new System.Drawing.Size(122, 16);
            this.checkBoxAutoShow.TabIndex = 5;
            this.checkBoxAutoShow.Text = "Auto show timeline";
            this.checkBoxAutoShow.UseVisualStyleBackColor = true;
            this.checkBoxAutoShow.CheckedChanged += new System.EventHandler(this.checkBoxAutoShow_CheckedChanged);
            // 
            // groupOverlayManage
            // 
            this.groupOverlayManage.Location = new System.Drawing.Point(491, 149);
            this.groupOverlayManage.Name = "groupOverlayManage";
            this.groupOverlayManage.Size = new System.Drawing.Size(278, 457);
            this.groupOverlayManage.TabIndex = 8;
            this.groupOverlayManage.TabStop = false;
            this.groupOverlayManage.Text = "OverlayManage";
            // 
            // ACTTabPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupOverlayManage);
            this.Controls.Add(this.groupBoxTracker);
            this.Controls.Add(this.groupBoxOverlay);
            this.Controls.Add(this.groupBoxTimelines);
            this.Controls.Add(this.groupBoxEnvironment);
            this.Controls.Add(this.groupBoxAutoLoader);
            this.Name = "ACTTabPageControl";
            this.Size = new System.Drawing.Size(784, 622);
            this.groupBoxEnvironment.ResumeLayout(false);
            this.groupBoxEnvironment.PerformLayout();
            this.groupBoxTimelines.ResumeLayout(false);
            this.groupBoxOverlay.ResumeLayout(false);
            this.groupBoxOverlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTextWidth)).EndInit();
            this.groupBoxTracker.ResumeLayout(false);
            this.groupBoxTracker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBoxAutoLoader.ResumeLayout(false);
            this.groupBoxAutoLoader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonResourceDirSelect;
        private System.Windows.Forms.TextBox textBoxResourceDir;
        private System.Windows.Forms.Label labelResourceDir;
        private System.Windows.Forms.GroupBox groupBoxEnvironment;
        private System.Windows.Forms.Button buttonResourceDirOpen;
        private System.Windows.Forms.GroupBox groupBoxTimelines;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ListBox listTimelines;
        private System.Windows.Forms.Button buttonRefreshList;
        private System.Windows.Forms.Label labelResourceDirStatus;
        private System.Windows.Forms.GroupBox groupBoxOverlay;
        private System.Windows.Forms.CheckBox checkBoxPlaySoundByACT;
        private System.Windows.Forms.GroupBox groupBoxTracker;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Label labelEndPos;
        private System.Windows.Forms.Label labelCurrPos;
        private System.Windows.Forms.Label labelSlash;
        private System.Windows.Forms.Label labelLoadedTimeline;
        private System.Windows.Forms.Label labelLoadedTimelineLabel;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.CheckBox checkBoxShowOverlayButtons;
        private System.Windows.Forms.Button buttonFontSelect;
        private System.Windows.Forms.Label labelCurrentFont;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelBar;
        private System.Windows.Forms.NumericUpDown udBarWidth;
        private System.Windows.Forms.NumericUpDown udTextWidth;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Label labelCurrOpacity;
        private System.Windows.Forms.CheckBox checkBoxMoveOverlayByDrag;
        private System.Windows.Forms.GroupBox groupBoxAutoLoader;
        private System.Windows.Forms.Label labelFindFilename;
        private System.Windows.Forms.TextBox textBoxZonename;
        private System.Windows.Forms.Label labeltxt;
        private System.Windows.Forms.CheckBox checkBoxAutoloadAfterChangeZone;
        private System.Windows.Forms.CheckBox checkBoxAutoShow;
        private System.Windows.Forms.CheckBox checkBoxAutoHide;
        private System.Windows.Forms.CheckBox checkBoxResetTimelineCombatEnd;
        private System.Windows.Forms.GroupBox groupOverlayManage;
    }
}
