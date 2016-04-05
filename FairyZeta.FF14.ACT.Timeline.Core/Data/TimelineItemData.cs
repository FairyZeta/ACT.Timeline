using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／タイムラインアイテムデータ
    /// </summary>
    public class TimelineItemData : _Data
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] int.ActivityIndex - ＜アクティビティ番号＞ -----
        /// <summary> アクティビティ番号 </summary>
        private int _ActivityIndex;
        /// <summary> アクティビティ番号 </summary>
        public int ActivityIndex
        {
            get { return this._ActivityIndex; }
            set
            {
                if (this._ActivityIndex == value) return;

                this._ActivityIndex = value;
                base.OnPropertyChanged("ActivityIndex");
            }
        }
        #endregion

        #region #- [Property] double.ActivityTime - ＜アクティビティタイム＞ -----
        /// <summary> アクティビティタイム </summary>
        private double _ActivityTime;
        /// <summary> アクティビティタイム </summary>
        public double ActivityTime
        {
            get { return this._ActivityTime; }
            set
            {
                if (this._ActivityTime == value) return;

                this._ActivityTime = value;
                base.OnPropertyChanged("ActivityTime");
            }
        }
        #endregion

        #region #- [Property] string.ActivityName - ＜アクティビティ名＞ -----
        /// <summary> アクティビティ名 </summary>
        private string _ActivityName;
        /// <summary> アクティビティ名 </summary>
        public string ActivityName
        {
            get { return this._ActivityName; }
            set
            {
                if (this._ActivityName == value) return;

                this._ActivityName = value;
                base.OnPropertyChanged("ActivityName");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインアイテムデータ／コンストラクタ
        /// </summary>
        public TimelineItemData()
            :base()
        {
            this.initData();
            this.clear();
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

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
