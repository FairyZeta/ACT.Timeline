using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Diagnostics;
using FairyZeta.FF14.ACT.DataModel;
using FairyZeta.FF14.ACT.Process;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムライン操作モジュール
    /// </summary>
    public class TimelineControlModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインメインタイマー
        /// </summary>
        public DispatcherTimer CurrentCombatTimer { get; set; }

        private Stopwatch stopwatch;

        public RelativeClock RelativeClock { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムライン操作モジュール
        /// </summary>
        public TimelineControlModule()
            : base()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.CurrentCombatTimer = new DispatcherTimer();
            this.RelativeClock = new RelativeClock();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイマーのセットアップを実行します。
        /// </summary>
        public void TimerSetup(Action act)
        {
            this.CurrentCombatTimer.Interval = TimeSpan.FromMilliseconds(100);
        }
        
        /// <summary> タイマー処理を開始します。
        /// </summary>
        public void TimerStart(CommonDataModel pCommonDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Stop:
                    this.RelativeClock.CurrentTime = 0;
                    break;
                case TimerStatus.Pause:
                    break;
                case TimerStatus.Run:
                    return;
            }

            this.CurrentCombatTimer.Start();
            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Run;
        }

        /// <summary> タイマー処理を停止します。
        /// </summary>
        public void TimerStop(CommonDataModel pCommonDM, TimerDataModel pTimerDM, TimelineDataModel pTimelineDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                    return;
                case TimerStatus.Run:
                    break;
            }

            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Stop;
            this.CurrentCombatTimer.Stop();
            this.RelativeClock.CurrentTime = 0;

            pTimerDM.TimerDeta.CurrentCombatTime = pTimerDM.TimerDeta.CurrentCombatStartTime;

            foreach (var item in pTimelineDM.TimelineItemCollection)
            {
                item.ViewReflesh();
            }
        }

        /// <summary> タイマーを一時停止します。
        /// </summary>
        public void TimerPause(CommonDataModel pCommonDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                    return;
                case TimerStatus.Run:
                    break;
            }

            this.CurrentCombatTimer.Stop();
            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Pause;
        }

        /// <summary> タイマーをリブートします。
        /// </summary>
        public void TimerReboot(CommonDataModel pCommonDM, TimerDataModel pTimerDM, TimelineDataModel pTimelineDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                case TimerStatus.Run:
                    break;
            }

            this.TimerStop(pCommonDM, pTimerDM, pTimelineDM);

            this.TimerStart(pCommonDM);
        }

        //private double const upDateTime = Math.Round(0.1);

        /// <summary> 戦闘時間が進む時の処理を実行します。
        /// </summary>
        /// <param name="pTimerDataModel"></param>
        /// <param name="pTimelineDataModel"></param>
        public void CombatTimeTick(CommonDataModel pCommonDM, TimerDataModel pTimerDataModel, TimelineDataModel pTimelineDataModel)
        {
            if (pCommonDM.AppStatusData.CurrentCombatTimerStatus != TimerStatus.Run) return;

            pTimerDataModel.TimerDeta.CurrentCombatTime = this.RelativeClock.CurrentTime;

            foreach (var item in pTimelineDataModel.TimelineItemCollection)
            {
                item.ViewReflesh();
            }

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
