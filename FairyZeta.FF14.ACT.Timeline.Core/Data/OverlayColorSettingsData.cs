using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイカラー設定データ
    /// </summary>
    public class OverlayColorSettingsData : _Data
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

        #region #- [Property] Color.MenuMain_Base - ＜メニューメイン.ベース＞ -----
        /// <summary> メニューメイン.ベース </summary>
        private Color _MenuMain_Base;
        /// <summary> メニューメイン.ベース </summary>    
        public Color MenuMain_Base
        {
            get { return _MenuMain_Base; }
            set
            {
                this.SetProperty(ref this._MenuMain_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.MenuMain_Shadow - ＜メニューメイン.シャドウ＞ -----
        /// <summary> メニューメイン.シャドウ </summary>
        private Color _MenuMain_Shadow;
        /// <summary> メニューメイン.シャドウ </summary>    
        public Color MenuMain_Shadow
        {
            get { return _MenuMain_Shadow; }
            set
            {
                this.SetProperty(ref this._MenuMain_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.MenuSub_Base - ＜メニューサブ.ベース＞ -----
        /// <summary> メニューサブ.ベース </summary>
        private Color _MenuSub_Base;
        /// <summary> メニューサブ.ベース </summary>    
        public Color MenuSub_Base
        {
            get { return _MenuSub_Base; }
            set
            {
                this.SetProperty(ref this._MenuSub_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.MenuSub_Shadow - ＜メニューサブ.シャドウ＞ -----
        /// <summary> メニューサブ.シャドウ </summary>
        private Color _MenuSub_Shadow;
        /// <summary> メニューサブ.シャドウ </summary>    
        public Color MenuSub_Shadow
        {
            get { return _MenuSub_Shadow; }
            set
            {
                this.SetProperty(ref this._MenuSub_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.Background_Base - ＜背景.ベース＞ -----
        /// <summary> 背景.ベース </summary>
        private Color _Background_Base;
        /// <summary> 背景.ベース </summary>    
        public Color Background_Base
        {
            get { return _Background_Base; }
            set
            {
                this.SetProperty(ref this._Background_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.HeaderText_Base - ＜ヘッダーテキスト.ベース＞ -----
        /// <summary> ヘッダーテキスト.ベース </summary>
        private Color _HeaderText_Base;
        /// <summary> ヘッダーテキスト.ベース </summary>    
        public Color HeaderText_Base
        {
            get { return _HeaderText_Base; }
            set
            {
                this.SetProperty(ref this._HeaderText_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.HeaderText_Shadow - ＜ヘッダーテキスト.シャドウ＞ -----
        /// <summary> ヘッダーテキスト.シャドウ </summary>
        private Color _HeaderText_Shadow;
        /// <summary> ヘッダーテキスト.シャドウ </summary>    
        public Color HeaderText_Shadow
        {
            get { return _HeaderText_Shadow; }
            set
            {
                this.SetProperty(ref this._HeaderText_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.HeaderBar_Base - ＜ヘッダーバー.ベース＞ -----
        /// <summary> ヘッダーバー.ベース </summary>
        private Color _HeaderBar_Base;
        /// <summary> ヘッダーバー.ベース </summary>    
        public Color HeaderBar_Base
        {
            get { return _HeaderBar_Base; }
            set
            {
                this.SetProperty(ref this._HeaderBar_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.HeaderBar_Shadow - ＜ヘッダーバー.シャドウ＞ -----
        /// <summary> ヘッダーバー.シャドウ </summary>
        private Color _HeaderBar_Shadow;
        /// <summary> ヘッダーバー.シャドウ </summary>    
        public Color HeaderBar_Shadow
        {
            get { return _HeaderBar_Shadow; }
            set
            {
                this.SetProperty(ref this._HeaderBar_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorENEMY_Base - ＜タイプカラー：敵.ベース＞ -----
        /// <summary> タイプカラー：敵.ベース </summary>
        private Color _TypeColorENEMY_Base;
        /// <summary> タイプカラー：敵.ベース </summary>    
        public Color TypeColorENEMY_Base
        {
            get { return _TypeColorENEMY_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorENEMY_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorENEMY_Shadow - ＜タイプカラー：敵.シャドウ＞ -----
        /// <summary> タイプカラー：敵.シャドウ </summary>
        private Color _TypeColorENEMY_Shadow;
        /// <summary> タイプカラー：敵.シャドウ </summary>    
        public Color TypeColorENEMY_Shadow
        {
            get { return _TypeColorENEMY_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorENEMY_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorUNKNOWN_Base - ＜タイプカラー：不明.ベース＞ -----
        /// <summary> タイプカラー：不明.ベース </summary>
        private Color _TypeColorUNKNOWN_Base;
        /// <summary> タイプカラー：不明.ベース </summary>    
        public Color TypeColorUNKNOWN_Base
        {
            get { return _TypeColorUNKNOWN_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorUNKNOWN_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorUNKNOWN_Shadow - ＜タイプカラー：不明.シャドウ＞ -----
        /// <summary> タイプカラー：不明.シャドウ </summary>
        private Color _TypeColorUNKNOWN_Shadow;
        /// <summary> タイプカラー：不明.シャドウ </summary>    
        public Color TypeColorUNKNOWN_Shadow
        {
            get { return _TypeColorUNKNOWN_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorUNKNOWN_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorTANK_Base - ＜タイプカラー：タンク.ベース＞ -----
        /// <summary> タイプカラー：タンク.ベース </summary>
        private Color _TypeColorTANK_Base;
        /// <summary> タイプカラー：タンク.ベース </summary>    
        public Color TypeColorTANK_Base
        {
            get { return _TypeColorTANK_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorTANK_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorTANK_Shadow - ＜タイプカラー：タンク.シャドウ＞ -----
        /// <summary> タイプカラー：タンク.シャドウ </summary>
        private Color _TypeColorTANK_Shadow;
        /// <summary> タイプカラー：タンク.シャドウ </summary>    
        public Color TypeColorTANK_Shadow
        {
            get { return _TypeColorTANK_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorTANK_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorDPS_Base - ＜タイプカラー：DPS.ベース＞ -----
        /// <summary> タイプカラー：DPS.ベース </summary>
        private Color _TypeColorDPS_Base;
        /// <summary> タイプカラー：DPS.ベース </summary>    
        public Color TypeColorDPS_Base
        {
            get { return _TypeColorDPS_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorDPS_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorDPS_Shadow - ＜タイプカラー：DPS.シャドウ＞ -----
        /// <summary> タイプカラー：DPS.シャドウ </summary>
        private Color _TypeColorDPS_Shadow;
        /// <summary> タイプカラー：DPS.シャドウ </summary>    
        public Color TypeColorDPS_Shadow
        {
            get { return _TypeColorDPS_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorDPS_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorHEALER_Base - ＜タイプカラー：ヒーラー.ベース＞ -----
        /// <summary> タイプカラー：ヒーラー.ベース </summary>
        private Color _TypeColorHEALER_Base;
        /// <summary> タイプカラー：ヒーラー.ベース </summary>    
        public Color TypeColorHEALER_Base
        {
            get { return _TypeColorHEALER_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorHEALER_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorHEALER_Shadow - ＜タイプカラー：ヒーラー.シャドウ＞ -----
        /// <summary> タイプカラー：ヒーラー.シャドウ </summary>
        private Color _TypeColorHEALER_Shadow;
        /// <summary> タイプカラー：ヒーラー.シャドウ </summary>    
        public Color TypeColorHEALER_Shadow
        {
            get { return _TypeColorHEALER_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorHEALER_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorPET_Base - ＜タイプカラー：ペット.ベース＞ -----
        /// <summary> タイプカラー：ペット.ベース </summary>
        private Color _TypeColorPET_Base;
        /// <summary> タイプカラー：ペット.ベース </summary>    
        public Color TypeColorPET_Base
        {
            get { return _TypeColorPET_Base; }
            set
            {
                this.SetProperty(ref this._TypeColorPET_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorPET_Shadow - ＜タイプカラー：ペット.シャドウ＞ -----
        /// <summary> タイプカラー：ペット.シャドウ </summary>
        private Color _TypeColorPET_Shadow;
        /// <summary> タイプカラー：ペット.シャドウ </summary>    
        public Color TypeColorPET_Shadow
        {
            get { return _TypeColorPET_Shadow; }
            set
            {
                this.SetProperty(ref this._TypeColorPET_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColorGIMMICK_Base - ＜タイプカラー：ギミック.ベース＞ -----
        /// <summary> タイプカラー：ギミック.ベース </summary>
        private Color _TypeColorGIMMICK_Base;
        /// <summary> タイプカラー：ギミック.ベース </summary>    
        public Color TypeColorGIMMICK_Base
        {
            get { return _TypeColorGIMMICK_Base; }
            set 
            {
                this.SetProperty(ref this._TypeColorGIMMICK_Base, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColorGIMMICK_Shadow - ＜タイプカラー：ギミック.シャドウ＞ -----
        /// <summary> タイプカラー：ギミック.シャドウ </summary>
        private Color _TypeColorGIMMICK_Shadow;
        /// <summary> タイプカラー：ギミック.シャドウ </summary>    
        public Color TypeColorGIMMICK_Shadow
        {
            get { return _TypeColorGIMMICK_Shadow; }
            set 
            {
                this.SetProperty(ref this._TypeColorGIMMICK_Shadow, value);
                base.SaveChangedTarget = true;
            }
        }
        #endregion


      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイカラー設定データ／コンストラクタ
        /// </summary>
        public OverlayColorSettingsData()
            : base()
        {
            this.initData();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initData()
        {
            this.MenuMain_Base = Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE);
            //this.MenuMain_Shadow = Color.FromArgb(0xFF, 0x79, 0x55, 0x16);
            this.MenuSub_Base = Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5);
            //this.MenuSub_Shadow = Color.FromArgb(0x88, 0xE2, 0xEB, 0xF5);
            this.Background_Base = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);

            this.HeaderText_Base = Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE);
            //this.HeaderText_Shadow = Color.FromArgb(0xFF, 0x79, 0x55, 0x16);
            this.HeaderBar_Base = Color.FromArgb(0xFF, 0xDE, 0xD7, 0xBE);
            //this.HeaderBar_Shadow = Color.FromArgb(0xFF, 0x79, 0x55, 0x16);

            this.TypeColorENEMY_Base = Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5);
            //this.TypeColorENEMY_Shadow = Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5);
            this.TypeColorUNKNOWN_Base = Color.FromArgb(0xBF, 0xAA, 0xAA, 0xAA);
            //this.TypeColorUNKNOWN_Shadow = Color.FromArgb(0xE2, 0xAA, 0xAA, 0xAA);

            this.TypeColorTANK_Base = Color.FromArgb(0xBF, 0x00, 0xD7, 0xFF);
            //this.TypeColorTANK_Shadow = Color.FromArgb(0xE2, 0x40, 0x54, 0xBF);
            this.TypeColorDPS_Base = Color.FromArgb(0xBF, 0xFF, 0x5F, 0x00);
            //this.TypeColorDPS_Shadow = Color.FromArgb(0xE2, 0xA0, 0x42, 0x42);
            this.TypeColorHEALER_Base = Color.FromArgb(0xBF, 0x6D, 0xD9, 0x00);
            //this.TypeColorHEALER_Shadow = Color.FromArgb(0xE2, 0x4C, 0x8D, 0x32);

            this.TypeColorPET_Base = Color.FromArgb(0xBF, 0xAF, 0xFE, 0xEE);
            //this.TypeColorPET_Shadow = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
            this.TypeColorGIMMICK_Base = Color.FromArgb(0xBF, 0xFF, 0xFF, 0x00);
            //this.TypeColorGIMMICK_Shadow = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

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
        
        private void setEditTargetColor(Color pColor)
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.Non:
                    break;

                case ColorEditTarget.MenuMain_Base:
                    this.MenuMain_Base = pColor;
                    break;
                case ColorEditTarget.MenuSub_Base:
                    this.MenuSub_Base = pColor;
                    break;
                case ColorEditTarget.Background_Base:
                    this.Background_Base = pColor;
                    break;

                case ColorEditTarget.HeaderText_Base:
                    this.HeaderText_Base = pColor;
                    break;
                case ColorEditTarget.HeaderBar_Base:
                    this.HeaderBar_Base = pColor;
                    break;

                case ColorEditTarget.TypeColorUNKNOWN_Base:
                    this.TypeColorUNKNOWN_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorENEMY_Base:
                    this.TypeColorENEMY_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorTANK_Base:
                    this.TypeColorTANK_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorDPS_Base:
                    this.TypeColorDPS_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorHEALER_Base:
                    this.TypeColorHEALER_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorPET_Base:
                    this.TypeColorPET_Base = pColor;
                    break;
                case ColorEditTarget.TypeColorGIMMICK_Base:
                    this.TypeColorGIMMICK_Base = pColor;
                    break;
            }
        }


        private Color getEditTargetColor()
        {
            switch (this.ColorEditTarget)
            {
                case ColorEditTarget.MenuMain_Base:
                    return this.MenuMain_Base;
                case ColorEditTarget.MenuSub_Base:
                    return this.MenuSub_Base;
                case ColorEditTarget.Background_Base:
                    return this.Background_Base;

                case ColorEditTarget.HeaderText_Base:
                    return this.HeaderText_Base;

                case ColorEditTarget.HeaderBar_Base:
                    return this.HeaderBar_Base;

                case ColorEditTarget.TypeColorUNKNOWN_Base:
                    return this.TypeColorUNKNOWN_Base;

                case ColorEditTarget.TypeColorENEMY_Base:
                    return this.TypeColorENEMY_Base;

                case ColorEditTarget.TypeColorTANK_Base:
                    return this.TypeColorTANK_Base;

                case ColorEditTarget.TypeColorDPS_Base:
                    return this.TypeColorDPS_Base;

                case ColorEditTarget.TypeColorHEALER_Base:
                    return this.TypeColorHEALER_Base;

                case ColorEditTarget.TypeColorPET_Base:
                    return this.TypeColorPET_Base;

                case ColorEditTarget.TypeColorGIMMICK_Base:
                    return this.TypeColorGIMMICK_Base;

                default:
                    return Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
            }

        }


        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
