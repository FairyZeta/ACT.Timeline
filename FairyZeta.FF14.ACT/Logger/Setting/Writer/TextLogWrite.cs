using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using FairyZeta.FF14.ACT.Logger.LogData;
using FairyZeta.FF14.ACT.Logger.Setting.OutputLevel;
using FairyZeta.FF14.ACT.Logger.Setting.OutputSetting;

namespace FairyZeta.FF14.ACT.Logger.Setting.Writer
{
    /// <summary> ログファイルをテキスト形式で書き込む機能を提供します。
    /// </summary>
    public class TextLogWrite : _WriterBase, IWriter
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログファイルの出力設定データ
        /// </summary>
        public OutputLevelSetting OutputLevelSetting { get; set; }
        /// <summary> ログ出力のレベル
        /// </summary>
        public FileLogSetting FileLogSetting { get; set; }
        /// <summary> ログファイルのエンコード
        /// </summary>
        public Encoding LogEncoding { get; set; }

        /// <summary> このロガーが生成された時間
        /// </summary>
        private DateTime writerCreationTime;
        /// <summary> 実行アセンブリ(.exe)から、ファイル名.拡張子を含むログファイルまでのパス
        /// </summary>
        private string logWritePath;

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        /// <param name="in_LogSetting"> ログファイルの出力設定データ </param>
        /// <param name="in_LevelSetting"> ログ出力のレベル </param>
        public TextLogWrite(FileLogSetting in_LogSetting, OutputLevelSetting in_LevelSetting)
            : base()
        {
            this.FileLogSetting = in_LogSetting;
            this.OutputLevelSetting = in_LevelSetting;
            this.LogEncoding = Encoding.GetEncoding("utf-8");

            this.writerCreationTime = DateTime.Now;

            if (this.FileLogSetting.AddFileNameDate)
            {
                string dateString = "_" + this.writerCreationTime.ToString(this.FileLogSetting.FileNameDateFormat);
                this.logWritePath = Path.Combine(
                    this.FileLogSetting.FilePath, this.FileLogSetting.FileName + dateString + this.FileLogSetting.FileExtension);
            }
            else
            {
                this.logWritePath = Path.Combine(
                    this.FileLogSetting.FilePath, this.FileLogSetting.FileName + this.FileLogSetting.FileExtension);
            }
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> [IF] ログファイルへの書き込みを実行します。
        /// </summary>
        /// <param name="in_LogData"></param>
        public void Write(ILogData in_LogData)
        {
            // ログレベルが書き込み対象であるか確認
            if (!base.WriteLevelCheck(in_LogData, this.OutputLevelSetting))
            {
                return;
            }

            // ログフォルダが存在するかどうか確認
            if (!Directory.Exists(this.FileLogSetting.FilePath))
            {
                return;
            }

            // 日付が変わっていた場合、ファイル名をリネームする
            if ((DateTime.Now.Year > this.writerCreationTime.Year) || (this.writerCreationTime.DayOfYear > DateTime.Now.DayOfYear))
            {
                this.writerCreationTime = DateTime.Now;

                if (this.FileLogSetting.AddFileNameDate)
                {
                    string dateString = "_" + this.writerCreationTime.ToString(this.FileLogSetting.FileNameDateFormat);
                    this.logWritePath = Path.Combine(
                        this.FileLogSetting.FilePath, this.FileLogSetting.FileName + dateString + this.FileLogSetting.FileExtension);
                }
                else
                {
                    this.logWritePath = Path.Combine(
                        this.FileLogSetting.FilePath, this.FileLogSetting.FileName + this.FileLogSetting.FileExtension);
                }
            }

            // ログ書き込みの文字列を生成
            string msg = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, <{6}.{7}()>, Line {8}"
                , in_LogData.OutputTime.ToString("yyyy/MM/dd HH:mm:ss.fff")
                , in_LogData.LogStatus.LogTypeEnum
                , in_LogData.LogStatus.LogResultEnum
                , in_LogData.LogStatus.LogLevelEnum
                , in_LogData.ProjectName
                , in_LogData.LogMessage
                , in_LogData.StackTrace.GetFrame(1).GetMethod().ReflectedType.FullName
                , in_LogData.StackTrace.GetFrame(1).GetMethod().Name
                , in_LogData.StackTrace.GetFrame(1).GetFileLineNumber().ToString()
                );

            // ログの書き込みを実行
            if (File.Exists(this.logWritePath))
            {
                File.AppendAllText(this.logWritePath, msg + "\r\n", this.LogEncoding);
            }
            else
            {
                File.WriteAllText(this.logWritePath, msg + "\r\n", this.LogEncoding);
            }
        }

        /// <summary> [IF] ログファイルへのスタックトレース書き込みを実行します。
        /// </summary>
        /// <param name="ex"></param>
        public void Write_StackTrace(Exception ex, int rank = 0)
        {
            // ログフォルダが存在するかどうか確認
            if (!Directory.Exists(this.FileLogSetting.FilePath))
            {
                // フォルダが無いと、どうにもならないので終了…
                return;
            }

            // ログの書き込みを実行
            if (File.Exists(this.logWritePath))
            {
                File.AppendAllText(this.logWritePath, "***** # " + ex.GetType().Name + " *****" + "\r\n", this.LogEncoding);
            }
            else
            {
                File.WriteAllText(this.logWritePath, "***** # " + ex.GetType().Name + " *****" + "\r\n", this.LogEncoding);
            }

            File.AppendAllText(this.logWritePath, "Exception Time: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "\r\n", this.LogEncoding);
            File.AppendAllText(this.logWritePath, "Rank: " + rank + "\r\n", this.LogEncoding);
            File.AppendAllText(this.logWritePath, "Message: " + ex.Message + "\r\n", this.LogEncoding);
            File.AppendAllText(this.logWritePath, "Stack Trace: " + "\r\n", this.LogEncoding);
            File.AppendAllText(this.logWritePath, ex.StackTrace + "\r\n\r\n", this.LogEncoding);

            if (ex.InnerException != null)
            {
                File.AppendAllText(this.logWritePath, " --- InnerException --- " + "\r\n", this.LogEncoding);
                Write_StackTrace(ex.InnerException, rank + 1);
            }
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
