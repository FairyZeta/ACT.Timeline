using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace FairyZeta.Framework.Proc
{
    /// <summary> FZ／ファイルダウンロードプロセス
    /// </summary>
    public class FileDownloadProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> FZ／ファイルダウンロードプロセス／コンストラクタ
        /// </summary>
        public FileDownloadProcess()
            : base()
        {
            this.initProcess();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> プロセスの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initProcess()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="stringURI"> string: ダウンロード先のURIを文字列で指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。 </param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public Task<bool> FileDownloadAsync(string stringURI, string SavePath, string SaveFileName, SaveType saveType)
        {
            return new Task<bool>( () => this.FileDownload(new Uri(stringURI), SavePath, SaveFileName, saveType));
        }
        /// <summary> ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="stringURI"> string: ダウンロード先のURIを文字列で指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。 </param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public bool FileDownload(string stringURI, string SavePath, string SaveFileName, SaveType saveType)
        {
            return this.FileDownload(new Uri(stringURI), SavePath, SaveFileName, saveType);
        }
        
        /// <summary> ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="uri"> Uri: ダウンロード先のURIを指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。</param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public Task<bool> FileDownloadAsync(Uri uri, string SavePath, string SaveFileName, SaveType saveType)
        {
            return new Task<bool>(() => this.FileDownload(uri, SavePath, SaveFileName, saveType));
        }
        /// <summary> ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="uri"> Uri: ダウンロード先のURIを指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。</param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public bool FileDownload(Uri uri, string SavePath, string SaveFileName, SaveType saveType)
        {
            WebClient downloadClient = new WebClient();

            try
            {
                if (SavePath.Substring(SavePath.Length - 1) != "/")
                {
                    SavePath += "/";
                }

                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                if (File.Exists(SavePath + SaveFileName))
                {
                    switch (saveType)
                    {
                        case SaveType.NewFile:
                            return false;

                        case SaveType.OverRide:
                            break;
                    }
                }

                downloadClient.DownloadFile(uri, SavePath + SaveFileName);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
