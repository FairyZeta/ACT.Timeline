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


        #region #- [Property] bool.ActiveIndicatorVisibility - ＜アクティブインジケータ表示フラグ＞ -----
        /// <summary> アクティブインジケータ表示フラグ </summary>
        private bool _ActiveIndicatorVisibility;
        /// <summary> アクティブインジケータ表示フラグ </summary>
        public bool ActiveIndicatorVisibility
        {
            get { return this._ActiveIndicatorVisibility; }
            set
            {
                if (this._ActiveIndicatorVisibility == value) return;

                this._ActiveIndicatorVisibility = value;
                base.OnPropertyChanged("ActiveIndicatorVisibility");
            }
        }
        #endregion
        #region #- [Property] decimal.ActiveIndicatorStartTime - ＜アクティブインジケータ開始時間＞ -----
        /// <summary> アクティブインジケータ開始時間 </summary>
        private decimal _ActiveIndicatorStartTime;
        /// <summary> アクティブインジケータ開始時間 </summary>
        public decimal ActiveIndicatorStartTime
        {
            get { return this._ActiveIndicatorStartTime; }
            set
            {
                if (this._ActiveIndicatorStartTime == value) return;

                this._ActiveIndicatorStartTime = value;
                base.OnPropertyChanged("ActiveIndicatorStartTime");
            }
        }
        #endregion
        #region #- [Property] double.ActiveIndicatorValue - ＜アクティブインジケータ値＞ -----
        /// <summary> アクティブインジケータ値 </summary>
        private double _ActiveIndicatorValue;
        /// <summary> アクティブインジケータ値 </summary>
        public double ActiveIndicatorValue
        {
            get { return this._ActiveIndicatorValue; }
            set
            {
                if (this._ActiveIndicatorValue == value) return;

                this._ActiveIndicatorValue = value;
                base.OnPropertyChanged("ActiveIndicatorValue");
            }
        }
        #endregion
        #region #- [Property] double.ActiveIndicatorMinValue - ＜アクティブインジケータ最小値＞ -----
        /// <summary> アクティブインジケータ最小値 </summary>
        private double _ActiveIndicatorMinValue;
        /// <summary> アクティブインジケータ最小値 </summary>
        public double ActiveIndicatorMinValue
        {
            get { return this._ActiveIndicatorMinValue; }
            set
            {
                if (this._ActiveIndicatorMinValue == value) return;

                this._ActiveIndicatorMinValue = value;
                base.OnPropertyChanged("ActiveIndicatorMinValue");
            }
        }
        #endregion
        #region #- [Property] double.ActiveIndicatorMaxValue - ＜アクティブインジケータ最大値＞ -----
        /// <summary> アクティブインジケータ最大値 </summary>
        private double _ActiveIndicatorMaxValue;
        /// <summary> アクティブインジケータ最大値 </summary>
        public double ActiveIndicatorMaxValue
        {
            get { return this._ActiveIndicatorMaxValue; }
            set
            {
                if (this._ActiveIndicatorMaxValue == value) return;

                this._ActiveIndicatorMaxValue = value;
                base.OnPropertyChanged("ActiveIndicatorMaxValue");
            }
        }
        #endregion
        #region #- [Property] double.ActiveIndicatorDefaultValue - ＜アクティブインジケータ初期値＞ -----
        /// <summary> アクティブインジケータ初期値 </summary>
        private double _ActiveIndicatorDefaultValue;
        /// <summary> アクティブインジケータ初期値 </summary>
        public double ActiveIndicatorDefaultValue
        {
            get { return this._ActiveIndicatorDefaultValue; }
            set
            {
                if (this._ActiveIndicatorDefaultValue == value) return;

                this._ActiveIndicatorDefaultValue = value;
                base.OnPropertyChanged("ActiveIndicatorDefaultValue");
            }
        }
        #endregion

        #region #- [Property] bool.DurationIndicatorVisibility - ＜アクションインジケータ表示フラグ＞ -----
        /// <summary> アクションインジケータ表示フラグ </summary>
        private bool _DurationIndicatorVisibility;
        /// <summary> アクションインジケータ表示フラグ </summary>
        public bool DurationIndicatorVisibility
        {
            get { return this._DurationIndicatorVisibility; }
            set
            {
                if (this._DurationIndicatorVisibility == value) return;

                this._DurationIndicatorVisibility = value;
                base.OnPropertyChanged("DurationIndicatorVisibility");
            }
        }
        #endregion
        #region #- [Property] double.DurationIndicatorValue - ＜アクションインジケータ値＞ -----
        /// <summary> アクションインジケータ値 </summary>
        private double _DurationIndicatorValue;
        /// <summary> アクションインジケータ値 </summary>
        public double DurationIndicatorValue
        {
            get { return this._DurationIndicatorValue; }
            set
            {
                if (this._DurationIndicatorValue == value) return;

                this._DurationIndicatorValue = value;
                base.OnPropertyChanged("DurationIndicatorValue");
            }
        }
        #endregion
        #region #- [Property] double.DurationIndicatorMinValue - ＜アクションインジケータ最小値＞ -----
        /// <summary> アクションインジケータ最小値 </summary>
        private double _DurationIndicatorMinValue;
        /// <summary> アクションインジケータ最小値 </summary>
        public double DurationIndicatorMinValue
        {
            get { return this._DurationIndicatorMinValue; }
            set
            {
                if (this._DurationIndicatorMinValue == value) return;

                this._DurationIndicatorMinValue = value;
                base.OnPropertyChanged("DurationIndicatorMinValue");
            }
        }
        #endregion
        #region #- [Property] double.DurationIndicatorMaxValue - ＜アクションインジケータ最大値＞ -----
        /// <summary> アクションインジケータ最大値 </summary>
        private double _DurationIndicatorMaxValue;
        /// <summary> アクションインジケータ最大値 </summary>
        public double DurationIndicatorMaxValue
        {
            get { return this._DurationIndicatorMaxValue; }
            set
            {
                if (this._DurationIndicatorMaxValue == value) return;

                this._DurationIndicatorMaxValue = value;
                base.OnPropertyChanged("DurationIndicatorMaxValue");
            }
        }
        #endregion
        #region #- [Property] double.DurationIndicatorDefaultValue - ＜アクションインジケータ初期値＞ -----
        /// <summary> アクションインジケータ初期値 </summary>
        private double _DurationIndicatorDefaultValue;
        /// <summary> アクションインジケータ初期値 </summary>
        public double DurationIndicatorDefaultValue
        {
            get { return this._DurationIndicatorDefaultValue; }
            set
            {
                if (this._DurationIndicatorDefaultValue == value) return;

                this._DurationIndicatorDefaultValue = value;
                base.OnPropertyChanged("DurationIndicatorDefaultValue");
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
            this.ActiveIndicatorVisibility = true;
            this.ActiveIndicatorValue = 0;
            this.ActiveIndicatorMinValue = 0;
            this.ActiveIndicatorMaxValue = 12;
            this.ActiveIndicatorDefaultValue = 0;

            this.DurationIndicatorVisibility = false;
            this.DurationIndicatorValue = 0;
            this.DurationIndicatorMinValue = 0;
            this.DurationIndicatorMaxValue = 0;
            this.DurationIndicatorDefaultValue = 0;

            return true;
        }
    }
}
