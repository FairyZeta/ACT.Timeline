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
        public TimerDataModel TimerDataModel { get; private set; }

        /// <summary> ACT汎用タイマープロセス
        /// </summary>
        public ActTimerProcess ActTimerProcess { get; private set; }

        public TimelineDataModel TimelineDataModel { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムライン操作モジュール
        /// </summary>
        public TimelineControlModule(TimelineDataModel pDataModel)
            : base()
        {
            this.TimelineDataModel = pDataModel;

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
            this.TimerDataModel = new TimerDataModel();

            this.TimerDataModel.TimerAutoReset = true;
            this.TimerDataModel.TimerInterval = 100.0;
            this.TimerDataModel.TimerEvent = this.TimerEvent;

            this.ActTimerProcess.TimerSetup(this.TimerDataModel);

        }
        
        public void TimerEvent(object o, ElapsedEventArgs e)
        {
            this.TimelineTimerTick(this.TimelineDataModel);
        }

        /// <summary> タイムラインの0.1秒単位の処理を実行します。
        /// </summary>
        public void TimelineTimerTick(TimelineDataModel pDataModel)
        {
            foreach (var item in pDataModel.TimelineActiveItemCollection)
            {
                if (!item.Visibility) continue;

                item.ActiveTime -= (decimal)0.1;

                if(item.ActiveTime <= 0) item.Visibility = false;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
