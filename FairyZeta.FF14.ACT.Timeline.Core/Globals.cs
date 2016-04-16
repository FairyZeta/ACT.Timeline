using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using FairyZeta.FF14.ACT.Logger;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    /// <summary> タイムライン／static
    /// </summary>
    public class Globals
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region #- [Property] ActLogger.SysLogger - ＜システムログ出力＞ -----
        /// <summary> システムログ出力 </summary>
        private static ActLogger _SysLogger;
        /// <summary> システムログ出力 </summary>
        public static ActLogger SysLogger
        {
            get 
            {
                if (_SysLogger == null) Globals.CreateLogger();

                return _SysLogger;
            }
            set { _SysLogger = value; }
        }
        #endregion 
        
        #region #- [Property] ActLogger.ErrLogger - ＜システムログ出力＞ -----
        /// <summary> エラーログ出力 </summary>
        private static ActLogger _ErrLogger;
        /// <summary> エラーログ出力 </summary>
        public static ActLogger ErrLogger
        {
            get
            {
                if (_ErrLogger == null) Globals.CreateLogger();

                return _ErrLogger;
            }
            set { _ErrLogger = value; }
        }
        #endregion 

        /// <summary> プロジェクト名
        /// </summary>
        public static string ProjectName { get; set; }

        /// <summary> プラグインDLLまでのパス
        /// </summary>
        public static string PluginDllDirectoryPath { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


        static private readonly Regex stripEndSlashesRegex = new Regex(@"/*$");
        static string StripEndSlashes(string pathstr)
        {
            return stripEndSlashesRegex.Replace(pathstr, "");
        }

        static private string resourceRoot;
        static public string ResourceRoot
        {
            get { return resourceRoot; }
            set
            {
                resourceRoot = StripEndSlashes(value);
            }
        }

        static public string SoundFilesRoot
        {
            get; //{ return ResourceRoot + "/wav"; }
            set;
        }

        static public int NumberOfSoundFilesInResourcesDir()
        {
            try
            {
                return Directory.GetFileSystemEntries(SoundFilesRoot, "*.wav").Length;
            }
            catch (DirectoryNotFoundException)
            {
                return 0;
            }
        }

        static public string TimelineTxtsRoot
        {
            get { return ResourceRoot + "/timeline"; }
        }

        static public string[] TimelineTxtsInResourcesDir
        {
            get
            {
                try
                {
                    return Directory.GetFileSystemEntries(TimelineTxtsRoot, "*.txt");
                }
                catch (DirectoryNotFoundException)
                {
                    return new string[] { };
                }
            }
        }

        public delegate void WriteLogDelegate(string str);
        static public WriteLogDelegate WriteLogImpl = System.Console.WriteLine;

        static public void WriteLog(string str)
        {
            WriteLogImpl(str);
        }

        public delegate string FetchUrlDelegate(string url);
        static public FetchUrlDelegate FetchUrlImpl = FetchUrlUsingWebRequest;

        static public string FetchUrl(string url)
        {
            return FetchUrlImpl(url);
        }

        static public string FetchUrlUsingWebRequest(string url)
        {
            var client = new System.Net.WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            return client.DownloadString(url);
        }

        static public bool ResetTimelineCombatEnd;

        /// <summary> ロガーの生成を実行します。
        /// </summary>
        public static void CreateLogger()
        {
            if (string.IsNullOrWhiteSpace(Globals.PluginDllDirectoryPath))
            {
                Globals.PluginDllDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            // Globals設定
            Globals.ProjectName = "Timeline.Core";

            // システムメッセージ用ロガー生成
            if (Globals._SysLogger == null)
            {
                Globals._SysLogger = new FF14.ACT.Logger.ActLogger();
                Globals._SysLogger.Setting.FileLogSetting.LogDictionary = Globals.PluginDllDirectoryPath + "/Log/System";
                Globals._SysLogger.Setting.FileLogSetting.FileName = "SysLog";
                Globals._SysLogger.Setting.FileLogSetting.FileExtension = ".txt";
                Globals._SysLogger.Setting.FileLogSetting.AddFileNameDate = true;
                Globals._SysLogger.Setting.FileLogSetting.FileNameDateFormat = "yyyyMMdd";
                Globals._SysLogger.Setting.SetupTextLogger(Globals.SysLogger.Setting.FileLogSetting);
            }
            // スタックトレース用ロガー生成
            if (Globals._ErrLogger == null)
            {
                Globals._ErrLogger = new FF14.ACT.Logger.ActLogger();
                Globals._ErrLogger.Setting.FileLogSetting.LogDictionary = Globals.PluginDllDirectoryPath + "/Log/Error";
                Globals._ErrLogger.Setting.FileLogSetting.FileName = "ErrorLog";
                Globals._ErrLogger.Setting.FileLogSetting.FileExtension = ".txt";
                Globals._ErrLogger.Setting.FileLogSetting.AddFileNameDate = true;
                Globals._ErrLogger.Setting.FileLogSetting.FileNameDateFormat = "yyyyMMdd_HHmmss";
                Globals._ErrLogger.Setting.SetupTextLogger(Globals.ErrLogger.Setting.FileLogSetting);
            }
        }
    }
}
