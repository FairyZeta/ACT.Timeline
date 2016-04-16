using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Data
{
    /// <summary> ACT／アップデートステータスデータ
    /// </summary>
    public class UpdateStatusData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Property] bool.DialogClosed - ＜ダイアログクローズ＞ -----
        /// <summary> ダイアログクローズ </summary>
        private bool _DialogClosed;
        /// <summary> ダイアログクローズ </summary>
        public bool DialogClosed
        {
            get { return this._DialogClosed; }
            set
            {
                if (this._DialogClosed == value) return;

                this._DialogClosed = value;
                base.OnPropertyChanged("DialogClosed");
            }
        }
        #endregion
        
        #region #- [Property] UpdateDialogResult.UpdateDialogResult - ＜アップデートダイアログ応答結果＞ -----
        /// <summary> アップデートダイアログ応答結果 </summary>
        private UpdateDialogResult _UpdateDialogResult;
        /// <summary> アップデートダイアログ応答結果 </summary>
        public UpdateDialogResult UpdateDialogResult
        {
            get { return this._UpdateDialogResult; }
            set
            {
                if (this._UpdateDialogResult == value) return;

                this._UpdateDialogResult = value;
                base.OnPropertyChanged("UpdateDialogResult");
            }
        }
        #endregion

        #region #- [Property] DownloadStatus.ZipDownloadStatus - ＜ZIPファイルダウンロードステータス＞ -----
        /// <summary> ZIPファイルダウンロードステータス </summary>
        private DownloadStatus _ZipDownloadStatus;
        /// <summary> ZIPファイルダウンロードステータス </summary>
        public DownloadStatus ZipDownloadStatus
        {
            get { return this._ZipDownloadStatus; }
            set
            {
                if (this._ZipDownloadStatus == value) return;

                this._ZipDownloadStatus = value;
                base.OnPropertyChanged("ZipDownloadStatus");
            }
        }
        #endregion 

        #region #- [Property] bool.CommandButtonEnabled - ＜コマンドボタンの有効状態＞ -----
        /// <summary> コマンドボタンの有効状態 </summary>
        private bool _CommandButtonEnabled;
        /// <summary> コマンドボタンの有効状態 </summary>
        public bool CommandButtonEnabled
        {
            get { return this._CommandButtonEnabled; }
            set
            {
                if (this._CommandButtonEnabled == value) return;

                this._CommandButtonEnabled = value;
                base.OnPropertyChanged("CommandButtonEnabled");
            }
        }
        #endregion


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ACT／アップデートステータスデータ
        /// </summary>
        public UpdateStatusData()
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
            this.DialogClosed = false;
            this.UpdateDialogResult = ACT.UpdateDialogResult.Unknown;
            this.ZipDownloadStatus = DownloadStatus.NonStarted;
            this.CommandButtonEnabled = true;

            return true;
        }
    }
}
