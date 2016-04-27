using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FairyZeta.Framework.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイカスタム一時的データ
    /// </summary>
    public class OverlayCustomTempData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.BaseFontCustomVisibility - ＜フォント変更の展開状態＞ -----
        /// <summary> フォント変更の展開状態 </summary>
        private bool _BaseFontCustomVisibility;
        /// <summary> フォント変更の展開状態 </summary>    
        public bool BaseFontCustomVisibility
        {
            get { return this._BaseFontCustomVisibility; }
            set { base.SetProperty(ref this._BaseFontCustomVisibility, value); }
        }
        #endregion
        #region #- [Property] FontInfo.ChangeTargetFontInfo - ＜変更対象のフォント情報＞ -----
        /// <summary> 変更対象のフォント情報 </summary>
        private FontInfo _ChangeTargetFontInfo;
        /// <summary> 変更対象のフォント情報 </summary>    
        public FontInfo ChangeTargetFontInfo
        {
            get { return this._ChangeTargetFontInfo; }
            set { base.SetProperty(ref this._ChangeTargetFontInfo, value); }
        }
        #endregion

        #region #- [Property] bool.StringColorCustomVisibility - ＜文字カラー変更の展開状態＞ -----
        /// <summary> 文字カラー変更の展開状態 </summary>
        private bool _StringColorCustomVisibility;
        /// <summary> 文字カラー変更の展開状態 </summary>    
        public bool StringColorCustomVisibility
        {
            get { return _StringColorCustomVisibility; }
            set { this.SetProperty(ref this._StringColorCustomVisibility, value); }
        }
        #endregion
        #region #- [Property] bool.ActiveColorCustomVisibility - ＜文字カラー変更の展開状態＞ -----
        /// <summary> 文字カラー変更の展開状態 </summary>
        private bool _ActiveColorCustomVisibility;
        /// <summary> 文字カラー変更の展開状態 </summary>    
        public bool ActiveColorCustomVisibility
        {
            get { return _ActiveColorCustomVisibility; }
            set { this.SetProperty(ref this._ActiveColorCustomVisibility, value); }
        }
        #endregion
        #region #- [Property] bool.CastColorCustomVisibility - ＜文字カラー変更の展開状態＞ -----
        /// <summary> 文字カラー変更の展開状態 </summary>
        private bool _CastColorCustomVisibility;
        /// <summary> 文字カラー変更の展開状態 </summary>    
        public bool CastColorCustomVisibility
        {
            get { return _CastColorCustomVisibility; }
            set { this.SetProperty(ref this._CastColorCustomVisibility, value); }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイカスタム一時的データ
        /// </summary>
        public OverlayCustomTempData()
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
            this.BaseFontCustomVisibility = false;
            this.StringColorCustomVisibility = false;
            this.ActiveColorCustomVisibility = false;
            this.CastColorCustomVisibility = false;

            return true;
        }
    }
}
