using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FairyZeta.FF14.ACT.DataModel;
using FairyZeta.FF14.ACT.Process;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムライン操作モジュール
    /// </summary>
    public class TimelineControlModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT汎用タイマー用データモデル
        /// </summary>
        public TimerSetDataModel TimerSetDataModel { get; private set; }

        /// <summary> ACT汎用タイマープロセス
        /// </summary>
        public ActTimerProcess ActTimerProcess { get; private set; }

        private TimerDataModel timerDetaModel;
        private TimelineDataModel timelineDataModel;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムライン操作モジュール
        /// </summary>
        public TimelineControlModule(TimelineDataModel pTimelineDataModel, TimerDataModel pTimerDataModel)
            : base()
        {
            this.timelineDataModel = pTimelineDataModel;
            this.timerDetaModel = pTimerDataModel;

            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.ActTimerProcess = new ActTimerProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void TimerSetup()
        {
            this.TimerSetDataModel = new TimerSetDataModel();

            this.TimerSetDataModel.TimerAutoReset = true;
            this.TimerSetDataModel.TimerInterval = 100.0;
            this.TimerSetDataModel.TimerEvent = this.TimerEvent;

            this.ActTimerProcess.TimerSetup(this.TimerSetDataModel);

        }
        
        public void TimerEvent(object o, ElapsedEventArgs e)
        {
            this.TimelineTimerTick(this.timelineDataModel, this.timerDetaModel);
        }

        /// <summary> タイムラインの0.1秒単位の処理を実行します。
        /// </summary>
        public void TimelineTimerTick(TimelineDataModel pTimelineDataModel, TimerDataModel pTimerDataModel)
        {
            pTimerDataModel.TimerDeta.MainTimerTime += (decimal)0.1;

            foreach (var item in pTimelineDataModel.TimelineItemCollection)
            {
                if (!item.Visibility) continue;

                item.ActiveTime -= (decimal)0.1;

                if(item.ActiveIndicatorStartTime < pTimerDataModel.TimerDeta.MainTimerTime)
                {
                    item.ActiveIndicatorValue += 0.1;
                }

                if(item.ActiveTime <= 0 && item.Duration > 0)
                {
                    item.ActiveIndicatorVisibility = false;
                    item.DurationIndicatorValue += 0.1;
                }

                if(item.ActiveTime <= (decimal)-2.0) item.Visibility = false;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
