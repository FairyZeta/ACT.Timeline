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

        /// <summary> ディスプレイ情報を返却します。
        /// </summary>
        /// <param name="pDisplayType"> 取得するディスプレイタイプ </param>
        /// <returns> ディスプレイデータ またはNull </returns>
        public DisplayData GetDisplayResolution(DisplayType pDisplayType)
        {
            DisplayData result = null;

            switch (pDisplayType)
            {
                case DisplayType.HD720:
                    result = new DisplayData(pDisplayType.ToString(), 1280d, 720d, 16d, 9d);
                    break;
                case DisplayType.FHD:
                    result = new DisplayData(pDisplayType.ToString(), 1920d, 1080d, 16d, 9d);
                    break;
                case DisplayType.WUXGA:
                    result = new DisplayData(pDisplayType.ToString(), 1920d, 1200d, 8d, 5d);
                    break;
                case DisplayType.QFHD_UHD_4K:
                    result = new DisplayData(pDisplayType.ToString(), 3840d, 2160d, 16d, 9d);
                    break;
            }

            return result;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
