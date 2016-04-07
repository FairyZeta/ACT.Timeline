using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Timeline.Core.Data
{
    /// <summary> タイムライン／プラグイン設定データ
    /// </summary>
    public class PluginSettingsData : _Data
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] bool.AllOverlayVisibility - ＜全オーバーレイの表示状態＞ -----
        /// <summary> 全オーバーレイの表示状態 </summary>
        private bool _AllOverlayVisibility;
        /// <summary> 全オーバーレイの表示状態 </summary>
        public bool AllOverlayVisibility
        {
            get { return this._AllOverlayVisibility; }
            set
            {
                if (this._AllOverlayVisibility == value) return;

                this._AllOverlayVisibility = value;
                base.OnPropertyChanged("AllOverlayVisibility");
            }
        }
        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／プラグイン設定データ／コンストラクタ
        /// </summary>
        public PluginSettingsData()
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
            this.AllOverlayVisibility = false;
            return true;
        }
    }
}
