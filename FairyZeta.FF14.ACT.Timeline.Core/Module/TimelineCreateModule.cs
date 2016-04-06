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

            decimal endTime = Convert.ToDecimal(pBaseData.EndTime);
            for (decimal d = 0; d < endTime; d += (decimal)0.1)
            {
                TimelineItemData item = new TimelineItemData();
                item.ActivityIndex = Convert.ToInt32(d * 10);
                item.ActivityNo = d;

                pDataModel.TimelineItemCollection.Add(item);
            }

            foreach (var data in pBaseData.Items)
            {
                var target = pDataModel.TimelineItemCollection.FirstOrDefault(item => item.ActivityNo == Convert.ToDecimal(this.DoubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1)));
                if (target != null)
                {
                    target.ActiveTime = target.ActivityNo;
                    target.ActivityName = data.Name;
                    target.Duration = Convert.ToDecimal(data.Duration);
                    target.Jump = Convert.ToDecimal(data.Jump);
                    target.Visibility = true;
                    target.TimelineType = TimelineType.ENEMY;
                    target.ActivityTime = new TimeSpan(0, 0, Convert.ToInt32(target.EndTime));

                    target.ActiveIndicatorStartTime = target.ActiveTime - Convert.ToDecimal(target.ActiveIndicatorMaxValue);
                    target.DurationIndicatorMaxValue = data.Duration;
                    if(target.DurationIndicatorMaxValue > 0)
                    {
                        target.DurationIndicatorVisibility = true;
                    }


                    if(target.ActivityName.IndexOf("[T]") > -1)
                    {
                        target.TimelineType = TimelineType.TANK;
                    }
                    else if (target.ActivityName.IndexOf("[H]") > -1)
                    {
                        target.TimelineType = TimelineType.HEALER;
                    }
                    else if (target.ActivityName.IndexOf("[D]") > -1)
                    {
                        target.TimelineType = TimelineType.DPS;
                    }


                }
            }

            foreach (var data in pBaseData.Alerts)
            {
                var targt = pDataModel.TimelineItemCollection.FirstOrDefault(item => item.ActivityNo == Convert.ToDecimal(this.DoubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1)));
                if(targt != null)
                {
                    targt.ActivityAlert = data;
                }
            }

            var activeItems = pDataModel.TimelineItemCollection.Where(i => !string.IsNullOrWhiteSpace(i.ActivityName));
            foreach (var item in activeItems)
            {
                pDataModel.TimelineActiveItemCollection.Add(item);
            }

            pDataModel.TimelineItemViewSource.View.Refresh();
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
