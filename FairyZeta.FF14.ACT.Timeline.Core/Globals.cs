using System.IO;
using System.Text.RegularExpressions;
using FairyZeta.FF14.ACT.Logger;

namespace FairyZeta.FF14.ACT.Timeline.Core
{
    public class Globals
    {
        /// <summary> システムログ出力
        /// </summary>
        public static ActLogger SysLogger { get; set; }
        /// <summary> エラーログ出力
        /// </summary>
        public static ActLogger ErrLogger { get; set; }
        /// <summary> プロジェクト名
        /// </summary>
        public static string ProjectName { get; set; }

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

        static public string PluginDllDirectoryPath;
    }
}
