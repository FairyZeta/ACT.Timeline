using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.FF14.ACT.Logger.Setting.Writer;
using FairyZeta.FF14.ACT.Logger.Setting.OutputLevel;
using FairyZeta.FF14.ACT.Logger.Setting.OutputSetting;

namespace FairyZeta.FF14.ACT.Logger.Setting
{
    public class LoggerSetting : _SettingBase
    {
      /*--- プロパティ/フィールド定義 ---------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ログ書込を実行するクラスを設定する </summary>
        public IWriter LogWriter { get; set; }

        /// <summary> ファイルログ出力の設定データ </summary>
        public FileLogSetting FileLogSetting { get; set; }
        /// <summary> ログ出力レベル設定データ </summary>
        public OutputLevelSetting OutputLevelSetting { get; set; }

      /*--- コンストラクタ --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> コンストラクタ
        /// </summary>
        public LoggerSetting()
            : base()
        {
            this.InitData();
        }

      /*--- メソッド：Public ------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> プロパティ/フィールドを初期化します。
        /// </summary>
        public void InitData()
        {
            this.FileLogSetting = new FileLogSetting();
            this.OutputLevelSetting = new OutputLevelSetting();
        }

        /// <summary> このロガーをテキスト(.txt)出力型としてセットアップします。
        /// <para> -> 引数なしは、デフォルト値の出力設定を使用してインスタンスを生成します。</para>
        /// </summary>
        public void SetupTextLogger()
        {
            // ファイルパス
            this.FileLogSetting.LogDictionary = "./";
            // ファイル名
            this.FileLogSetting.FileName = "syslog";
            // ファイル拡張子
            this.FileLogSetting.FileExtension = ".txt";
            // 日付出力 = あり
            this.FileLogSetting.AddFileNameDate = true;
            // 日付形式 = yyyyMMdd
            this.FileLogSetting.FileNameDateFormat = "yyyyMMdd";

            // ログ出力レベル＝全て
            this.OutputLevelSetting.SetOutputLevel(OutputLevelSetting.LevelPreset.All);

            this.LogWriter = new TextLogWrite(this.FileLogSetting, this.OutputLevelSetting);
        }


        /// <summary> このロガーをテキスト(.txt)出力型としてセットアップします。
        /// <para> -> セットアップされたファイルログ出力設定を使用して、インスタンスを生成します。</para>
        /// <para> -> ログ出力レベルはデフォルト（全て）を設定します。</para>
        /// <para> --- Code Hint ---</para>
        /// <para> (Logger) = new Logger();</para>
        /// <para> (Logger).LoggerSetting.FileLogSetting.FilePath = "xxxxx"; </para>
        /// <para> (Logger).LoggerSetting.FileLogSetting.FileName = "zzzzz"; </para>
        /// <para> (Logger).LoggerSetting.FileLogSetting.FileExtension = ".txt"; </para>
        /// <para> (Logger).LoggerSetting.FileLogSetting.AddFileNameDate = true or false; </para>
        /// <para>  |</para>
        /// <para> (Logger).LoggerSetting.SetupTextLogger((Logger).LoggerSetting.FileLogSetting); </para>
        /// </summary>
        public void SetupTextLogger(FileLogSetting in_FileLogSetting)
        {
            // ログ出力レベル＝全て
            this.OutputLevelSetting.SetOutputLevel(OutputLevelSetting.LevelPreset.All);
            
            this.LogWriter = new TextLogWrite(this.FileLogSetting, this.OutputLevelSetting);
        }

        /// <summary> このロガーをテキスト(.csv)出力型としてセットアップします。 </summary>
        public void SetupCsvLogger()
        {
        }

        /// <summary> このロガーをSQLite(.db)出力型としてセットアップします。 </summary>
        public void SetupSQLiteLogger()
        { 
        }

      /*--- メソッド：Private -----------------------------------------------------------------------------------------------------------------------------------------*/



    }
}
