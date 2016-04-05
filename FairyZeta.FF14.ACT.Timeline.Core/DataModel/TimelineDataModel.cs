using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataFilter;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／タイムラインデータモデル
    /// </summary>
    public class TimelineDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 現在のタイムラインアイテム
        /// </summary>
        public TimelineBaseData Timeline { get; set; }

        /// <summary> タイムラインアイテムコレクション
        /// </summary>
        public ObservableCollection<TimelineItemData> TimelineItemCollection { get; private set; }

        /// <summary> 画面表示用タイムラインビューソース
        /// </summary>
        public CollectionViewSource TimelineItemViewSource { get; private set; }

        public ActivityNameFilter ActivityNameFilter { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインデータモデル
        /// </summary>
        public TimelineDataModel()
        {
            this.initDataModel();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.TimelineItemCollection = new ObservableCollection<TimelineItemData>();
            this.TimelineItemViewSource = new CollectionViewSource() { Source = this.TimelineItemCollection };

            this.ActivityNameFilter = new ActivityNameFilter();
            this.TimelineItemViewSource.Filter += new FilterEventHandler(this.ActivityNameFilter.Filter_ActivityNonName);
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            base.Clear();
            this.clear();

            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.TimelineItemCollection.Clear();

            return true;
        }
    }
}
