using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／タイムライン表示データ
    /// </summary>
    public class OverlayViewData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.OverlayCustomClosed - ＜オーバーレイカスタムウィンドウを閉じる＞ -----
        /// <summary> オーバーレイカスタムウィンドウを閉じる </summary>
        private bool _OverlayCustomClosed;
        /// <summary> オーバーレイカスタムウィンドウを閉じる </summary>
        public bool OverlayCustomClosed
        {
            get { return this._OverlayCustomClosed; }
            set
            {
                if (this._OverlayCustomClosed == value) return;

                this._OverlayCustomClosed = value;
                base.OnPropertyChanged("OverlayCustomClosed");
            }
        }
        #endregion

        /// <summary> 画面表示されるタイムラインビューソース
        /// </summary>
        public CollectionViewSource TimelineViewSource { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムライン表示データ／コンストラクタ
        /// </summary>
        public OverlayViewData()
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
