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
            return true;
        }
    }
}
