using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／共通データ
    /// </summary>
    public class AppCommonData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.TimelineDirectoryStatus - ＜タイムラインディレクトリステータス＞ -----
        /// <summary> タイムラインディレクトリステータス </summary>
        private string _TimelineDirectoryStatus;
        /// <summary> タイムラインディレクトリステータス </summary>
        public string TimelineDirectoryStatus
        {
            get { return this._TimelineDirectoryStatus; }
            set
            {
                if (this._TimelineDirectoryStatus == value) return;

                this._TimelineDirectoryStatus = value;
                base.OnPropertyChanged("TimelineDirectoryStatus");
            }
        }
        #endregion
        #region #- [Property] string.SoundDirectoryStatus - ＜サウンドディレクトリステータス＞ -----
        /// <summary> サウンドディレクトリステータス </summary>
        private string _SoundDirectoryStatus;
        /// <summary> サウンドディレクトリステータス </summary>
        public string SoundDirectoryStatus
        {
            get { return this._SoundDirectoryStatus; }
            set
            {
                if (this._SoundDirectoryStatus == value) return;

                this._SoundDirectoryStatus = value;
                base.OnPropertyChanged("SoundDirectoryStatus");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通データ／コンストラクタ
        /// </summary>
        public AppCommonData()
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
            this.TimelineDirectoryStatus = string.Empty;
            this.SoundDirectoryStatus = string.Empty;

            return true;
        }
    }
}
