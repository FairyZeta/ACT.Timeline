//-------------------------
// code by FairyZeta.
//-------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Commands;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Module;

namespace FairyZeta.FF14.ACT.Timeline.Core.Component
{
    /// <summary> タイムライン／タイムラインコンポーネント
    /// </summary>
    public class TimelineComponent : _Component
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- DataModels ---
        
        public TimelineDataModel TimelineDataModel { get; private set; }

        public TimerDataModel TimerDataModel { get; private set; }

        #endregion

        #region --- Modules ---

        public TimelineCreateModule TimelineCreateModule { get; private set; }

        public TimelineControlModule TimelineControlModule { get; private set; }

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

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインコンポーネント／コンストラクタ
        /// </summary>
        public TimelineComponent(CommonDataModel pCommonDataModel)
            : base(pCommonDataModel)
        {
            this.initComponent();

            this.TimelineControlModule.TimerSetup();
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
            this.TimelineControlModule = new TimelineControlModule(this.TimelineDataModel, this.TimerDataModel);

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void TimelineLoda()
        {
            return;
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
                    this.TimelineControlModule.ActTimerProcess.TimerStart();
                    break;
                case "Stop":
                    this.TimelineControlModule.ActTimerProcess.TimerStop();
                    break;
                case "Pause":
                    this.TimelineControlModule.ActTimerProcess.TimerStop();
                    break;
                case "ReBoot":
                    this.TimelineControlModule.ActTimerProcess.TimerReBoot();
                    break;
            }
        }
        #endregion 
    }
}
