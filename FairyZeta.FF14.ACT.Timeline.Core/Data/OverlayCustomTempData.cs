using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> オーバーレイカスタム一時的データ
    /// </summary>
    public class OverlayCustomTempData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

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

        #region #- [Property] Color.ChangeTargetStringColor - ＜文字配色変更用のカラー＞ -----
        /// <summary> 文字配色変更用のカラー </summary>
        private Color _ChangeTargetStringColor;
        /// <summary> 文字配色変更用のカラー </summary>    
        public Color ChangeTargetStringColor
        {
            get { return _ChangeTargetStringColor; }
            set { this.SetProperty(ref this._ChangeTargetStringColor, value); }
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
            this.StringColorCustomVisibility = false;
            return true;
        }
    }
}
