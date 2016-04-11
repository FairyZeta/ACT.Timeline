using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／シンクロ処理プロセス
    /// </summary>
    public class TimelineSynchroProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／シンクロ処理プロセス／コンストラクタ
        /// </summary>
        public TimelineSynchroProcess()
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

        /// <summary> ログの内容からjumpまたはsyncに一致するデータがあるかを判定します。
        /// </summary>
        /// <param name="pJumpItemList"> 判定用アイテムリスト </param>
        /// <param name="pTimerData"> 現在のタイマー情報 </param>
        /// <param name="pLogLine"> 判定するログ </param>
        /// <returns> 一致データがある場合は 対象データ, ない場合は Null </returns>
        public TimelineAnchorData SynchronizeDecision(IList<TimelineAnchorData> pItemList, TimerData pTimerData, string pLogLine)
        {
            var jumplist = pItemList.Where(j => j.ActiveAt(pTimerData.CurrentCombatTime));
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
