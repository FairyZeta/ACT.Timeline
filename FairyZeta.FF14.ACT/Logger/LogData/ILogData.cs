using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FairyZeta.FF14.ACT.Logger.LogData
{
    public interface ILogData
    {      
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログ出力の時間 </summary>
        DateTime OutputTime { get; set; }

        /// <summary> ログの各状態 </summary>
        LogStatusDefinition LogStatus { get; set; }

        /// <summary> ログ出力元のプロジェクト名(任意) </summary>
        string ProjectName { get; set; }

        /// <summary> ログ出力する文字列 </summary>
        string LogMessage { get; set; }

        /// <summary> スタックトレース </summary>
        StackTrace StackTrace { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
