using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／オーバーレイデータモデル
    /// </summary>
    [Serializable]
    public class OverlayDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> このデータモデルが保存対象であるかを返します。
        /// </summary>
        [XmlIgnore]
        public bool SaveChangedTarget
        {
            get
            {
                if (this.OverlayWindowData.SaveChangedTarget 
                    || this.OverlayGenericSettingsData.SaveChangedTarget
                    || this.OverlayOptionData.SaveChangedTarget 
                    || this.OverlayFilterSettingsData.SaveChangedTarget
                    || this.OverlayItemVisibilitySettingsData.SaveChangedTarget
                    || this.OverlayContentSettingsData.SaveChangedTarget
                    || this.OverlayColorSettingsData.SaveChangedTarget
                    || this.ActiveBarSettingsData.SaveChangedTarget
                    || this.CastBarSettingsData.SaveChangedTarget
                    || this.FontData.SaveChangedTarget
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary> オーバーレイタイプコレクション
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<OverlayType> OverlayTypeCollection { get; private set; }

        /// <summary> データバージョン(str) </summary>
        public string DataVersionStr { get; set; }

        /// <summary> データバージョン </summary>
        [XmlIgnore]
        public Version DataVersion
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.DataVersionStr))
                {
                    return new Version(0, 0, 0, 0);
                }
                else
                {
                    return new Version(this.DataVersionStr);
                }
            }
            set
            {
                this.DataVersionStr = value.ToString();
            }
        }

        #region #- [Property] OverlayWindowData.OverlayWindowData - ＜新オーバーレイ画面データ＞ -----
        /// <summary> 新オーバーレイ画面データ </summary>
        private OverlayWindowData _OverlayWindowData;
        /// <summary> 新オーバーレイ画面データ </summary>
        public OverlayWindowData OverlayWindowData
        {
            get { return this._OverlayWindowData; }
            set
            {
                if (this._OverlayWindowData == value) return;

                this._OverlayWindowData = value;
                base.OnPropertyChanged("OverlayWindowData");
            }
        }
        #endregion

        #region #- [Property] OverlayGenericSettingsData.OverlayGenericSettingsData - ＜オーバーレイ一般設定データ＞ -----
        /// <summary> オーバーレイ一般設定データ </summary>
        private OverlayGenericSettingsData _OverlayGenericSettingsData;
        /// <summary> オーバーレイ一般設定データ </summary>
        public OverlayGenericSettingsData OverlayGenericSettingsData
        {
            get { return this._OverlayGenericSettingsData; }
            set
            {
                if (this._OverlayGenericSettingsData == value) return;

                this._OverlayGenericSettingsData = value;
                base.OnPropertyChanged("OverlayGenericSettingsData");
            }
        }
        #endregion
        #region #- [Property] OverlaySettingsData.OverlaySettingsData - ＜オーバーレイオプションデータ＞ -----
        /// <summary> オーバーレイオプションデータ </summary>
        private OverlayOptionData _OverlayOptionData;
        /// <summary> オーバーレイオプションデータ </summary>
        public OverlayOptionData OverlayOptionData
        {
            get { return this._OverlayOptionData; }
            set
            {
                if (this._OverlayOptionData == value) return;

                this._OverlayOptionData = value;
                base.OnPropertyChanged("OverlayOptionData");
            }
        }
        #endregion
        #region #- [Property] OverlayFilterSettingsData.OverlayFilterSettingData - ＜オーバーレイフィルタ設定データ＞ -----
        /// <summary> オーバーレイフィルタ設定データ </summary>
        private OverlayFilterSettingsData _OverlayFilterSettingsData;
        /// <summary> オーバーレイフィルタ設定データ </summary>
        public OverlayFilterSettingsData OverlayFilterSettingsData
        {
            get { return this._OverlayFilterSettingsData; }
            set
            {
                if (this._OverlayFilterSettingsData == value) return;

                this._OverlayFilterSettingsData = value;
                base.OnPropertyChanged("OverlayFilterSettingData");
            }
        }
        #endregion
        #region #- [Property] OverlayItemVisibilitySettingsData.OverlayItemVisibilitySettingsData - ＜オーバーレイアイテム表示設定データ＞ -----
        /// <summary> オーバーレイアイテム表示設定データ </summary>
        private OverlayItemVisibilitySettingsData _OverlayItemVisibilitySettingsData;
        /// <summary> オーバーレイアイテム表示設定データ </summary>
        public OverlayItemVisibilitySettingsData OverlayItemVisibilitySettingsData
        {
            get { return this._OverlayItemVisibilitySettingsData; }
            set
            {
                if (this._OverlayItemVisibilitySettingsData == value) return;

                this._OverlayItemVisibilitySettingsData = value;
                base.OnPropertyChanged("OverlayItemVisibilitySettingsData");
            }
        }
        #endregion
        #region #- [Property] OverlayContentSettingsData.OverlayContentSettingsData - ＜オーバーレイコンテンツ設定データ＞ -----
        /// <summary> オーバーレイコンテンツ設定データ </summary>
        private OverlayContentSettingsData _OverlayContentSettingsData;
        /// <summary> オーバーレイコンテンツ設定データ </summary>
        public OverlayContentSettingsData OverlayContentSettingsData
        {
            get { return this._OverlayContentSettingsData; }
            set
            {
                if (this._OverlayContentSettingsData == value) return;

                this._OverlayContentSettingsData = value;
                base.OnPropertyChanged("OverlayContentSettingsData");
            }
        }
        #endregion

        #region #- [Property] OverlayViewData.OverlayViewData - ＜オーバーレイ画面表示データ＞ -----
        /// <summary> オーバーレイ画面表示データ </summary>
        private OverlayViewData _OverlayViewData;
        /// <summary> オーバーレイ画面表示データ </summary>
        [XmlIgnore]
        public OverlayViewData OverlayViewData
        {
            get { return this._OverlayViewData; }
            set
            {
                if (this._OverlayViewData == value) return;

                this._OverlayViewData = value;
                base.OnPropertyChanged("OverlayViewData");
            }
        }
        #endregion

        #region #- [Property] OverlayColorSettingsData.OverlayColorSettingsData - ＜オーバーレイ配色設定データ＞ -----
        /// <summary> オーバーレイ配色設定データ </summary>
        private OverlayColorSettingsData _OverlayColorSettingsData;
        /// <summary> オーバーレイ配色設定データ </summary>    
        public OverlayColorSettingsData OverlayColorSettingsData
        {
            get { return _OverlayColorSettingsData; }
            set { this.SetProperty(ref this._OverlayColorSettingsData, value); }
        }
        #endregion

        /// <summary> アクティブバー設定データ
        /// </summary>
        public OverlayBarSettingsData ActiveBarSettingsData { get; set; }
        /// <summary> キャストバー設定データ
        /// </summary>
        public OverlayBarSettingsData CastBarSettingsData { get; set; }

        /// <summary> フォントデータ
        /// </summary>
        public OverlayFontData FontData { get; set; }

        /// <summary> オーバーレイカスタム一時的データ
        /// </summary>
        [XmlIgnore]
        public OverlayCustomTempData OverlayCustomTempData { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／オーバーレイ追加用データモデル／コンストラクタ
        /// </summary>
        public OverlayDataModel()
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
            this.OverlayWindowData = new OverlayWindowData();
            this.OverlayOptionData = new OverlayOptionData();
            this.OverlayTypeCollection = new ObservableCollection<OverlayType>();
            this.OverlayViewData = new OverlayViewData();
            this.OverlayFilterSettingsData = new OverlayFilterSettingsData();
            this.OverlayItemVisibilitySettingsData = new OverlayItemVisibilitySettingsData();
            this.OverlayGenericSettingsData = new OverlayGenericSettingsData();
            this.OverlayContentSettingsData = new OverlayContentSettingsData();
            this.OverlayCustomTempData = new OverlayCustomTempData();
            this.OverlayColorSettingsData = new OverlayColorSettingsData();

            this.ActiveBarSettingsData = new OverlayBarSettingsData();
            this.ActiveBarSettingsData.DefaultSetup_ActiveBar();
            this.CastBarSettingsData = new OverlayBarSettingsData();
            this.CastBarSettingsData.DefaultSetup_CastBar();

            this.FontData = new OverlayFontData();
            this.FontData.SetupDefaultFontSetting();

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
            this.OverlayTypeCollection.Clear();

            return true;
        }
    }
}
