using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using IntervalTree;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    using TimelineInterval = IntervalTree.Interval<double>;

    /// <summary> タイムライン／シンクアイテムデータ
    /// </summary>
    public class TimelineSyncItemData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        //public double WindowBefore { get; set; }
        public double WindowBefore { get; set; }
        public double WindowAfter { get; set; }

        public TimelineInterval Interval
        {
            get
            {
                return new TimelineInterval(this.SyncToTime - WindowBefore, this.SyncToTime + WindowAfter);
            }
        }

        public const double DefaultWindow = 5.0;


        /// <summary> シンクの有効状態
        /// </summary>
        public bool SyncEnabled { get; set; }

        /// <summary> シンク先の時間
        /// </summary>
        //public double TimeFromStart { get; set; }
        public double SyncToTime { get; set; }
        
        /// <summary> シンクキーワード
        /// </summary>
        //public Regex Regex { get; set; }
        public Regex SyncKey { get; set; }

        //public double Jump { get; set; }
        //public double Window
        //{
        //    set
        //    {
        //        WindowBefore = value / 2;
        //        WindowAfter = value / 2;
        //    }
        //}

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／シンクアイテムデータ
        /// </summary>
        public TimelineSyncItemData()
            : base()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
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

        /// <summary> シンクの有効範囲でbool値を返す
        /// </summary>
        /// <param name="t">  現在の時間 </param>
        /// <returns></returns>
        public bool ActiveAt(double t)
        {
            return (this.SyncToTime - WindowBefore) < t && t < (this.SyncToTime + WindowAfter);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            this.SyncEnabled = false;
            this.SyncToTime = 0.0;
            this.SyncKey = null;

            return true;
        }

    }
}
