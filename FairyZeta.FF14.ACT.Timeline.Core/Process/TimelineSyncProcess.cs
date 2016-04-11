using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process

{    /// <summary> タイムライン／シンク処理プロセス
    /// </summary>
    public class TimelineSyncProcess
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ジャンプ処理プロセス／コンストラクタ
        /// </summary>
        public TimelineSyncProcess()
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
            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログの内容からシンクに一致するデータがあるかを判定します。
        /// </summary>
        /// <param name="pSyncItemList"> シンクアイテムリスト </param>
        /// <param name="pTimerData"> 現在のタイマー情報 </param>
        /// <param name="pLogLine"> 判定するログ </param>
        /// <returns> 一致データがある場合は シンク対象データ を返却、ない場合は Null 返却</returns>
        public TimelineAnchorData SyncDecision(IList<TimelineAnchorData> pSyncItemList, TimerData pTimerData, string pLogLine)
        {
            var tmpList = pSyncItemList.Where(j => j.ActiveAt(pTimerData.CurrentCombatTime));
            foreach (var item in tmpList)
            {
                if(item.Regex.IsMatch(pLogLine)) 
                    return item;
            }

            return null;
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
    }
}
