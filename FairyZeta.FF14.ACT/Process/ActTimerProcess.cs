using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FairyZeta.FF14.ACT.DataModel;

namespace FairyZeta.FF14.ACT.Process
{
    /// <summary> ACT共通／汎用タイマープロセス
    /// </summary>
    public class ActTimerProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT用汎用タイマー
        /// </summary>
        public Timer ActCommonTimer { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT共通／汎用タイマープロセス／コンストラクタ
        /// </summary>
        public ActTimerProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            this.ActCommonTimer = new Timer();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 汎用タイマーのセッティングを実行します。
        /// </summary>
        /// <param name="pTimerDataModel"></param>
        public void TimerSetup(TimerDataModel pTimerDataModel)
        {
            this.ActCommonTimer.AutoReset = pTimerDataModel.TimerAutoReset;
            this.ActCommonTimer.Interval = pTimerDataModel.TimerInterval;
            this.ActCommonTimer.Elapsed += pTimerDataModel.TimerEvent;
        }

        /// <summary> タイマーを開始します。
        /// </summary>
        public void TimerStart()
        {
            this.ActCommonTimer.Enabled = true;
            this.ActCommonTimer.Start();
        }

        /// <summary> タイマーを停止します。
        /// </summary>
        public void TimerStop()
        {
            this.ActCommonTimer.Enabled = false;
            this.ActCommonTimer.Stop();
        }

        /// <summary> タイマーをリブート（停止=>開始）します。
        /// </summary>
        public void TimerReBoot()
        {
            this.TimerStop();
            this.TimerStart();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
