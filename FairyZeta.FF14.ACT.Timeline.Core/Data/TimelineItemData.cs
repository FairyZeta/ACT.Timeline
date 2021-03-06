﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／タイムラインアイテムデータ
    /// </summary>
    public class TimelineItemData : _Data
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/


        /// <summary> タイムラインアイテムのジョブタイプ
        /// </summary>
        public Job JobType { get; set; }
        
        /// <summary> タイムラインアイテムタイプ
        /// </summary>
        public TimelineType TimelineType { get; set; }


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
        private double _ActivityNo;
        /// <summary> アクティビティ番号(秒) </summary>
        public double ActivityNo
        {
            get { return this._ActivityNo; }
            set
            {
                if (this._ActivityNo == value) return;

                this._ActivityNo = value;
                base.OnPropertyChanged("ActivityTimeSpan");
                base.OnPropertyChanged("EndTime");
            }
        }
        #endregion

        /// <summary> (get) アクティビティタイム </summary>
        public TimeSpan ActivityTimeSpan
        {
            get
            {
                return new TimeSpan(0, 0, Convert.ToInt32(this.EndTime));
            }
        }

        
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

        /// <summary> (get) アクティブになるまでの残り時間 
        /// </summary>
        public double ActiveTime
        {
            get 
            {
                if (this.timerData == null) return 0;

                return this.EndTime - this.timerData.CurrentCombatTime;
            }
        }

        public double Duration { get; set; }

        /// <summary> このアイテムのジャンプ元データ
        /// </summary>
        public TimelineAnchorData JumpItemData { get; set; }
        /// <summary> このアイテムのシンク元データ
        /// </summary>
        public TimelineAnchorData SyncItemData { get; set; }

        
        #region #- [Property] double.ActiveIndicatorStartTime - ＜アクティブインジケータ開始時間＞ -----
        /// <summary> アクティブインジケータ開始時間 </summary>
        private double _ActiveIndicatorStartTime;
        /// <summary> アクティブインジケータ開始時間 </summary>
        public double ActiveIndicatorStartTime
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
        public double ActiveIndicatorMinValue
        {
            get
            {
                return this.ActivityNo - 12.0;
            }
        }
        #endregion
        #region #- [Property] double.ActiveIndicatorMaxValue - ＜アクティブインジケータ最大値＞ -----

        /// <summary> アクティブインジケータ最大値 </summary>
        public double ActiveIndicatorMaxValue
        {
            get 
            { 
                return this.ActivityNo; 
            }
            set
            {
                return;
                //if (this._ActiveIndicatorMaxValue == value) return;

                //this._ActiveIndicatorMaxValue = value;
                //base.OnPropertyChanged("ActiveIndicatorMaxValue");
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

        /// <summary> (get) アクションインジケータ表示フラグ </summary>
        public bool DurationIndicatorVisibility
        {
            get
            {
                if (this.ActivityNo - this.timerData.CurrentCombatTime <= 0) return true;

                return false;
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

        
        public double EndTime
        {
            get
            {
                return ActivityNo + Duration;
            }
        }


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインアイテムデータ／コンストラクタ
        /// </summary>
        public TimelineItemData(TimerData pTimerData)
            :base()
        {
            if (pTimerData != null)
            {
                this.timerData = pTimerData;
                pTimerData.CombatTimeChangedRefreshList.Add(this);
            }   
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
        
        /// <summary> OnPropertyChangedを発行し、画面を更新します。
        /// </summary>
        public void ViewRefresh()
        {
            base.OnPropertyChanged("ActiveTime");
            base.OnPropertyChanged("DurationIndicatorVisibility");
            base.OnPropertyChanged("TimelineVisibility");
        }

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
            this.JobType = Job.UNKNOWN;
            this.TimelineType = TimelineType.UNKNOWN;

            this.ActivityName = string.Empty;

            this.ActiveIndicatorValue = 0;
            this.ActiveIndicatorMinValue = 0;
            this.ActiveIndicatorMaxValue = 12;
            this.ActiveIndicatorDefaultValue = 0;
            
            this.DurationIndicatorValue = 0;
            this.DurationIndicatorMinValue = 0;

            return true;
        }
    }
}
