using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／共通データモデル
    /// </summary>
    [Serializable]
    public class CommonDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインアプリケーションデータ
        /// </summary>
        [XmlIgnore]
        public ApplicationData ApplicationData { get; set; }

        /// <summary> 共通画面表示データ
        /// </summary>
        [XmlIgnore]
        public AppCommonData AppCommonData { get; set; }

        /// <summary> アプリケーションステータスデータ
        /// </summary>
        [XmlIgnore]
        public AppStatusData AppStatusData { get; set; }

        /// <summary> アプリケーション機能管理データ
        /// </summary>
        [XmlIgnore]
        public AppEnableManageData AppEnableManageData { get; set; }

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

        /// <summary> (get) オーバーレイの一時的な非表示 
        /// <para> 表示する場合は True, 非表示の場合は False </para>
        /// </summary>
        public bool OverlayPassVisibility
        {
            get 
            { 
                return true; 
            }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通表示データモデル／コンストラクタ
        /// </summary>
        public CommonDataModel()
            : base()
        {
            this.initDataModel();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.ApplicationData = new ApplicationData();
            this.AppCommonData = new AppCommonData();
            this.PluginSettingsData = new PluginSettingsData();
            this.AppStatusData = new AppStatusData();
            this.AppEnableManageData = new AppEnableManageData();

            this.TimelineFileCollection = new ObservableCollection<TimelineFileData>();
            this.TimelineFileViewSource = new CollectionViewSource() { Source = this.TimelineFileCollection };

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
