using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FairyZeta.FF14.ACT.Logger.LogData;
using FairyZeta.FF14.ACT.Logger.Setting;

namespace FairyZeta.FF14.ACT.Logger.LogType.LogResult.LogLevel
{
    public abstract class _LogLevelBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        public LogStatusDefinition LogDefinition { get; set; }
        public LoggerSetting LoggerSetting { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <param name="in_LD"> LogDefinition:ロガー定義 </param>
        /// <param name="in_LS"> LoggerSetting:ロガーの設定モデル </param>
        /// <param name="in_LogResult"> LogResult:ログの状態を設定 </param>
        public _LogLevelBase(LogStatusDefinition in_LD, LoggerSetting in_LS, LogLevelEnum in_LogLevel)
        {
            LogStatusDefinition ld = new LogStatusDefinition()
            {
                LogLevelEnum = in_LogLevel,
                LogResultEnum = in_LD.LogResultEnum,
                LogTypeEnum = in_LD.LogTypeEnum
            };
            this.InitData(ld, in_LS);
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData(LogStatusDefinition in_LD, LoggerSetting in_LS)
        {
            this.LogDefinition = in_LD;
            this.LoggerSetting = in_LS;
        }

        /// <summary> ログの書き込みを実行し、生成したログファイルをフィードバックします。
        /// <para> -> プロジェクト名は「－」として書き込まれます。</para>
        /// </summary>
        /// <param name="in_LogMsg"> ログに書き込むメッセージ </param>
        public BasicLogData Write(string in_LogMsg)
        {
            BasicLogData log = new BasicLogData();
            log.LogMessage = in_LogMsg;
            log.ProjectName = "－";
            log.StackTrace = new StackTrace(true);

            this.write(log);

            return log;
        }

        /// <summary> ログの書き込みを実行し、生成したログファイルをフィードバックします。
        /// <para> -> 入力されたプロジェクト名をログファイルに書き込みます。</para>
        /// </summary>
        /// <param name="in_LogMsg"> ログに書き込むメッセージ </param>
        /// <param name="in_ProjectName"> ログ出力元のプロジェクト名 </param>
        public BasicLogData Write(string in_LogMsg, string in_ProjectName)
        {
            BasicLogData log = new BasicLogData();
            log.LogMessage = in_LogMsg;
            log.ProjectName = in_ProjectName;
            log.StackTrace = new StackTrace(true);

            this.write(log);

            return log;
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログ書き込み実行
        /// </summary>
        /// <param name="in_LogData"> ログメッセージ、プロジェクト名、スタックトレースを設定済のログデータ </param>
        private void write(BasicLogData in_LogData)
        {
            in_LogData.OutputTime = DateTime.Now;
            in_LogData.LogStatus.LogTypeEnum = this.LogDefinition.LogTypeEnum;
            in_LogData.LogStatus.LogResultEnum = this.LogDefinition.LogResultEnum;
            in_LogData.LogStatus.LogLevelEnum = this.LogDefinition.LogLevelEnum;

            this.LoggerSetting.LogWriter.Write(in_LogData);
        }
    }
}
