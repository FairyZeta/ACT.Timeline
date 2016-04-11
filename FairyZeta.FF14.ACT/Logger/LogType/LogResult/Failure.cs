using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.Setting;

namespace FairyZeta.FF14.ACT.Logger.LogType.LogResult
{
    public class Failure : _LogResultBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public Failure(LogStatusDefinition in_LD, LoggerSetting in_LS)
            :base(in_LD, in_LS, LogResultEnum.Failure)
        {
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
