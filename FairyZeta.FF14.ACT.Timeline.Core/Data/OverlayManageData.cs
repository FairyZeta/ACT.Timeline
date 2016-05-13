using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイ管理データ
    /// </summary>
    public class OverlayManageData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/
        
        #region #- [Property] bool.OverlayManageWindowClosed - ＜オーバーレイ管理ウィンドウクローズフラグ＞ -----
        /// <summary> オーバーレイ管理ウィンドウクローズフラグ </summary>
        private bool _OverlayManageWindowClosed;
        /// <summary> オーバーレイ管理ウィンドウクローズフラグ </summary>
        public bool OverlayManageWindowClosed
        {
            get { return this._OverlayManageWindowClosed; }
            set
            {
                if (this._OverlayManageWindowClosed == value) return;

                this._OverlayManageWindowClosed = value;
                base.OnPropertyChanged("OverlayManageWindowClosed");
            }
        }
        #endregion

        #region #- [Property] bool.ModalBaseVisibility - ＜モーダルベース表示状態＞ -----
        /// <summary> モーダルベース表示状態 </summary>
        private bool _ModalBaseVisibility;
        /// <summary> モーダルベース表示状態 </summary>
        public bool ModalBaseVisibility
        {
            get { return this._ModalBaseVisibility; }
            set
            {
                if (this._ModalBaseVisibility == value) return;

                this._ModalBaseVisibility = value;
                base.OnPropertyChanged("ModalBaseVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.NowOverlayAddModal - ＜新規オーバーレイ追加モーダル表示＞ -----
        /// <summary> 新規オーバーレイ追加モーダル表示 </summary>
        private bool _NowOverlayAddModalVisibility;
        /// <summary> 新規オーバーレイ追加モーダル表示 </summary>
        public bool NowOverlayAddModalVisibility
        {
            get { return this._NowOverlayAddModalVisibility; }
            set
            {
                if (this._NowOverlayAddModalVisibility == value) return;

                this._NowOverlayAddModalVisibility = value;
                base.OnPropertyChanged("NowOverlayAddModalVisibility");
            }
        }
        #endregion
        #region #- [Property] bool.OverlayDeleteModalVisibility - ＜オーバーレイ削除モーダル表示状態＞ -----
        /// <summary> オーバーレイ削除モーダル表示状態 </summary>
        private bool _OverlayDeleteModalVisibility;
        /// <summary> オーバーレイ削除モーダル表示状態 </summary>
        public bool OverlayDeleteModalVisibility
        {
            get { return this._OverlayDeleteModalVisibility; }
            set
            {
                if (this._OverlayDeleteModalVisibility == value) return;

                this._OverlayDeleteModalVisibility = value;
                base.OnPropertyChanged("OverlayDeleteModalVisibility");
            }
        }
        #endregion

        #region #- [Property] bool.OverlayImportModalVisibility - ＜オーバーレイインポートモーダル表示状態＞ -----
        /// <summary> オーバーレイインポートモーダル表示状態 </summary>
        private bool _OverlayImportModalVisibility;
        /// <summary> オーバーレイインポートモーダル表示状態 </summary>    
        public bool OverlayImportModalVisibility
        {
            get { return _OverlayImportModalVisibility; }
            set { this.SetProperty(ref this._OverlayImportModalVisibility, value); }
        }
        #endregion

        #region #- [Property] bool.ImportDownloadButtonVisibility - ＜インポートダウンロードボタン表示状態＞ -----
        /// <summary> インポートダウンロードボタン表示状態 </summary>
        private bool _ImportDownloadButtonVisibility;
        /// <summary> インポートダウンロードボタン表示状態 </summary>    
        public bool ImportDownloadButtonVisibility
        {
            get { return _ImportDownloadButtonVisibility; }
            set { this.SetProperty(ref this._ImportDownloadButtonVisibility, value); }
        }
        #endregion
        #region #- [Property] bool.ImportCloseButtonVisibility - ＜インポートクローズボタン表示状態＞ -----
        /// <summary> インポートクローズボタン表示状態 </summary>
        private bool _ImportCloseButtonVisibility;
        /// <summary> インポートクローズボタン表示状態 </summary>    
        public bool ImportCloseButtonVisibility
        {
            get { return _ImportCloseButtonVisibility; }
            set { this.SetProperty(ref this._ImportCloseButtonVisibility, value); }
        }
        #endregion

        #region #- [Property] bool.ImportMenuVisibility - ＜インポートメニュー表示状態＞ -----
        /// <summary> インポートメニュー表示状態 </summary>
        private bool _ImportMenuVisibility;
        /// <summary> インポートメニュー表示状態 </summary>    
        public bool ImportMenuVisibility
        {
            get { return _ImportMenuVisibility; }
            set { this.SetProperty(ref this._ImportMenuVisibility, value); }
        }
        #endregion

        #region #- [Property] bool.ImportDownloadVisibility - ＜インポートダウンロード表示状態＞ -----
        /// <summary> インポートダウンロード表示状態 </summary>
        private bool _ImportDownloadVisibility;
        /// <summary> インポートダウンロード表示状態 </summary>    
        public bool ImportDownloadVisibility
        {
            get { return _ImportDownloadVisibility; }
            set { this.SetProperty(ref this._ImportDownloadVisibility, value); }
        }
        #endregion
        #region #- [Property] bool.NowImportVisibility - ＜インポート中ステータス表示状態＞ -----
        /// <summary> インポート中ステータス表示状態 </summary>
        private bool _NowImportVisibility;
        /// <summary> インポート中ステータス表示状態 </summary>    
        public bool NowImportVisibility
        {
            get { return _NowImportVisibility; }
            set { this.SetProperty(ref this._NowImportVisibility, value); }
        }
        #endregion
        #region #- [Property] bool.ImportResultVisibility - ＜インポート結果表示状態＞ -----
        /// <summary> インポート結果表示状態 </summary>
        private bool _ImportResultVisibility;
        /// <summary> インポート結果表示状態 </summary>    
        public bool ImportResultVisibility
        {
            get { return _ImportResultVisibility; }
            set { this.SetProperty(ref this._ImportResultVisibility, value); }
        }
        #endregion

        #region #- [Property] string.ImportResult - ＜インポート結果＞ -----
        /// <summary> インポート結果 </summary>
        private ImportResult? _ImportResult;
        /// <summary> インポート結果 </summary>    
        public ImportResult? ImportResult
        {
            get { return _ImportResult; }
            set { this.SetProperty(ref this._ImportResult, value); }
        }
        #endregion
        #region #- [Property] string.ImportMsg - ＜インポート結果メッセージ＞ -----
        /// <summary> インポート結果メッセージ </summary>
        private string _ImportMsg;
        /// <summary> インポート結果メッセージ </summary>    
        public string ImportMsg
        {
            get { return _ImportMsg; }
            set { this.SetProperty(ref this._ImportMsg, value); }
        }
        #endregion
        #region #- [Property] string.ImportURL - ＜インポートURL＞ -----
        /// <summary> インポートURL </summary>
        private string _ImportURL;
        /// <summary> インポートURL </summary>    
        public string ImportURL
        {
            get { return _ImportURL; }
            set { this.SetProperty(ref this._ImportURL, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイ管理データ
        /// </summary>
        public OverlayManageData()
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
            this.ModalBaseVisibility = false;
            this.NowOverlayAddModalVisibility = false;
            this.OverlayDeleteModalVisibility = false;
            this.OverlayManageWindowClosed = false;
            
            this.OverlayImportModalVisibility = false;
            this.ImportCloseButtonVisibility = false;
            this.ImportDownloadButtonVisibility = false;
            this.ImportMenuVisibility = false;
            this.NowImportVisibility = false;
            this.ImportDownloadVisibility = false;
            this.ImportResultVisibility = false;
            this.ImportURL = string.Empty;
            this.ImportResult = null;
            this.ImportMsg = string.Empty;

            return true;
        }
    }
}
