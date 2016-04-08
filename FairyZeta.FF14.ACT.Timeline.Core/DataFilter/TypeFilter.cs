using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataFilter
{
    /// <summary> タイムライン／タイプフィルタ
    /// </summary>
    public class TypeFilter : _DataFilter
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／ジョブフィルタ／コンストラクタ
        /// </summary>
        public TypeFilter()
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

        /// <summary> TimelineType.UNKNOWNを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeUNKNOWN(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.UNKNOWN);
            return;
        }

        /// <summary> TimelineType.ENEMYを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeENEMY(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.ENEMY);
            return;
        }

        /// <summary> TimelineType.TANKを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeTANK(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.TANK);
            return;
        }

        /// <summary> TimelineType.DPSを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeDPS(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.DPS);
            return;
        }

        /// <summary> TimelineType.HEALERを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeHEALER(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.HEALER);
            return;
        }

        /// <summary> TimelineType.PETを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypePET(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.PET);
            return;
        }

        /// <summary> TimelineType.GIMMICKを非表示にします。
        /// </summary>
        /// <param name="sender"> 対象オブジェクト </param>
        /// <param name="e"> フィルターイベント </param>
        public void Filter_TypeGIMMICK(object sender, FilterEventArgs e)
        {
            this.setTypeFilter(e, TimelineType.GIMMICK);
            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> パラメータ指定されたTimelineTypeのアイテムを非表示にします。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="pTimelineType"></param>
        private void setTypeFilter(FilterEventArgs e, TimelineType pTimelineType)
        {
            if (e.Accepted == false) return;

            var data = e.Item as TimelineItemData;
            if (data == null || data.TimelineType != pTimelineType) return;

            e.Accepted = false;

            return;
        }
    }
}
