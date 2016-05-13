using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> オーバーレイ／データ補正プロセス 
    /// </summary>
    public class OverlayDataRevisionProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> オーバーレイ／データ補正プロセス 
        /// </summary>
        public OverlayDataRevisionProcess()
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

        /// <summary> データ補正を実行します。
        /// </summary>
        /// <param name="pOverlayDataModel"> 補正対象のオーバーレイデータモデル </param>
        public void DataRevisionExecute(OverlayDataModel pOverlayDataModel)
        {
            // v0.0.5以前のフォントサイズ移行
            if (pOverlayDataModel.DataVersion < new Version(0, 0, 5, 0))
            {
                pOverlayDataModel.FontData.TitleBar_BaseFontInfo.Size = pOverlayDataModel.OverlayGenericSettingsData.TitleBarFontSize;
                pOverlayDataModel.FontData.Header_BaseFontInfo.Size = pOverlayDataModel.OverlayGenericSettingsData.HeaderFontSize;
                pOverlayDataModel.FontData.Content_BaseFontInfo.Size = pOverlayDataModel.OverlayGenericSettingsData.ContentFontSize;
                pOverlayDataModel.FontData.Content_ActiveFontInfo.Size = pOverlayDataModel.OverlayGenericSettingsData.ContentFontSize;
            }

        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
