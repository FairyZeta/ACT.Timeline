using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> タイムライン／アイテム解析プロセス
    /// </summary>
    public class TimelineItemAnalyzProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アイテム種別解析プロセス／コンストラクタ
        /// </summary>
        public TimelineItemAnalyzProcess()
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

        #region --- Set Data -----

        /// <summary> タイムラインアイテムを解析し、データにタイムラインタイプを設定します。
        /// </summary>
        /// <param name="pTimelineItemD"> 解析と設定を実行するデータ </param>
        public void SetTimelineType(TimelineActivityData pTimelineActivityD)
        {
            pTimelineActivityD.TimelineType = this.TimelineTypeAnalyz(pTimelineActivityD.Name);
        }

        /// <summary> タイムラインアイテムを解析し、データにタイムラインジョブを設定します。
        /// </summary>
        /// <param name="pTimelineItemD"> 解析と設定を実行するデータ </param>
        public void SetTimelineJob(TimelineActivityData pTimelineActivityD)
        {
            pTimelineActivityD.JobType = this.JobAnalyz(pTimelineActivityD.Name);
        }

        #endregion

        #region --- Analyz -----

        /// <summary> 文字列を解析し、対応するTymelineTypeのEnum値を返却します。
        /// </summary>
        /// <param name="pTimelineItemD"> 解析する文字列 </param>
        public TimelineType TimelineTypeAnalyz(string pStr)
        {
            if (pStr.IndexOf("[T]") > -1) return TimelineType.TANK;
            if (pStr.IndexOf("[H]") > -1) return TimelineType.HEALER;
            if (pStr.IndexOf("[D]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[G]") > -1) return TimelineType.GIMMICK;

            if (pStr.IndexOf("[PLD]") > -1) return TimelineType.TANK;
            if (pStr.IndexOf("[WAR]") > -1) return TimelineType.TANK;
            // 暗黒の呼び名が安定しないので両方ひっかける
            if (pStr.IndexOf("[DKN]") > -1) return TimelineType.TANK;
            //if (pStr.IndexOf("[DRK]") > -1) return TimelineType.TANK;

            if (pStr.IndexOf("[MNK]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[DRG]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[BRD]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[NIN]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[BLM]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[SMN]") > -1) return TimelineType.DPS;
            if (pStr.IndexOf("[MCN]") > -1) return TimelineType.DPS;
            
            if (pStr.IndexOf("[WHM]") > -1) return TimelineType.HEALER;
            if (pStr.IndexOf("[SCH]") > -1) return TimelineType.HEALER;
            if (pStr.IndexOf("[AST]") > -1) return TimelineType.HEALER;

            if (pStr.IndexOf("[EGI]") > -1) return TimelineType.PET;
            if (pStr.IndexOf("[FAIRY]") > -1) return TimelineType.PET;
            if (pStr.IndexOf("[TURRET]") > -1) return TimelineType.PET;
            
            return TimelineType.ENEMY;
        }

        /// <summary> 文字列を解析し、対応するJobのEnum値を返却します。
        /// </summary>
        /// <param name="pTimelineItemD"> 解析する文字列 </param>
        public Job JobAnalyz(string pStr)
        {
            if (pStr.IndexOf("[T]") > -1) return Job.NON;
            if (pStr.IndexOf("[H]") > -1) return Job.NON;
            if (pStr.IndexOf("[D]") > -1) return Job.NON;
            if (pStr.IndexOf("[G]") > -1) return Job.NON;

            if (pStr.IndexOf("[PLD]") > -1) return Job.PLD;
            if (pStr.IndexOf("[WAR]") > -1) return Job.WAR;
            // 暗黒の呼び名が安定しないので両方ひっかける
            if (pStr.IndexOf("[DKN]") > -1) return Job.DKN;
            //if (pStr.IndexOf("[DRK]") > -1) return Job.DKN;
            
            if (pStr.IndexOf("[MNK]") > -1) return Job.MNK;
            if (pStr.IndexOf("[DRG]") > -1) return Job.DRG;
            if (pStr.IndexOf("[BRD]") > -1) return Job.BRD;
            if (pStr.IndexOf("[NIN]") > -1) return Job.NIN;
            if (pStr.IndexOf("[BLM]") > -1) return Job.BLM;
            if (pStr.IndexOf("[SMN]") > -1) return Job.SMN;
            if (pStr.IndexOf("[MCN]") > -1) return Job.MCN;

            if (pStr.IndexOf("[WHM]") > -1) return Job.WHM;
            if (pStr.IndexOf("[SCH]") > -1) return Job.SCH;
            if (pStr.IndexOf("[AST]") > -1) return Job.AST;

            if (pStr.IndexOf("[EGI]") > -1) return Job.EGI;
            if (pStr.IndexOf("[FAIRY]") > -1) return Job.FAIRY;
            if (pStr.IndexOf("[TURRET]") > -1) return Job.TURRET;

            return Job.NON;
        }

        #endregion

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
