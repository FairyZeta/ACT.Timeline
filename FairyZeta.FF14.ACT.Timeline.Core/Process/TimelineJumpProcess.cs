using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／ジャンプ処理プロセス
    /// </summary>
    public class TimelineJumpProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ジャンプ処理プロセス／コンストラクタ
        /// </summary>
        public TimelineJumpProcess()
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


        /// <summary> ログの内容からジャンプまたはに一致するデータがあるかを判定します。
        /// </summary>
        /// <param name="pJumpItemList"> ジャンプアイテムリスト </param>
        /// <param name="pTimerData"> 現在のタイマー情報 </param>
        /// <param name="pLogLine"> 判定するログ </param>
        /// <returns> 一致データがある場合は ジャンプ対象データ を返却、ない場合は Null 返却</returns>
        public TimelineAnchorData JumpSyncDecision(IList<TimelineAnchorData> pItemList, TimerData pTimerData, string pLogLine)
        {
            var jumplist = pItemList.Where(j => j.ActiveAt(pTimerData.CurrentCombatTime));
            foreach (var item in jumplist)
            {
                if (item.Regex.IsMatch(pLogLine))
                    return item;
            }

            return null;
        }

        /// <summary> ログの内容からジャンプに一致するデータがあるかを判定します。
        /// </summary>
        /// <param name="pJumpItemList"> ジャンプアイテムリスト </param>
        /// <param name="pTimerData"> 現在のタイマー情報 </param>
        /// <param name="pLogLine"> 判定するログ </param>
        /// <returns> 一致データがある場合は ジャンプ対象データ を返却、ない場合は Null 返却</returns>
        public TimelineAnchorData JumpDecision(IList<TimelineAnchorData> pJumpItemList, TimerData pTimerData, string pLogLine)
        {
            var jumplist = pJumpItemList.Where(j => j.ActiveAt(pTimerData.CurrentCombatTime));
            foreach (var item in jumplist)
            {
                if (item.Regex.IsMatch(pLogLine))
                    return item;
            }

            return null;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
