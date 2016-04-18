using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Timeline.Core.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.Process
{
    /// <summary> オーバーレイデフォルト設定プロセス
    /// </summary>
    public class OvarlayDefaultSetProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オーバーレイデフォルト設定プロセス
        /// </summary>
        public OvarlayDefaultSetProcess()
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

        /// <summary> オーバーレイのデフォルトカラーを設定します。
        /// <para> => バーカラーはバー設定で指定 </para>
        /// </summary>
        /// <param name="pColorSettingsData"> 設定するカラーデータ </param>
        /// <param name="pDefaultColorData"> 設定値を参照するデータ </param>
        public void SetDefaultColorSettings(OverlayColorSettingsData pColorSettingsData, DefaultColorData pDefaultColorData)
        {
            pColorSettingsData.TextColor_Base           = pDefaultColorData.TextColor_Base;
            pColorSettingsData.TextColor_Shadow         = pDefaultColorData.TextColor_Shadow;
            /*
            pColorSettingsData.HeaderColor_Base         = pDefaultColorData.HeaderColor_Base;
            pColorSettingsData.HeaderColor_Shadow       = pDefaultColorData.HeaderColor_Shadow;

            pColorSettingsData.TypeColor_ENEMY_Base     = pDefaultColorData.TypeColor_ENEMY_Base;
            pColorSettingsData.TypeColor_ENEMY_Shadow   = pDefaultColorData.TypeColor_ENEMY_Shadow;
            pColorSettingsData.TypeColor_UNKNOWN_Base   = pDefaultColorData.TypeColor_UNKNOWN_Base;
            pColorSettingsData.TypeColor_UNKNOWN_Shadow = pDefaultColorData.TypeColor_UNKNOWN_Shadow;
                                                        
            pColorSettingsData.TypeColor_TANK_Base      = pDefaultColorData.TypeColor_TANK_Base;
            pColorSettingsData.TypeColor_TANK_Shadow    = pDefaultColorData.TypeColor_TANK_Shadow;
            pColorSettingsData.TypeColor_DPS_Base       = pDefaultColorData.TypeColor_DPS_Base;
            pColorSettingsData.TypeColor_DPS_Shadow     = pDefaultColorData.TypeColor_DPS_Shadow;
            pColorSettingsData.TypeColor_HEALER_Base    = pDefaultColorData.TypeColor_HEALER_Base;
            pColorSettingsData.TypeColor_HEALER_Shadow  = pDefaultColorData.TypeColor_HEALER_Shadow;
                                                        
            pColorSettingsData.TypeColor_PET_Base       = pDefaultColorData.TypeColor_PET_Base;
            pColorSettingsData.TypeColor_PET_Shadow     = pDefaultColorData.TypeColor_PET_Shadow;
            pColorSettingsData.TypeColor_GIMMICK_Base   = pDefaultColorData.TypeColor_GIMMICK_Base;
            pColorSettingsData.TypeColor_GIMMICK_Shadow = pDefaultColorData.TypeColor_GIMMICK_Shadow;
            */
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
