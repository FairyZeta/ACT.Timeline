using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Process;

namespace FairyZeta.Framework.Module
{
    /// <summary> フレームワーク／シリアライズモジュール
    /// </summary>
    public class SerializerModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> XMLシリアライズプロセス
        /// </summary>
        private XmlSerializerProcess xmlSerializerProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> フレームワーク／シリアライズモジュール／コンストラクタ
        /// </summary>
        public SerializerModule()
            : base()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.xmlSerializerProcess = new XmlSerializerProcess();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
