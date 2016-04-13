using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace FairyZeta.Framework.Module
{
    /// <summary> FZ／ネットワークモジュール
    /// <para> => ローカルおよびインターネットの接続確認や特定URLへ接続の可否など、総合的にネットワークを管理します。 </para>
    /// </summary>
    public class NetworkModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ネットワークモジュール／コンストラクタ
        /// </summary>
        public NetworkModule()
            :base()
        {
            this.initModule();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ネットワークが有効であるかを確認します。
        /// <para> -> 有効であればTrue, 無効であればFalseを返却します。 </para>
        /// </summary>
        /// <returns> 有効:True / 無効:False </returns>
        public bool GetIsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続接続可能であればTrue, 不可能であればFalseを返却します。</para>
        /// </summary>
        /// <param name="stringURI"> string: 接続を確認したいURIの文字列を指定します。 </param>
        /// <returns></returns>
        public bool CheckWebResponse(string stringURI)
        {
            return this.CheckWebResponse(new Uri(stringURI));
        }

        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続接続可能であればTrue, 不可能であればFalseを返却します。</para>
        /// </summary>
        /// <param name="uri"> Uri: 接続を確認したいURIを指定します。 </param>
        /// <returns></returns>
        public bool CheckWebResponse(Uri uri)
        {
            HttpWebRequest webreq = null;
            HttpWebResponse webres = null;
            try
            {
                //HttpWebRequestの作成
                webreq = (HttpWebRequest)WebRequest.Create(uri);
                //メソッドをHEADにする
                webreq.Method = "HEAD";
                //受信する
                webres = (HttpWebResponse)webreq.GetResponse();
                //応答ステータスコードを表示
                //Console.WriteLine(webres.StatusCode);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (webres != null)
                {
                    webres.Close();
                }
            }
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
            return this.FileDownload(new Uri(stringURI), SavePath,SaveFileName, saveType);
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

                if(!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }

                if (File.Exists(SavePath + SaveFileName))
                {
                    switch(saveType)
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
            catch
            {
                return false;
            }
            finally
            {

            }
        }
      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
