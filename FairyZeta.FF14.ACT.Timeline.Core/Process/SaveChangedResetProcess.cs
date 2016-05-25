using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> オーバーレイ／データモデルセーブ対象リセットプロセス
    /// </summary>
    public class SaveChangedResetProcess
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイ／データモデルセーブ対象リセットプロセス
        /// </summary>
        public SaveChangedResetProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイデータモデルのセーブフラグをリセットします。
        /// </summary>
        /// <param name="pDataModel"> リセット対象のデータモデル </param>
        public void OverlayDataSaveChangedReset(OverlayDataModel pDataModel)
        {
            pDataModel.OverlayWindowData.SaveChangedTarget = false;
            pDataModel.OverlayGenericSettingsData.SaveChangedTarget = false;
            pDataModel.OverlayOptionData.SaveChangedTarget = false;
            pDataModel.OverlayFilterSettingsData.SaveChangedTarget = false;
            pDataModel.OverlayItemVisibilitySettingsData.SaveChangedTarget = false;
            pDataModel.OverlayContentSettingsData.SaveChangedTarget = false;
            pDataModel.OverlayViewData.SaveChangedTarget = false;
            pDataModel.OverlayColorSettingsData.SaveChangedTarget = false;
            pDataModel.ActiveBarSettingsData.SaveChangedTarget = false;
            pDataModel.CastBarSettingsData.SaveChangedTarget = false;
            pDataModel.FontData.SaveChangedTarget = false;

            pDataModel.OverlayColorSettings.SetPropertyChangedFLG(false);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
