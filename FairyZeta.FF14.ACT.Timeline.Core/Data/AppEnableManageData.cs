using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／アプリケーション機能管理データ
    /// </summary>
    public class AppEnableManageData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.TimelineFileLoadEnable - ＜タイムラインファイルロードの有効状態＞ -----
        /// <summary> タイムラインファイルロードの有効状態 </summary>
        private bool _TimelineFileLoadEnable;
        /// <summary> タイムラインファイルロードの有効状態 </summary>
        public bool TimelineFileLoadEnable
        {
            get { return this._TimelineFileLoadEnable; }
            set
            {
                if (this._TimelineFileLoadEnable == value) return;

                this._TimelineFileLoadEnable = value;
                base.OnPropertyChanged("TimelineFileLoadEnable");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／アプリケーション機能管理データ
        /// </summary>
        public AppEnableManageData()
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
            this.TimelineFileLoadEnable = false;
            return true;
        }
    }
}
