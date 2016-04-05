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

        public TimelineType TimelineType { get; set; }

        public ActivityAlert ActivityAlert { get; set; }

        #region #- [Property] int.ActivityIndex - ＜アクティビティ管理番号＞ -----
        /// <summary> アクティビティ管理番号 </summary>
        private int _ActivityIndex;
        /// <summary> アクティビティ管理番号 </summary>
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

        #region #- [Property] double.ActivityNo - ＜アクティビティ番号(秒)＞ -----
        /// <summary> アクティビティ番号(秒) </summary>
        private decimal _ActivityNo;
        /// <summary> アクティビティ番号(秒) </summary>
        public decimal ActivityNo
        {
            get { return this._ActivityNo; }
            set
            {
                if (this._ActivityNo == value) return;

                this._ActivityNo = value;
                base.OnPropertyChanged("ActivityTime");
            }
        }
        #endregion

        #region #- [Property] TimeSpan.ActivityTime - ＜アクティビティタイム＞ -----
        /// <summary> アクティビティタイム </summary>
        private TimeSpan _ActivityTime;
        /// <summary> アクティビティタイム </summary>
        public TimeSpan ActivityTime
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

        #region #- [Property] decimal.ActiveTime - ＜アクティブになるまでの残り時間＞ -----
        /// <summary> アクティブになるまでの残り時間 </summary>
        private decimal _ActiveTime;
        /// <summary> アクティブになるまでの残り時間 </summary>
        public decimal ActiveTime
        {
            get { return this._ActiveTime; }
            set
            {
                if (this._ActiveTime == value) return;

                this._ActiveTime = value;
                base.OnPropertyChanged("ActiveTime");
            }
        }
        #endregion

        public decimal Duration { get; set; }
        public decimal Jump { get; set; }

        #region #- [Property] bool.Visibility - ＜タイムラインリスト表示判定フラグ＞ -----
        /// <summary> タイムラインリスト表示判定フラグ </summary>
        private bool _Visibility;
        /// <summary> タイムラインリスト表示判定フラグ </summary>
        public bool Visibility
        {
            get { return this._Visibility; }
            set
            {
                if (this._Visibility == value) return;

                this._Visibility = value;
                base.OnPropertyChanged("Visibility");
            }
        }
        #endregion

        public decimal EndTime
        {
            get
            {
                return ActivityNo + Duration;
            }
        }


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
