using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／プラグイン設定データ
    /// </summary>
    [Serializable]
    public class PluginSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/


        #region #- [Property] string.TimelineResourceDirectory - ＜タイムラインリソースディレクトリ＞ -----
        /// <summary> タイムラインリソースディレクトリ </summary>
        private string _TimelineResourceDirectory;
        /// <summary> タイムラインリソースディレクトリ </summary>
        public string TimelineResourceDirectory
        {
            get { return this._TimelineResourceDirectory; }
            set
            {
                if (this._TimelineResourceDirectory == value) return;

                this._TimelineResourceDirectory = value;
                base.OnPropertyChanged("TimelineResourceDirectory");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.SoundResourceDirectory - ＜サウンドリソースディレクトリ＞ -----
        /// <summary> サウンドリソースディレクトリ </summary>
        private string _SoundResourceDirectory;
        /// <summary> サウンドリソースディレクトリ </summary>
        public string SoundResourceDirectory
        {
            get { return this._SoundResourceDirectory; }
            set
            {
                if (this._SoundResourceDirectory == value) return;

                this._SoundResourceDirectory = value;
                base.OnPropertyChanged("SoundResourceDirectory");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] string.LastLoadTimelineFileName - ＜最後に読み込んだタイムラインのファイル名＞ -----
        /// <summary> 最後に読み込んだタイムラインのファイル名 </summary>
        private string _LastLoadTimelineFileName;
        /// <summary> 最後に読み込んだタイムラインのファイル名 </summary>
        public string LastLoadTimelineFileName
        {
            get { return this._LastLoadTimelineFileName; }
            set
            {
                if (this._LastLoadTimelineFileName == value) return;

                this._LastLoadTimelineFileName = value;
                base.OnPropertyChanged("LastLoadTimelineFileName");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] string.LastLoadTimelineFullPath - ＜最後に読み込んだタイムラインのフルパス＞ -----
        /// <summary> 最後に読み込んだタイムラインのフルパス </summary>
        private string _LastLoadTimelineFullPath;
        /// <summary> 最後に読み込んだタイムラインのフルパス </summary>
        public string LastLoadTimelineFullPath
        {
            get { return this._LastLoadTimelineFullPath; }
            set
            {
                if (this._LastLoadTimelineFullPath == value) return;

                this._LastLoadTimelineFullPath = value;
                base.OnPropertyChanged("LastLoadTimelineFullPath");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.PlaySoundByACT - ＜サウンド再生設定(true => ACT本体でサウンド再生)＞ -----
        /// <summary> サウンド再生設定(true => ACT本体でサウンド再生) </summary>
        private bool _PlaySoundByACT;
        /// <summary> サウンド再生設定(true => ACT本体でサウンド再生) </summary>
        public bool PlaySoundByACT
        {
            get { return this._PlaySoundByACT; }
            set
            {
                if (this._PlaySoundByACT == value) return;

                this._PlaySoundByACT = value;
                base.OnPropertyChanged("PlaySoundByACT");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.TimelineAutoLoadEnable - ＜タイムライン自動読込の有効状態＞ -----
        /// <summary> タイムライン自動読込の有効状態 </summary>
        private bool _TimelineAutoLoadEnabled;
        /// <summary> タイムライン自動読込の有効状態 </summary>
        public bool TimelineAutoLoadEnabled
        {
            get { return this._TimelineAutoLoadEnabled; }
            set
            {
                if (this._TimelineAutoLoadEnabled == value) return;

                this._TimelineAutoLoadEnabled = value;
                base.OnPropertyChanged("TimelineAutoLoadEnabled");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.AutoTimelineVisibilityEnabled - ＜タイムラインの有無による自動表示切替＞ -----
        /// <summary> タイムラインの有無による自動表示切替 </summary>
        private bool _AutoTimelineVisibilityEnabled;
        /// <summary> タイムラインの有無による自動表示切替 </summary>
        public bool AutoTimelineVisibilityEnabled
        {
            get { return this._AutoTimelineVisibilityEnabled; }
            set
            {
                if (this._AutoTimelineVisibilityEnabled == value) return;

                this._AutoTimelineVisibilityEnabled = value;
                base.OnPropertyChanged("AutoTimelineVisibilityEnabled");
            }
        }
        #endregion

        #region #- [Property] bool.ResetTimelineCombatEndEnabled - ＜戦闘終了時の自動リセット有効状態＞ -----
        /// <summary> 戦闘終了時の自動リセット有効状態 </summary>
        private bool _ResetTimelineCombatEndEnabled;
        /// <summary> 戦闘終了時の自動リセット有効状態 </summary>
        public bool ResetTimelineCombatEndEnabled
        {
            get { return this._ResetTimelineCombatEndEnabled; }
            set
            {
                if (this._ResetTimelineCombatEndEnabled == value) return;

                this._ResetTimelineCombatEndEnabled = value;
                base.OnPropertyChanged("ResetTimelineCombatEndEnabled");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.AutoUpdateChackEnabled - ＜プラグインアップデートチェックの有効状態＞ -----
        /// <summary> プラグインアップデートチェックの有効状態 </summary>
        private bool _AutoUpdateChackEnabled;
        /// <summary> プラグインアップデートチェックの有効状態 </summary>
        public bool AutoUpdateChackEnabled
        {
            get { return this._AutoUpdateChackEnabled; }
            set
            {
                if (this._AutoUpdateChackEnabled == value) return;

                this._AutoUpdateChackEnabled = value;
                base.OnPropertyChanged("AutoUpdateChackEnabled");
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] bool.BuildRevisonUpdateIgnore - ＜軽度アップデートチェックの無視設定＞ -----
        /// <summary> 軽度アップデートチェックの無視設定 </summary>
        private bool _BuildRevisonUpdateIgnore;
        /// <summary> 軽度アップデートチェックの無視設定 </summary>
        public bool BuildRevisonUpdateIgnore
        {
            get { return this._BuildRevisonUpdateIgnore; }
            set
            {
                if (this._BuildRevisonUpdateIgnore == value) return;

                this._BuildRevisonUpdateIgnore = value;
                base.OnPropertyChanged("BuildRevisonUpdateIgnore");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] bool.ActCheckBoxValue - ＜ACT本体チェックボックスの値＞ -----
        /// <summary> ACT本体チェックボックスの値 </summary>
        private bool _ActCheckBoxValue;
        /// <summary> ACT本体チェックボックスの値 </summary>
        public bool ActCheckBoxValue
        {
            get { return this._ActCheckBoxValue; }
            set
            {
                if (this._ActCheckBoxValue == value) return;

                this._ActCheckBoxValue = value;
                base.OnPropertyChanged("ActCheckBoxValue");
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] DateTime.LastUpdateCheckTime - ＜最後にアップデートを確認した時間＞ -----
        /// <summary> 最後にアップデートを確認した時間 </summary>
        private DateTime _LastUpdateCheckTime;
        /// <summary> 最後にアップデートを確認した時間 </summary>
        public DateTime LastUpdateCheckTime
        {
            get { return this._LastUpdateCheckTime; }
            set
            {
                if (this._LastUpdateCheckTime == value) return;

                this._LastUpdateCheckTime = value;
                base.OnPropertyChanged("LastUpdateCheckTime");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／プラグイン設定データ／コンストラクタ
        /// </summary>
        public PluginSettingsData()
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
            this.SoundResourceDirectory = string.Empty;
            this.TimelineResourceDirectory = string.Empty;

            this.LastLoadTimelineFileName = string.Empty;
            this.LastLoadTimelineFullPath = string.Empty;

            this.PlaySoundByACT = true;

            this.AutoTimelineVisibilityEnabled = true;
            this.TimelineAutoLoadEnabled = true;
            this.ResetTimelineCombatEndEnabled = true;

            this.AutoUpdateChackEnabled = true;
            this.BuildRevisonUpdateIgnore = true;

            this.ActCheckBoxValue = true;

            return true;
        }
    }
}
