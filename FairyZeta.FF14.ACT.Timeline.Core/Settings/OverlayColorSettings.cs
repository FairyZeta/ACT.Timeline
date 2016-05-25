using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using FairyZeta.Framework.Data;
using System.Windows.Media;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Settings
{
    /// <summary> タイムライン／オーバーレイカラー設定
    /// </summary>
    public class OverlayColorSettings : BindableBase
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> (バインド用)カスタム配色プロパティ </summary>    
        [XmlIgnore]
        public Color EditBindColor
        {
            get { return this.getEditTargetColor(); }
            set
            {
                this.setEditTargetColor(value);
            }
        }

        #region #- [Property] ColorEditTarget.ColorEditTarget - ＜カラー変更ターゲット＞ -----
        /// <summary> カラー変更ターゲット </summary>
        private ColorEditTarget _ColorEditTarget;
        /// <summary> カラー変更ターゲット </summary>
        [XmlIgnore]
        public ColorEditTarget ColorEditTarget
        {
            get { return _ColorEditTarget; }
            set
            {
                this.SetProperty(ref this._ColorEditTarget, value);
                base.OnPropertyChanged("EditBindColor");
            }
        }
        #endregion
        /// <summary> 変更前カラー情報
        /// </summary>
        [XmlIgnore]
        public Color BeforeColor { get; set; }

        /// <summary> メニューメイン・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData MenuMain_OutlineTextData { get; set; }

        /// <summary> メニューサブ・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData MenuSub_OutlineTextData { get; set; }

        /// <summary> ヘッダーテキスト・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData HeaderText_OutlineTextData { get; set; }

        /// <summary> タイプカラー：敵・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData ENEMY_OutlineTextData { get; set; }

        /// <summary> タイプカラー：不明・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData UNKNOWN_OutlineTextData { get; set; }

        /// <summary> タイプカラー：タンク・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData TANK_OutlineTextData { get; set; }

        /// <summary> タイプカラー：DPS・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData DPS_OutlineTextData { get; set; }

        /// <summary> タイプカラー：ヒーラー・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData HEALER_OutlineTextData { get; set; }

        /// <summary> タイプカラー：ペット・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData PET_OutlineTextData { get; set; }

        /// <summary> タイプカラー：ギミック・アウトラインテキストデータ
        /// </summary>
        public OutlineTextData GIMMICK_OutlineTextData { get; set; }

        /// <summary> 背景シャドウ設定データ
        /// </summary>
        public ShadowSettingsData Background_ShadowSettingsData { get; set; }
        /// <summary> ヘッダーバーシャドウ設定データ
        /// </summary>
        public ShadowSettingsData HeaderBar_ShadowSettingsData { get; set; }

        private List<OutlineTextData> outlineTextDataList;
        private List<ShadowSettingsData> shadowSettingsDataList;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイカラー設定／コンストラクタ
        /// </summary>
        public OverlayColorSettings()
        {
            this.initSettings();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 設定の初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initSettings()
        {
            this.outlineTextDataList = new List<OutlineTextData>();
            this.shadowSettingsDataList = new List<ShadowSettingsData>();

            this.outlineTextDataList.Add(this.MenuMain_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.MenuSub_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.HeaderText_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.ENEMY_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.UNKNOWN_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xAA, 0xAA, 0xAA), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.TANK_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0x00, 0xD7, 0xFF), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.DPS_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xFF, 0x5F, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.HEALER_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0x6D, 0xD9, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.PET_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xAF, 0xFE, 0xEE), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.outlineTextDataList.Add(this.GIMMICK_OutlineTextData
                = new OutlineTextData(Color.FromArgb(0xBF, 0xFF, 0xFF, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.shadowSettingsDataList.Add(this.Background_ShadowSettingsData
                = new ShadowSettingsData(Color.FromArgb(0xFF, 0x00, 0x00, 0x00), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));
            this.shadowSettingsDataList.Add(this.HeaderBar_ShadowSettingsData
                = new ShadowSettingsData(Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE), Color.FromArgb(0xFF, 0x00, 0x00, 0x00)));

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 変更前カラー情報を取得して設定します。
        /// </summary>
        public void SetBeforeColor()
        {
            this.BeforeColor = this.getEditTargetColor();
        }

        /// <summary> 設定に変更があったかどうかをbool値で返却します。
        /// </summary>
        /// <returns> 変更があった場合 True, なかった場合 False </returns>
        public bool IsSettingChanged()
        {
            foreach (var outline in this.outlineTextDataList)
            {
                if(outline.PropertyChangedFLG)
                    return true;
            }
            foreach (var shadow in this.shadowSettingsDataList)
            {
                if (shadow.PropertyChangedFLG)
                    return true;
            }

            return false;
        }

        /// <summary> 設定データのプロパティ変更フラグをパラメータのbool値で書き換えます。
        /// </summary>
        public void SetPropertyChangedFLG(bool pChangedFLG)
        {
            foreach (var outline in this.outlineTextDataList)
            {
                outline.PropertyChangedFLG = pChangedFLG;
            }
            foreach (var shadow in this.shadowSettingsDataList)
            {
                shadow.PropertyChangedFLG = pChangedFLG;
            }

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 変更ターゲットとなるカラーに値を設定します。
        /// </summary>
        /// <param name="pColor"> 変更カラー </param>
        private void setEditTargetColor(Color pColor)
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.Non:
                    break;

                case ColorEditTarget.MenuMain_Base:
                    this.MenuMain_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.MenuMain_Outline:
                    this.MenuMain_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.MenuMain_Shadow:
                    this.MenuMain_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.MenuSub_Base:
                    this.MenuSub_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.MenuSub_Outline:
                    this.MenuSub_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.MenuSub_Shadow:
                    this.MenuSub_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.Background_Base:
                    this.Background_ShadowSettingsData.BaseColor = pColor;
                    break;
                case ColorEditTarget.Background_Shadow:
                    this.Background_ShadowSettingsData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.HeaderText_Base:
                    this.HeaderText_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.HeaderText_Outline:
                    this.HeaderText_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.HeaderText_Shadow:
                    this.HeaderText_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.HeaderBar_Base:
                    this.HeaderBar_ShadowSettingsData.BaseColor = pColor;
                    break;
                case ColorEditTarget.HeaderBar_Shadow:
                    this.HeaderBar_ShadowSettingsData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorUNKNOWN_Base:
                    this.UNKNOWN_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorUNKNOWN_Outline:
                    this.UNKNOWN_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorUNKNOWN_Shadow:
                    this.UNKNOWN_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorENEMY_Base:
                    this.ENEMY_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorENEMY_Outline:
                    this.ENEMY_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorENEMY_Shadow:
                    this.ENEMY_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorTANK_Base:
                    this.TANK_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorTANK_Outline:
                    this.TANK_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorTANK_Shadow:
                    this.TANK_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorDPS_Base:
                    this.DPS_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorDPS_Outline:
                    this.DPS_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorDPS_Shadow:
                    this.DPS_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorHEALER_Base:
                    this.HEALER_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorHEALER_Outline:
                    this.HEALER_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorHEALER_Shadow:
                    this.HEALER_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorPET_Base:
                    this.PET_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorPET_Outline:
                    this.PET_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorPET_Shadow:
                    this.PET_OutlineTextData.ShadowColor = pColor;
                    break;

                case ColorEditTarget.TypeColorGIMMICK_Base:
                    this.GIMMICK_OutlineTextData.InnerTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorGIMMICK_Outline:
                    this.GIMMICK_OutlineTextData.OutlineTextColor = pColor;
                    break;
                case ColorEditTarget.TypeColorGIMMICK_Shadow:
                    this.GIMMICK_OutlineTextData.ShadowColor = pColor;
                    break;
            }
        }

        /// <summary> 変更ターゲットとなるカラーから値を取得します。
        /// </summary>
        /// <param name="pColor"> 変更カラー </param>
        private Color getEditTargetColor()
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.MenuMain_Base:
                    return this.MenuMain_OutlineTextData.InnerTextColor;
                case ColorEditTarget.MenuMain_Outline:
                    return this.MenuMain_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.MenuMain_Shadow:
                    return this.MenuMain_OutlineTextData.ShadowColor;

                case ColorEditTarget.MenuSub_Base:
                    return this.MenuSub_OutlineTextData.InnerTextColor;
                case ColorEditTarget.MenuSub_Outline:
                    return this.MenuSub_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.MenuSub_Shadow:
                    return this.MenuSub_OutlineTextData.ShadowColor;

                case ColorEditTarget.Background_Base:
                    return this.Background_ShadowSettingsData.BaseColor;
                case ColorEditTarget.Background_Shadow:
                    return this.Background_ShadowSettingsData.ShadowColor;

                case ColorEditTarget.HeaderText_Base:
                    return this.HeaderText_OutlineTextData.InnerTextColor;
                case ColorEditTarget.HeaderText_Outline:
                    return this.HeaderText_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.HeaderText_Shadow:
                    return this.HeaderText_OutlineTextData.ShadowColor;

                case ColorEditTarget.HeaderBar_Base:
                    return this.HeaderBar_ShadowSettingsData.BaseColor;
                case ColorEditTarget.HeaderBar_Shadow:
                    return this.HeaderBar_ShadowSettingsData.ShadowColor;

                case ColorEditTarget.TypeColorUNKNOWN_Base:
                    return this.UNKNOWN_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorUNKNOWN_Outline:
                    return this.UNKNOWN_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorUNKNOWN_Shadow:
                    return this.UNKNOWN_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorENEMY_Base:
                    return this.ENEMY_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorENEMY_Outline:
                    return this.ENEMY_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorENEMY_Shadow:
                    return this.ENEMY_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorTANK_Base:
                    return this.TANK_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorTANK_Outline:
                    return this.TANK_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorTANK_Shadow:
                    return this.TANK_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorDPS_Base:
                    return this.DPS_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorDPS_Outline:
                    return this.DPS_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorDPS_Shadow:
                    return this.DPS_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorHEALER_Base:
                    return this.HEALER_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorHEALER_Outline:
                    return this.HEALER_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorHEALER_Shadow:
                    return this.HEALER_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorPET_Base:
                    return this.PET_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorPET_Outline:
                    return this.PET_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorPET_Shadow:
                    return this.PET_OutlineTextData.ShadowColor;

                case ColorEditTarget.TypeColorGIMMICK_Base:
                    return this.GIMMICK_OutlineTextData.InnerTextColor;
                case ColorEditTarget.TypeColorGIMMICK_Outline:
                    return this.GIMMICK_OutlineTextData.OutlineTextColor;
                case ColorEditTarget.TypeColorGIMMICK_Shadow:
                    return this.GIMMICK_OutlineTextData.ShadowColor;

                default:
                    return Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            }

        }

    }
}
