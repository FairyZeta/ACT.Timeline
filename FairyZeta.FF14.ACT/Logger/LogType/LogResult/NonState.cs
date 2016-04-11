using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.Setting;

namespace FairyZeta.FF14.ACT.Logger.LogType.LogResult
{
    public class NonState : _LogResultBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public NonState(LogStatusDefinition in_LD, LoggerSetting in_LS)
            : base(in_LD, in_LS, LogResultEnum.NonState)
        {
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
