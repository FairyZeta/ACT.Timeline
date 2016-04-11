using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairyZeta.FF14.ACT.Logger
{
    /// <summary> ログ定義 </summary>
    public class LogStatusDefinition : _LoggerBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 出力ログのタイプ </summary>
        public LogTypeEnum LogTypeEnum { get; set; }
        /// <summary> 出力ログの成果（結果） </summary>
        public LogResultEnum LogResultEnum { get; set; }
        /// <summary> 出力ログのレベル </summary>
        public LogLevelEnum LogLevelEnum { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public LogStatusDefinition()
            :base()
        {
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
