using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／ログアナライザーモジュール
    /// </summary>
    public class TimelineLogAnalyzerModule
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> シンクロ処理プロセス
        /// </summary>
        private TimelineSynchroProcess timelineSynchroProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
            
        /// <summary> タイムライン／ログアナライザーモジュール
        /// </summary>
        public TimelineLogAnalyzerModule()
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
            this.timelineSynchroProcess = new TimelineSynchroProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ジャンプまたはシンクが発生しているかどうかをログの内容から判定し、データモデルに格納します。
        /// </summary>
        /// <param name="pTimelineDataModel"> タイムラインデータモデル </param>
        /// <param name="pTimerDataModel"> タイマーデータモデル </param>
        /// <param name="pLogLine"> ログ </param>
        public void JumpSyncAnalayz(TimelineDataModel pTimelineDataModel, TimerDataModel pTimerDataModel, string pLogLine)
        {
            pTimelineDataModel.SynchroAnchorData = this.timelineSynchroProcess.SynchronizeDecision(pTimelineDataModel.TimelineAnchorDataCollection, pTimerDataModel.TimerDeta, pLogLine);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
