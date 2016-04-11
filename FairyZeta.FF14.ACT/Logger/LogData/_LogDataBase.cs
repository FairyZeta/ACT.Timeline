using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FairyZeta.FF14.ACT.Logger.LogData
{
    public abstract class _LogDataBase : ILogData
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログ出力の時間 </summary>
        public DateTime OutputTime { get; set; }
        /// <summary> ログの各状態 </summary>
        public LogStatusDefinition LogStatus { get; set; }
        /// <summary> ログ出力元のプロジェクト名(任意) </summary>
        public string ProjectName { get; set; }
        /// <summary> ログ出力する文字列 </summary>
        public string LogMessage { get; set; }
        /// <summary> スタックトレース </summary>
        public StackTrace StackTrace { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public _LogDataBase()
        {
            this.InitData();
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData()
        {
            this.OutputTime = new DateTime();
            this.LogStatus = new LogStatusDefinition();
            this.ProjectName = string.Empty;
            this.LogMessage = string.Empty;
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
