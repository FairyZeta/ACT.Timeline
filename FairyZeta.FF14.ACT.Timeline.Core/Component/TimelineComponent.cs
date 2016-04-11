
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Commands;
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

            // タイマーセットアップ
            //this.TimelineControlModule.TimerSetup();
            this.TimelineControlModule.CurrentCombatTimer.Tick += new EventHandler(this.TimelineTimerTickEvent);
            //this.TimelineControlModule.CurrentCombatTimer.Elapsed += new System.Timers.ElapsedEventHandler();

            // ACTイベント登録
            if (ActGlobals.oFormActMain != null)
            {
                ActGlobals.oFormActMain.OnCombatEnd += ActEvent_CombatEnd;
                ActGlobals.oFormActMain.OnLogLineRead += ActEvent_OnLogLineRead;
            }
        }


      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            this.TimelineDataModel = new TimelineDataModel();
            this.TimerDataModel = new TimerDataModel();

            this.TimelineCreateModule = new TimelineCreateModule();
            this.TimelineControlModule = new TimelineControlModule();
            this.TimelineLogAnalyzerModule = new TimelineLogAnalyzerModule();

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
        private void ActEvent_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            //if (isImport || timeline == null) return;

            string line = logInfo.logLine;

            // ジャンプとシンクの判定
            this.TimelineLogAnalyzerModule.JumpSyncAnalayz(this.TimelineDataModel, this.TimerDataModel, line);
            //this.TimelineLogAnalyzerModule.JumpAnalayz(this.TimelineDataModel, this.TimerDataModel, line);
            //this.TimelineLogAnalyzerModule.SyncAnalayz(this.TimelineDataModel, this.TimerDataModel, line);

            //TimelineAnchor anchor = timeline.FindAnchorMatchingLogline(CurrentTime, logInfo.logLine);
            if (this.TimelineDataModel.JumpSyncAnchorData != null)
            {
                // ジャンプ
                if (this.TimelineDataModel.JumpSyncAnchorData.Jump >= 0)
                {
                    if (this.TimelineDataModel.JumpSyncAnchorData.Jump == 0)
                    {
                        // 自動終了
                        this.TimelineControlModule.TimerStop(this.CommonDataModel, this.TimerDataModel, this.TimelineDataModel);
                    }
                    else
                    {
                        // 通常ジャンプ
                        this.TimelineControlModule.RelativeClock.CurrentTime = this.TimelineDataModel.JumpSyncAnchorData.TimeFromStart;
                    }
                }
                // シンク
                else
                {
                    // 自動開始判定
                    if (this.CommonDataModel.AppStatusData.CurrentCombatTimerStatus != TimerStatus.Run)
                    {
                        this.TimelineControlModule.TimerStart(this.CommonDataModel);
                        this.TimelineControlModule.RelativeClock.CurrentTime = this.TimelineDataModel.JumpSyncAnchorData.TimeFromStart;
                    }
                    // 通常シンク
                    else
                    {
                        this.TimelineControlModule.RelativeClock.CurrentTime = this.TimelineDataModel.JumpSyncAnchorData.TimeFromStart;
                    }
                }
            }
            //if(this.TimelineDataModel.SyncTargetData != null)
            {
            }
        }

        /// <summary> 戦闘終了時に実行される処理を定義します。
        /// </summary>
        /// <param name="isImport"></param>
        /// <param name="encounterInfo"></param>
        public void ActEvent_CombatEnd(bool isImport, CombatToggleEventArgs encounterInfo)
        {
            if (!isImport && Globals.ResetTimelineCombatEnd)
            {
            //    Controller.Paused = true;
            //    Controller.CurrentTime = 0;
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
                    this.TimelineControlModule.TimerStart(this.CommonDataModel);
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
