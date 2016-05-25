using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FairyZeta.Core.Data;

namespace FairyZeta.Core.Process
{
    /// <summary> FZ／ディスプレイ解像度取得プロセス
    /// </summary>
    public class GetDisplayResolutionProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／ディスプレイ解像度取得プロセス／コンストラクタ
        /// </summary>
        public GetDisplayResolutionProcess()
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

        public DisplayData GetDisplayResolution(DisplayType pDisplayType)
        {
            DisplayData result = null;

            switch (pDisplayType)
            {
                case DisplayType.HD720:
                    result = new DisplayData(pDisplayType.ToString(), 720d, 1280d, 9d, 16d);
                    break;
            }

            return result;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
