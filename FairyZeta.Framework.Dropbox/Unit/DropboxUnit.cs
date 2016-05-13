using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Dropbox.Proc;

namespace FairyZeta.Framework.Dropbox.Unit
{
    /// <summary> ドロップボックスユニット
    /// </summary>
    public class DropboxUnit
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/



        /// <summary> ダウンロードプロセス
        /// </summary>
        private DropboxDownloadProcess dropboxDownloadProcess; 

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ドロップボックスユニット／コンストラクタ
        /// </summary>
        public DropboxUnit()
        {
            this.initUnit();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ユニットの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initUnit()
        {
            this.dropboxDownloadProcess = new DropboxDownloadProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
