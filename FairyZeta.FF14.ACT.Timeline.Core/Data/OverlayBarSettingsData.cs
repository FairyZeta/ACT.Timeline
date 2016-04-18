using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／オーバーレイ各種バー設定データ
    /// </summary>
    public class OverlayBarSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] Brush.ActiveBerColor1 - ＜アクティブバーカラー(1)＞ -----
        /// <summary> アクティブバーカラー(1) </summary>
        private Brush _ActiveBerColor1;
        /// <summary> アクティブバーカラー(1) </summary>    
        public Brush ActiveBerColor1
        {
            get { return _ActiveBerColor1; }
            set { this.SetProperty(ref this._ActiveBerColor1, value); }
        }
        #endregion
        #region #- [Property] Brush.ActiveBarColor2 - ＜アクティブバーカラー(2)＞ -----
        /// <summary> アクティブバーカラー(2) </summary>
        private Brush _ActiveBarColor2;
        /// <summary> アクティブバーカラー(2) </summary>    
        public Brush ActiveBarColor2
        {
            get { return _ActiveBarColor2; }
            set { this.SetProperty(ref this._ActiveBarColor2, value); }
        }
        #endregion
        #region #- [Property] Brush.ActiveBarColor3 - ＜アクティブバーカラー(3)＞ -----
        /// <summary> アクティブバーカラー(3) </summary>
        private Brush _ActiveBarColor3;
        /// <summary> アクティブバーカラー(3) </summary>    
        public Brush ActiveBarColor3
        {
            get { return _ActiveBarColor3; }
            set { this.SetProperty(ref this._ActiveBarColor3, value); }
        }
        #endregion

        #region #- [Property] Brush.CastBarColor1 - ＜キャストバーカラー(1)＞ -----
        /// <summary> キャストバーカラー(1) </summary>
        private Brush _CastBarColor1;
        /// <summary> キャストバーカラー(1) </summary>    
        public Brush CastBarColor1
        {
            get { return _CastBarColor1; }
            set { this.SetProperty(ref this._CastBarColor1, value); }
        }
        #endregion
        #region #- [Property] Brush.CastBarColor2 - ＜キャストバーカラー(2)＞ -----
        /// <summary> キャストバーカラー(2) </summary>
        private Brush _CastBarColor2;
        /// <summary> キャストバーカラー(2) </summary>    
        public Brush CastBarColor2
        {
            get { return _CastBarColor2; }
            set { this.SetProperty(ref this._CastBarColor2, value); }
        }
        #endregion

        #region #- [Property] Brush.ActiveBarHeight - ＜アクティブバーの高さ＞ -----
        /// <summary> アクティブバーの高さ </summary>
        private Brush _ActiveBarHeight;
        /// <summary> アクティブバーの高さ </summary>    
        public Brush ActiveBarHeight
        {
            get { return _ActiveBarHeight; }
            set { this.SetProperty(ref this._ActiveBarHeight, value); }
        }
        #endregion
        

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> タイムライン／オーバーレイ各種バー設定データ
        /// </summary>
        public OverlayBarSettingsData()
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
            return true;
        }
    }
}
