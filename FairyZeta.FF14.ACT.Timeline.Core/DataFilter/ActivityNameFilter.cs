using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataFilter
{
    /// <summary> タイムライン／データフィルタ／アクティビティ名フィルタ
    /// </summary>
    public class ActivityNameFilter
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／データフィルタ／アクティビティ名フィルタ／コンストラクタ
        /// </summary>
        public ActivityNameFilter()
            : base()
        {
            this.initFilter();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> フィルタの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initFilter()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> TimelineItemDataのActivityNameにより、表示と非表示を切り分けます。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_ActivityNonName(object sender, FilterEventArgs e)
        {
            e.Accepted = false;

            var data = e.Item as TimelineItemData;
            if (data != null && !string.IsNullOrWhiteSpace(data.ActivityName))
            {
                e.Accepted = true;
            }

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
