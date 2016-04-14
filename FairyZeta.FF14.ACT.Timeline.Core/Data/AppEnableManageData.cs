using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／アプリケーション機能管理データ
    /// </summary>
    public class AppEnableManageData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.TimelineFileLoadEnable - ＜タイムラインファイルロードの有効状態＞ -----
        /// <summary> タイムラインファイルロードの有効状態 </summary>
        private bool _TimelineFileLoadEnabled;
        /// <summary> タイムラインファイルロードの有効状態 </summary>
        public bool TimelineFileLoadEnabled
        {
            get { return this._TimelineFileLoadEnabled; }
            set
            {
                if (this._TimelineFileLoadEnabled == value) return;

                this._TimelineFileLoadEnabled = value;
                base.OnPropertyChanged("TimelineFileLoadEnabled");
            }
        }
        #endregion
        #region #- [Property] bool.RefreshTimelineListEnabled - ＜タイムラインリスト更新の有効状態＞ -----
        /// <summary> タイムラインリスト更新の有効状態 </summary>
        private bool _RefreshTimelineListEnabled;
        /// <summary> タイムラインリスト更新の有効状態 </summary>
        public bool RefreshTimelineListEnabled
        {
            get { return this._RefreshTimelineListEnabled; }
            set
            {
                if (this._RefreshTimelineListEnabled == value) return;

                this._RefreshTimelineListEnabled = value;
                base.OnPropertyChanged("RefreshTimelineListEnabled");
            }
        }
        #endregion

        #region #- [Property] bool.TimelinePlayEnabled - ＜タイムライン再生の有効状態＞ -----
        /// <summary> タイムライン再生の有効状態 </summary>
        private bool _TimelinePlayEnabled;
        /// <summary> タイムライン再生の有効状態 </summary>
        public bool TimelinePlayEnabled
        {
            get { return this._TimelinePlayEnabled; }
            set
            {
                if (this._TimelinePlayEnabled == value) return;

                this._TimelinePlayEnabled = value;
                base.OnPropertyChanged("TimelinePlayEnabled");
            }
        }
        #endregion
        #region #- [Property] bool.TimelinePauseEnabled - ＜タイムライン一時停止の有効状態＞ -----
        /// <summary> タイムライン一時停止の有効状態 </summary>
        private bool _TimelinePauseEnabled;
        /// <summary> タイムライン一時停止の有効状態 </summary>
        public bool TimelinePauseEnabled
        {
            get { return this._TimelinePauseEnabled; }
            set
            {
                if (this._TimelinePauseEnabled == value) return;

                this._TimelinePauseEnabled = value;
                base.OnPropertyChanged("TimelinePauseEnabled");
            }
        }
        #endregion
        #region #- [Property] bool.TimelineRewindEnabled - ＜タイムライン巻き戻し有効状態＞ -----
        /// <summary> タイムライン巻き戻し有効状態 </summary>
        private bool _TimelineRewindEnabled;
        /// <summary> タイムライン巻き戻し有効状態 </summary>
        public bool TimelineRewindEnabled
        {
            get { return this._TimelineRewindEnabled; }
            set
            {
                if (this._TimelineRewindEnabled == value) return;

                this._TimelineRewindEnabled = value;
                base.OnPropertyChanged("TimelineRewindEnabled");
            }
        }
        #endregion

        #region #- [Property] bool.TimelineTrackerEnabled - ＜タイムライントラッカーの有効状態＞ -----
        /// <summary> タイムライントラッカーの有効状態 </summary>
        private bool _TimelineTrackerEnabled;
        /// <summary> タイムライントラッカーの有効状態 </summary>
        public bool TimelineTrackerEnabled
        {
            get { return this._TimelineTrackerEnabled; }
            set
            {
                if (this._TimelineTrackerEnabled == value) return;

                this._TimelineTrackerEnabled = value;
                base.OnPropertyChanged("TimelineTrackerEnabled");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アプリケーション機能管理データ
        /// </summary>
        public AppEnableManageData()
            : base()
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
            this.TimelineFileLoadEnabled = true;
            this.RefreshTimelineListEnabled = true;

            this.TimelinePlayEnabled = true;
            this.TimelinePauseEnabled = true;
            this.TimelineRewindEnabled = true;

            this.TimelineTrackerEnabled = true;

            return true;
        }
    }
}
