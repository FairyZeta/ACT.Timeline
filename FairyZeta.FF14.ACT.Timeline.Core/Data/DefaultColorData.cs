using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイ／デフォルトカラーデータ
    /// </summary>
    public class DefaultColorData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] Color.TextColor_Base - ＜テキストカラー.ベース＞ -----
        /// <summary> テキストカラー.ベース </summary>
        public string TextColor_Base_String;
        /// <summary> テキストカラー.ベース </summary>
        [XmlIgnore]
        public Color TextColor_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TextColor_Base_String); }
            set
            {
                this.SetProperty(ref this.TextColor_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TextColor_Shadow - ＜テキストカラー.シャドウ＞ -----
        /// <summary> テキストカラー.シャドウ </summary>
        public string TextColor_Shadow_String;
        /// <summary> テキストカラー.シャドウ </summary>  
        [XmlIgnore]
        public Color TextColor_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TextColor_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TextColor_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.HeaderColor_Base - ＜ヘッダーカラー.ベース＞ -----
        /// <summary> ヘッダーカラー.ベース </summary>
        public string HeaderColor_Base_String;
        /// <summary> ヘッダーカラー.ベース </summary> 
        [XmlIgnore]
        public Color HeaderColor_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.HeaderColor_Base_String); }
            set
            {
                this.SetProperty(ref this.HeaderColor_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.HeaderColor_Shadow - ＜ヘッダーカラー.シャドウ＞ -----
        /// <summary> ヘッダーカラー.シャドウ </summary>
        public string HeaderColor_Shadow_String;
        /// <summary> ヘッダーカラー.シャドウ </summary>    
        public Color HeaderColor_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.HeaderColor_Shadow_String); }
            set
            {
                this.SetProperty(ref this.HeaderColor_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColor_ENEMY_Base - ＜タイプカラー：敵.ベース＞ -----
        /// <summary> タイプカラー：敵.ベース </summary>
        public string TypeColor_ENEMY_Base_String;
        /// <summary> タイプカラー：敵.ベース </summary>    
        public Color TypeColor_ENEMY_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_ENEMY_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_ENEMY_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_ENEMY_Shadow - ＜タイプカラー：敵.シャドウ＞ -----
        /// <summary> タイプカラー：敵.シャドウ </summary>
        public string TypeColor_ENEMY_Shadow_String;
        /// <summary> タイプカラー：敵.シャドウ </summary>    
        public Color TypeColor_ENEMY_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_ENEMY_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_ENEMY_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_UNKNOWN_Base - ＜タイプカラー：不明.ベース＞ -----
        /// <summary> タイプカラー：不明.ベース </summary>
        public string TypeColor_UNKNOWN_Base_String;
        /// <summary> タイプカラー：不明.ベース </summary>    
        public Color TypeColor_UNKNOWN_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_UNKNOWN_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_UNKNOWN_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_UNKNOWN_Shadow - ＜タイプカラー：不明.シャドウ＞ -----
        /// <summary> タイプカラー：不明.シャドウ </summary>
        public string TypeColor_UNKNOWN_Shadow_String;
        /// <summary> タイプカラー：不明.シャドウ </summary>    
        public Color TypeColor_UNKNOWN_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_UNKNOWN_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_UNKNOWN_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColor_TANK_Base - ＜タイプカラー：タンク.ベース＞ -----
        /// <summary> タイプカラー：タンク.ベース </summary>
        public string TypeColor_TANK_Base_String;
        /// <summary> タイプカラー：タンク.ベース </summary>    
        public Color TypeColor_TANK_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_TANK_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_TANK_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_TANK_Shadow - ＜タイプカラー：タンク.シャドウ＞ -----
        /// <summary> タイプカラー：タンク.シャドウ </summary>
        public string TypeColor_TANK_Shadow_String;
        /// <summary> タイプカラー：タンク.シャドウ </summary>    
        public Color TypeColor_TANK_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_TANK_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_TANK_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_DPS_Base - ＜タイプカラー：DPS.ベース＞ -----
        /// <summary> タイプカラー：DPS.ベース </summary>
        public string TypeColor_DPS_Base_String;
        /// <summary> タイプカラー：DPS.ベース </summary>    
        public Color TypeColor_DPS_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_DPS_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_DPS_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_DPS_Shadow - ＜タイプカラー：DPS.シャドウ＞ -----
        /// <summary> タイプカラー：DPS.シャドウ </summary>
        public string TypeColor_DPS_Shadow_String;
        /// <summary> タイプカラー：DPS.シャドウ </summary>    
        public Color TypeColor_DPS_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_DPS_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_DPS_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_HEALER_Base - ＜タイプカラー：ヒーラー.ベース＞ -----
        /// <summary> タイプカラー：ヒーラー.ベース </summary>
        public string TypeColor_HEALER_Base_String;
        /// <summary> タイプカラー：ヒーラー.ベース </summary>    
        public Color TypeColor_HEALER_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_HEALER_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_HEALER_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_HEALER_Shadow - ＜タイプカラー：ヒーラー.シャドウ＞ -----
        /// <summary> タイプカラー：ヒーラー.シャドウ </summary>
        public string TypeColor_HEALER_Shadow_String;
        /// <summary> タイプカラー：ヒーラー.シャドウ </summary>    
        public Color TypeColor_HEALER_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_HEALER_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_HEALER_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        #region #- [Property] Color.TypeColor_PET_Base - ＜タイプカラー：ペット.ベース＞ -----
        /// <summary> タイプカラー：ペット.ベース </summary>
        public string TypeColor_PET_Base_String;
        /// <summary> タイプカラー：ペット.ベース </summary>    
        public Color TypeColor_PET_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_PET_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_PET_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_PET_Shadow - ＜タイプカラー：ペット.シャドウ＞ -----
        /// <summary> タイプカラー：ペット.シャドウ </summary>
        public string TypeColor_PET_Shadow_String;
        /// <summary> タイプカラー：ペット.シャドウ </summary>    
        public Color TypeColor_PET_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_PET_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_PET_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Color.TypeColor_GIMMICK_Base - ＜タイプカラー：ギミック.ベース＞ -----
        /// <summary> タイプカラー：ギミック.ベース </summary>
        public string TypeColor_GIMMICK_Base_String;
        /// <summary> タイプカラー：ギミック.ベース </summary>    
        public Color TypeColor_GIMMICK_Base
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_GIMMICK_Base_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_GIMMICK_Base_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion
        #region #- [Property] Brudh.TypeColor_GIMMICK_Shadow - ＜タイプカラー：ギミック.シャドウ＞ -----
        /// <summary> タイプカラー：ギミック.シャドウ </summary>
        public string TypeColor_GIMMICK_Shadow_String;
        /// <summary> タイプカラー：ギミック.シャドウ </summary>    
        public Color TypeColor_GIMMICK_Shadow
        {
            get { return (Color)ColorConverter.ConvertFromString(this.TypeColor_GIMMICK_Shadow_String); }
            set
            {
                this.SetProperty(ref this.TypeColor_GIMMICK_Shadow_String, base.ColorToStringFormat(value));
                base.SaveChangedTarget = true;
            }
        }
        #endregion

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイ／デフォルトカラーデータ
        /// </summary>
        public DefaultColorData()
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
            //this.TextColor_Base = Color.FromArgb(0x88, 0x21, 0x7A, 0xA2);
            //this.TextColor_Shadow = Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5);
            this.TextColor_Base = Color.FromArgb(0x88, 0xFF, 0x00, 0x00);
            this.TextColor_Shadow = Color.FromArgb(0xBF, 0x00, 0xFF, 0x00);
            this.HeaderColor_Base = Color.FromArgb(0xBF, 0xDE, 0xD7, 0xBE);
            this.HeaderColor_Shadow = Color.FromArgb(0xE2, 0x79, 0x55, 0x16);

            this.TypeColor_ENEMY_Base = Color.FromArgb(0x88, 0x21, 0x7A, 0xA2);
            this.TypeColor_ENEMY_Shadow = Color.FromArgb(0xBF, 0xE2, 0xEB, 0xF5);
            this.TypeColor_UNKNOWN_Base = Color.FromArgb(0xBF, 0xAA, 0xAA, 0xAA);
            this.TypeColor_UNKNOWN_Shadow = Color.FromArgb(0xE2, 0xAA, 0xAA, 0xAA);

            this.TypeColor_TANK_Base = Color.FromArgb(0xBF,0x34,0x43,0x96);
            this.TypeColor_TANK_Shadow = Color.FromArgb(0xE2,0x40,0x54,0xBF);
            this.TypeColor_DPS_Base = Color.FromArgb(0xBF, 0x65, 0x32, 0x32);
            this.TypeColor_DPS_Shadow = Color.FromArgb(0xE2, 0xA0, 0x42, 0x42);
            this.TypeColor_HEALER_Base = Color.FromArgb(0xBF, 0x39, 0x65, 0x27);
            this.TypeColor_HEALER_Shadow = Color.FromArgb(0xE2, 0x4C, 0x8D, 0x32);

            this.TypeColor_PET_Base = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
            this.TypeColor_PET_Shadow = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
            this.TypeColor_GIMMICK_Base = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
            this.TypeColor_GIMMICK_Shadow = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの全体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        public override bool Clear()
        {
            this.clear();

            return true;
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データの単体クリアを実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool clear()
        {
            return true;
        }
    }
}
