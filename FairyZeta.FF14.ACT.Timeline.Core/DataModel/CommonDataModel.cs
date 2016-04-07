using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using System.Xml;

namespace FairyZeta.FF14.ACT.Timeline.Core.DataModel
{
    /// <summary> タイムライン／共通データモデル
    /// </summary>
    [Serializable]
    public class CommonDataModel : _DataModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 共通表示データ
        /// </summary>
        public CommonViewData CommonViewData { get; set; }

        /// <summary> プラグイン設定データ
        /// </summary>
        public PluginSettingsData PluginSettingsData { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／共通表示データモデル／コンストラクタ
        /// </summary>
        public CommonDataModel()
            : base()
        {
            this.initDataModel();
            this.clear();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> データモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initDataModel()
        {
            this.CommonViewData = new CommonViewData();
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
