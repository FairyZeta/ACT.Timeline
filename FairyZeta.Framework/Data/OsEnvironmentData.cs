using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.Framework.Data
{
    /// <summary> FZ／OS環境情報データ
    /// </summary>
    public class OsEnvironmentData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OSが64Bitで稼働しているかどうか
        /// </summary>
        public bool IsOperating64Bit { get; set; }
        /// <summary> プロセスが64Bitで稼働しているかどうか
        /// </summary>
        public bool IsProcess64Bit { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／OS環境情報データ
        /// </summary>
        public OsEnvironmentData()
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

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
