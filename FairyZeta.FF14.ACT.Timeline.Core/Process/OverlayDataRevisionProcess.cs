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
            
            // v0.0.7以前のカラーデータ移行とバー調整
            if (pOverlayDataModel.DataVersion < new Version(0, 0, 7, 0))
            {
                pOverlayDataModel.OverlayColorSettings.MenuMain_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.MenuMain_Base;
                pOverlayDataModel.OverlayColorSettings.MenuSub_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.MenuSub_Base;
                pOverlayDataModel.OverlayColorSettings.Background_ShadowSettingsData.BaseColor
                    = pOverlayDataModel.OverlayColorSettingsData.Background_Base;

                pOverlayDataModel.OverlayColorSettings.HeaderText_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.HeaderText_Base;
                pOverlayDataModel.OverlayColorSettings.HeaderBar_ShadowSettingsData.BaseColor
                    = pOverlayDataModel.OverlayColorSettingsData.HeaderBar_Base;

                pOverlayDataModel.OverlayColorSettings.UNKNOWN_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorUNKNOWN_Base;
                pOverlayDataModel.OverlayColorSettings.ENEMY_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorENEMY_Base;
                pOverlayDataModel.OverlayColorSettings.TANK_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorTANK_Base;
                pOverlayDataModel.OverlayColorSettings.DPS_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorDPS_Base;
                pOverlayDataModel.OverlayColorSettings.HEALER_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorHEALER_Base;
                pOverlayDataModel.OverlayColorSettings.PET_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorPET_Base;
                pOverlayDataModel.OverlayColorSettings.GIMMICK_OutlineTextData.InnerTextColor
                    = pOverlayDataModel.OverlayColorSettingsData.TypeColorGIMMICK_Base;

                pOverlayDataModel.ActiveBarSettingsData.BarActiveTime = 12d;
                pOverlayDataModel.ActiveBarSettingsData.GradientStop1StartTime = 9d;
                pOverlayDataModel.ActiveBarSettingsData.GradientStop1EndTime = 7d;
                pOverlayDataModel.ActiveBarSettingsData.GradientStop2StartTime = 5d;
                pOverlayDataModel.ActiveBarSettingsData.GradientStop2EndTime = 3d;

                pOverlayDataModel.CastBarSettingsData.BarActiveTime = 3d;
                pOverlayDataModel.CastBarSettingsData.GradientStop1StartTime = 3d;
                pOverlayDataModel.CastBarSettingsData.GradientStop1EndTime = 2d;
                pOverlayDataModel.CastBarSettingsData.GradientStop2StartTime = 2d;
                pOverlayDataModel.CastBarSettingsData.GradientStop2EndTime = 1d;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
