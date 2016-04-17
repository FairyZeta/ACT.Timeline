using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Data;
using FairyZeta.FF14.ACT.Info;
using FairyZeta.FF14.ACT.Logger.LogData;
using FairyZeta.Framework.ObjectModel;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／共通データモデル
    /// </summary>
    public class CommonDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインアプリケーションデータ
        /// </summary>
        public ApplicationData ApplicationData { get; set; }

        /// <summary> 共通画面表示データ
        /// </summary>
        public AppCommonData AppCommonData { get; set; }

        /// <summary> アプリケーションステータスデータ
        /// </summary>
        public AppStatusData AppStatusData { get; set; }

        /// <summary> アプリケーション機能管理データ
        /// </summary>
        public AppEnableManageData AppEnableManageData { get; set; }

        /// <summary> ログデータコレクション
        /// </summary>
        public ObservableCollection<BasicLogData> LogDataCollection { get; set; }

        #region #- [Property] PluginSettingsData.PluginSettingsData - ＜プラグイン設定データ＞ -----
        /// <summary> プラグイン設定データ </summary>
        private PluginSettingsData _PluginSettingsData;
        /// <summary> プラグイン設定データ </summary>
        public PluginSettingsData PluginSettingsData
        {
            get { return this._PluginSettingsData; }
            set
            {
                if (this._PluginSettingsData == value) return;

                this._PluginSettingsData = value;
                base.OnPropertyChanged("PluginSettingsData");
            }
        }
        #endregion

        /// <summary> タイムラインファイルコレクション
        /// </summary>
        public ObservableCollection<TimelineFileData> TimelineFileCollection { get; private set; }
        /// <summary> タイムラインファイルコレクション／ビューソース
        /// </summary>
        public CollectionViewSource TimelineFileViewSource { get; private set; }

        /// <summary> 現在の位置情報
        /// </summary>
        public LocationData LocationData { get; private set; }

        #region #- [Property] TimelineFileData.SelectedTimelineFileData - ＜選択されているタイムラインファイルデータ＞ -----
        /// <summary> 選択されているタイムラインファイルデータ </summary>
        private TimelineFileData _SelectedTimelineFileData;
        /// <summary> 選択されているタイムラインファイルデータ </summary>
        public TimelineFileData SelectedTimelineFileData
        {
            get { return this._SelectedTimelineFileData; }
            set
            {
                if (this._SelectedTimelineFileData == value) return;

                this._SelectedTimelineFileData = value;
                base.OnPropertyChanged("SelectedTimelineFileData");
            }
        }
        #endregion

        /// <summary> ACT本体搭載のコントロールデータ
        /// </summary>
        public FormActMainControlData FormActMainControlData { get; private set; }

        /// <summary> (get) オーバーレイの一時的な非表示 
        /// <para> 表示する場合は True, 非表示の場合は False </para>
        /// </summary>
        public bool OverlayPassVisibility
        {
            get 
            {
                // ACTのShowボタン状態
                if (!this.PluginSettingsData.ActCheckBoxValue)
                    return false;
                // ウィンドウのアクティブ状態
                if (!this.AppStatusData.ActRelationWindowActive)
                    return false;
                // タイムラインロード状況
                if (this.PluginSettingsData.AutoTimelineVisibilityEnabled)
                {
                    if (this.AppStatusData.TimelineLoadStatus != TimelineLoadStatus.Success)
                        return false;
                }

                return true;
                
            }
        }

        #region #- [Property] PluginVersionInfo.PluginVersionInfo - ＜プラグインバージョン情報＞ -----
        /// <summary> プラグインバージョン情報 </summary>
        private PluginVersionInfo _PluginVersionInfo;
        /// <summary> プラグインバージョン情報 </summary>
        public PluginVersionInfo PluginVersionInfo
        {
            get { return this._PluginVersionInfo; }
            set
            {
                if (this._PluginVersionInfo == value) return;

                this._PluginVersionInfo = value;
                base.OnPropertyChanged("PluginVersionInfo");
            }
        }
        #endregion

        /// <summary> OS環境オブジェクトモデル
        /// </summary>
        public EnvironmentObjectModel EnvironmentObjectModel { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通表示データモデル／コンストラクタ
        /// </summary>
        public CommonDataModel()
            : base()
        {
            this.initDataModel();
            this.clear();

            this.EnvironmentObjectModel.CreateOsEnvironment();
            this.LogDataCollection.Add(
                Globals.SysLogger.WriteSystemLog.NonState.DEBUG.Write(string.Format("Process Is64Bit: {0}", this.EnvironmentObjectModel.OsEnvironmentData.IsProcess64Bit), Globals.ProjectName));
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.EnvironmentObjectModel = new EnvironmentObjectModel();

            this.ApplicationData = new ApplicationData();
            this.AppCommonData = new AppCommonData();
            this.PluginSettingsData = new PluginSettingsData();
            this.AppStatusData = new AppStatusData();
            this.AppEnableManageData = new AppEnableManageData();

            this.TimelineFileCollection = new ObservableCollection<TimelineFileData>();
            this.TimelineFileViewSource = new CollectionViewSource() { Source = this.TimelineFileCollection };

            this.LogDataCollection = new ObservableCollection<BasicLogData>();

            this.LocationData = new LocationData();

            this.FormActMainControlData = new FormActMainControlData();
            this.PluginVersionInfo = new PluginVersionInfo();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OnPropertyChangedを発行し、画面を更新します。
        /// </summary>
        public void ViewRefresh()
        {
            base.OnPropertyChanged("OverlayPassVisibility");
            this.TimelineFileViewSource.View.Refresh();
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
            this.TimelineFileCollection.Clear();
            return true;
        }
    }
}
