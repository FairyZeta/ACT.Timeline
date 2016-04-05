using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Component;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Desing
{
    /// <summary> [画面デザイン用] タイムライン／タイムラインデータモデル
    /// </summary>
    public class Desing_TimelineComponent : TimelineComponent
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [画面デザイン用] タイムライン／タイムラインデータモデル／コンストラクタ
        /// </summary>
        public Desing_TimelineComponent()
            : base()
        {
            this.initComponent();
            this.createDesingData_P001();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンポーネントの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initComponent()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> デザイン用データ（パターン１）の生成
        /// </summary>
        private void createDesingData_P001()
        {
            for (int i = 0; i < 60.0 * 10; i++)
            {
                TimelineItemData item = new TimelineItemData();
                item.ActivityIndex = i;
                item.ActivityTime = this.TimelineCreateModule.DoubleToAdjustProcess.ToHalfAdjust(Convert.ToDouble(i)/10, 1);
                item.ActivityName = "デザイン＠" + item.ActivityTime.ToString();

                base.TimelineDataModel.TimelineItemCollection.Add(item);
            }
        }
    }
}
