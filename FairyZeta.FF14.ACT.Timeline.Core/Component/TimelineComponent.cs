using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Commands;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;
using Advanced_Combat_Tracker;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／タイムラインコンポーネント
    /// </summary>
    public class TimelineComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      #region --- DataModels ---
        
        /// <summary> タイムラインデータモデル
        /// </summary>
        public TimelineDataModel TimelineDataModel { get; private set; }
        /// <summary> タイマーデータモデル
        /// </summary>
        public TimerDataModel TimerDataModel { get; private set; }

      #endregion

      #region --- Modules ---

        public AppCommonModule AppCommonModule { get; private set; }

        public TimelineCreateModule TimelineCreateModule { get; private set; }

        public TimelineControlModule TimelineControlModule { get; private set; }

        /// <summary> タイムラインログ解析モジュール
        /// </summary>
        public TimelineLogAnalyzerModule TimelineLogAnalyzerModule { get; private set; }

      #endregion

      #region --- Commands ---

        #region #- [Command] DelegateCommand<TimerOperation>.TimerControlCommand - ＜タイマー操作コマンド＞ -----
        /// <summary> タイマー操作コマンド＜コマンド＞ </summary>
        private DelegateCommand<string> _TimerControlCommand;
        /// <summary> タイマー操作コマンド＜コマンド＞ </summary>
        public DelegateCommand<string> TimerControlCommand
        {
            get { return _TimerControlCommand = _TimerControlCommand ?? new DelegateCommand<string>(this._TimerControlExecute, this._CanTimerControlExecute); }
        }
        #endregion

        #region #- [Command] DelegateCommand.TimelineLoadCommand - ＜タイムラインロードコマンド＞ -----
        /// <summary> タイムラインロードコマンド＜コマンド＞ </summary>
        private DelegateCommand _TimelineLoadCommand;
        /// <summary> タイムラインロードコマンド＜コマンド＞ </summary>
        public DelegateCommand TimelineLoadCommand
        {
            get { return _TimelineLoadCommand = _TimelineLoadCommand ?? new DelegateCommand(this._TimelineLoadExecute, this._CanTimelineLoadExecute); }
        }
        #endregion 

      #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインコンポーネント／コンストラクタ
        /// </summary>
        public TimelineComponent(CommonDataModel pCommonDataModel)
            : base(pCommonDataModel)
        {
            this.initComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.AppCommonModule = new AppCommonModule();
            this.TimelineDataModel = new TimelineDataModel();
            this.TimerDataModel = new TimerDataModel();

            this.TimelineCreateModule = new TimelineCreateModule();
            this.TimelineControlModule = new TimelineControlModule();
            this.TimelineLogAnalyzerModule = new TimelineLogAnalyzerModule();

            return true;
        }

        /// <summary> コンポーネントのセットアップを実行します。
        /// </summary>
        /// <param name="pLastTimelineLoad"> 最後に読み込んだタイムラインをロードする場合 True </param>
        /// <returns> 正常終了時 True </returns>
        public bool SetupComponent(bool pLastTimelineLoad)
        {
            if (base.CommonDataModel == null) return false;

            // タイマーセットアップ
            this.TimelineControlModule.TimerSetup();
            this.TimelineControlModule.CurrentCombatTimer.Tick += new EventHandler(this.TimelineTimerTickEvent);

            // オートロードが有効かつプラグイン起動の場合、オートロード, 無効な場合、最終ロードファイルを読込
            if (this.CommonDataModel.PluginSettingsData.TimelineAutoLoadEnabled && ActGlobals.oFormActMain != null)
            {
                this.TimelineAutoLoadEvent(null, null);
            }
            else
            {
                this.CommonDataModel.SelectedTimelineFileData = new Data.TimelineFileData()
                {
                    TimelineFileName = this.CommonDataModel.PluginSettingsData.LastLoadTimelineFileName,
                    TimelineFileFullPath = System.IO.Path.Combine(this.CommonDataModel.PluginSettingsData.LastLoadTimelineFullPath)
                };
                this.TimelineCreateModule.CreateTimelineDataModel(this.CommonDataModel, this.TimelineDataModel, this.TimerDataModel);
                this.CommonDataModel.SelectedTimelineFileData = null;
            }


            return true;
        }

        /// <summary> 自動実行系の処理を開始します。
        /// </summary>
        /// <returns> 正常に開始した場合 True </returns>
        public bool AutoProcessStart()
        {
            // ACTイベント登録
            if (ActGlobals.oFormActMain != null)
            {
                ActGlobals.oFormActMain.OnCombatEnd += ActEvent_CombatEnd;
                ActGlobals.oFormActMain.OnLogLineRead += ActEvent_OnLogLineRead;
            }

            // タイムラインオートロードタイマー開始
            this.TimelineControlModule.AutoLoadTimer.Tick += new EventHandler(this.TimelineAutoLoadEvent);
            this.TimelineControlModule.AutoLoadTimer.Start();

            return true;
        }

        /// <summary> 自動実行系の処理を終了します。
        /// </summary>
        /// <returns> 正常に終了した場合 True </returns>
        public bool AutoProcessEnd()
        {
            // ACTイベント解除
            if (ActGlobals.oFormActMain != null)
            {
                ActGlobals.oFormActMain.OnCombatEnd -= ActEvent_CombatEnd;
                ActGlobals.oFormActMain.OnLogLineRead -= ActEvent_OnLogLineRead;
            }

            // タイムラインオートロードタイマー終了
            this.TimelineControlModule.AutoLoadTimer.Tick -= new EventHandler(this.TimelineAutoLoadEvent);
            this.TimelineControlModule.AutoLoadTimer.Stop();
            // 戦闘タイマーの強制終了
            this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
            this.TimelineControlModule.CurrentCombatTimer.Tick -= new EventHandler(this.TimelineTimerTickEvent);

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインロードを実行します。
        /// </summary>
        public void TimelineLoad()
        {
            if (this.CommonDataModel == null || this.CommonDataModel.SelectedTimelineFileData == null) return;
            this.TimelineCreateModule.CreateTimelineDataModel(base.CommonDataModel, this.TimelineDataModel, this.TimerDataModel);

            return;
        }


        /// <summary> タイムラインのタイマーイベントを実行します。
        /// </summary>
        public void TimelineTimerTickEvent(object sender, EventArgs e)
        {
            this.TimelineControlModule.CombatTimeTick(base.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
        }

        /// <summary> ACTログが発生した時の処理を定義します。
        /// </summary>
        /// <param name="isImport"></param>
        /// <param name="logInfo"></param>
        public void ActEvent_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (isImport) return;

            Task.Run(() => this.LogAnalyz(logInfo.logLine));
        }

        /// <summary> ログを解析してジャンプ／シンクの処理を実行します。
        /// </summary>
        /// <param name="pLine"></param>
        public void LogAnalyz(string pLine)
        {

            // ジャンプとシンクの判定
            this.TimelineLogAnalyzerModule.JumpSyncAnalayz(this.TimelineDataModel, this.TimerDataModel, pLine);

            if (this.TimelineDataModel.SynchroAnchorData != null)
            {
                // ジャンプ
                if (this.TimelineDataModel.SynchroAnchorData.Jump >= 0)
                {
                    if (this.TimelineDataModel.SynchroAnchorData.Jump == 0)
                    {
                        // 自動終了
                        this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                    }
                    else
                    {
                        // 通常ジャンプ
                        this.TimelineControlModule.CurrentCombatRelativeClock.CurrentTime = this.TimelineDataModel.SynchroAnchorData.TimeFromStart;
                    }
                }
                // シンク
                else
                {
                    // 自動開始判定
                    if (this.CommonDataModel.AppStatusData.CurrentCombatTimerStatus != TimerStatus.Run)
                    {
                        this.TimelineControlModule.TimerStart(this.CommonDataModel, this.TimerDataModel);
                        this.TimelineControlModule.CurrentCombatRelativeClock.CurrentTime = this.TimelineDataModel.SynchroAnchorData.TimeFromStart;
                    }
                    // 通常シンク
                    else
                    {
                        this.TimelineControlModule.CurrentCombatRelativeClock.CurrentTime = this.TimelineDataModel.SynchroAnchorData.TimeFromStart;
                    }
                }
            }
        }

        /// <summary> 戦闘終了時に実行される処理を定義します。
        /// </summary>
        /// <param name="isImport"></param>
        /// <param name="encounterInfo"></param>
        public void ActEvent_CombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (!isImport && this.CommonDataModel.PluginSettingsData.ResetTimelineCombatEndEnabled)
            {
                  this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                  this.TimelineControlModule.CurrentCombatRelativeClock.StopClock(0);
            }
        }

        /// <summary> [タイマー用] タイムラインオートロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimelineAutoLoadEvent(object sender, EventArgs e)
        {
            if (this.CommonDataModel.AppStatusData.AutoLoadStatus == TimelineLoadStatus.NowLoading) return;
            if (!this.CommonDataModel.PluginSettingsData.TimelineAutoLoadEnabled) return;
            if (ActGlobals.oFormActMain == null) return;

            var zonename = ActGlobals.oFormActMain.CurrentZone;
            if (zonename.Length == 0) return;

            if (this.CommonDataModel.LocationData.CurrentZoneName != zonename)
            {
                this.AppCommonModule.CheckTimelineResourceDirectory(this.CommonDataModel);
                this.AppCommonModule.CheckSoundResourceDirectory(this.CommonDataModel);

                Globals.SysLogger.WriteSystemLog.Success.INFO.Write(string.Format("Timeline AutoLoad Start. ( Zone = {0} )", zonename), Globals.ProjectName);
                this.CommonDataModel.AppStatusData.AutoLoadStatus = TimelineLoadStatus.NowLoading;

                var file = zonename;
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                {
                    file = file.Replace(c, '_');
                }

                List<string> findList = new List<string>();
                findList.Add(string.Format("{0}.txt", file));

                foreach (string findName in findList)
                {
                    var target = this.CommonDataModel.TimelineFileCollection.FirstOrDefault(f => f.TimelineFileName == findName);
                    if (target != null)
                    {
                        this.CommonDataModel.SelectedTimelineFileData = target;
                        this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                        this.TimelineCreateModule.CreateTimelineDataModel(base.CommonDataModel, this.TimelineDataModel, this.TimerDataModel);

                        if (this.CommonDataModel.PluginSettingsData.AutoShowTimelineEnabled)
                        {
                            this.CommonDataModel.PluginSettingsData.AllOverlayVisibility = true;
                            this.CommonDataModel.ViewRefresh();
                        }

                        this.CommonDataModel.LogDataCollection.Add(
                            Globals.SysLogger.WriteSystemLog.Success.INFO.Write(string.Format("Timeline AutoLoad Success. ( File = {0} )", findName, Globals.ProjectName)));
                        this.CommonDataModel.AppStatusData.AutoLoadStatus = TimelineLoadStatus.Success;
                        this.CommonDataModel.ViewRefresh();

                        break;
                    }
                    else
                    {
                        if (this.CommonDataModel.PluginSettingsData.AutoHideTimelineEnabled)
                        {
                            this.CommonDataModel.PluginSettingsData.AllOverlayVisibility = false;
                            this.CommonDataModel.ViewRefresh();
                        }

                        this.TimelineCreateModule.TimelineDataClear(this.CommonDataModel, this.TimelineDataModel, this.TimerDataModel);

                        this.CommonDataModel.LogDataCollection.Add(
                            Globals.SysLogger.WriteSystemLog.Failure.INFO.Write(string.Format("Timeline AutoLoad Failure. File Not Found. ( File = {0} )", findName), Globals.ProjectName));
                        this.CommonDataModel.LogDataCollection.Add(
                            Globals.SysLogger.WriteSystemLog.Failure.INFO.Write(string.Format("Timeline Unloaded."), Globals.ProjectName));
                        this.CommonDataModel.AppStatusData.AutoLoadStatus = TimelineLoadStatus.NotFoundTimeline;
                        this.CommonDataModel.ViewRefresh();
                    }
                }

                this.CommonDataModel.LocationData.CurrentZoneName = zonename;
            }

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


        #region #- [Method] CanExecute,Execute @ TimerControlCommand - ＜タイマー操作コマンド＞ -----
        /// <summary> 実行可能確認＜タイマー操作コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanTimerControlExecute(string para)
        {
            return true;
        }

        /// <summary> コマンド実行＜タイマー操作コマンド＞ </summary>
        /// <param name="para"> コマンドパラメーター </param>
        private void _TimerControlExecute(string para)
        {
            switch (para)
            {
                case "Start":
                    this.TimelineControlModule.TimerStart(this.CommonDataModel, this.TimerDataModel);
                    break;
                case "Stop":
                    this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                    break;
                case "Pause":
                    this.TimelineControlModule.TimerPause(this.CommonDataModel);
                    break;
                case "ReBoot":
                    this.TimelineControlModule.TimerReboot(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                    break;
            }
        }
        #endregion 

        
        #region #- [Method] CanExecute,Execute @ TimelineLoadCommand - ＜タイムラインロードコマンド＞ -----
        /// <summary> 実行可能確認＜タイムラインロードコマンド＞ </summary>
        /// <returns> 実行可能: ture / 実行不可能: false </returns>
        private bool _CanTimelineLoadExecute()
        {
            return true;
        }

        /// <summary> コマンド実行＜タイムラインロードコマンド＞ </summary>
        private void _TimelineLoadExecute()
        {
            this.TimelineLoad();
        }
        #endregion 
    }
}
