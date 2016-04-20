using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Data;
using FairyZeta.FF14.ACT.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.ObjectModel
{
    /// <summary> タイムライン／アラートオブジェクトモデル
    /// </summary>
    public class TimelineAlertObjectModel : IComparable<TimelineAlertObjectModel>, IAlertSoundIO
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> このサウンドの開始時間
        /// </summary>
        public double TimeFromStart
        {
            get { return Activity.TimeFromStart - ReminderTimeOffset; }
        }

        /// <summary> アラートサウンドデータ
        /// </summary>
        public AlertSoundData AlertSoundData { get; set; }

        /// <summary> このサウンドの再生状態
        /// <para> => 再生済: True, 未再生: False  </para>
        /// </summary>
        public bool Processed { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アラートオブジェクトモデル／コンストラクタ
        /// </summary>
        public TimelineAlertObjectModel()
        {
            this.initObjectModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.Processed = false;
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        public double ReminderTimeOffset { get; set; }
        public TimelineActivityData Activity { get; set; }

        public int CompareTo(TimelineAlertObjectModel other)
        {
            return TimeFromStart.CompareTo(other.TimeFromStart);
        }
    }
}
