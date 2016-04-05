using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムラインデータ生成モジュール
    /// </summary>
    public class TimelineCreateModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- Proccess ---

        /// <summary> [Util] double処理用プロセス
        /// </summary>
        public DoubleToAdjustProcess DoubleToAdjustProcess { get; private set; }

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインデータ生成モジュール／コンストラクタ
        /// </summary>
        public TimelineCreateModule()
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
            this.DoubleToAdjustProcess = new DoubleToAdjustProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public void CreateTimelineDataModel(TimelineBaseData pBaseData, TimelineDataModel pDataModel)
        {
            pDataModel.Timeline = pBaseData;

            if (pBaseData.Items.Count() == 0) return;

            for (double d = 0; d < pBaseData.EndTime; d += (double)0.1)
            {
                TimelineItemData item = new TimelineItemData();
                item.ActivityIndex = Convert.ToInt32(d * 10);
                item.ActivityTime = this.DoubleToAdjustProcess.ToHalfAdjust(d,1);

                pDataModel.TimelineItemCollection.Add(item);
            }

            foreach (var data in pBaseData.Items)
            {
                var target = pDataModel.TimelineItemCollection.FirstOrDefault(item => item.ActivityTime == this.DoubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1));
                if (target != null)
                {
                    target.ActivityName = data.Name;
                }

            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
