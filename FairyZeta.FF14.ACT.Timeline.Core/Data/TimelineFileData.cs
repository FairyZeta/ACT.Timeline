using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／タイムラインファイルデータ
    /// </summary>
    public class TimelineFileData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] string.TimelineFileName - ＜タイムラインファイル名＞ -----
        /// <summary> タイムラインファイル名 </summary>
        private string _TimelineFileName;
        /// <summary> タイムラインファイル名 </summary>
        public string TimelineFileName
        {
            get { return this._TimelineFileName; }
            set
            {
                if (this._TimelineFileName == value) return;

                this._TimelineFileName = value;
                base.OnPropertyChanged("TimelineFileName");
            }
        }
        #endregion

        #region #- [Property] string.TimelineFileFullPath - ＜タイムラインファイルフルパス＞ -----
        /// <summary> タイムラインファイルフルパス </summary>
        private string _TimelineFileFullPath;
        /// <summary> タイムラインファイルフルパス </summary>
        public string TimelineFileFullPath
        {
            get { return this._TimelineFileFullPath; }
            set
            {
                if (this._TimelineFileFullPath == value) return;

                this._TimelineFileFullPath = value;
                base.OnPropertyChanged("TimelineFileFullPath");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／タイムラインファイルデータ／コンストラクタ
        /// </summary>
        public TimelineFileData()
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
            this.TimelineFileName = string.Empty;
            this.TimelineFileFullPath = string.Empty;

            return true;
        }

    }
}
