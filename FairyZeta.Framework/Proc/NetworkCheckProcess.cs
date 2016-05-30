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
    /// <summary> FZ／ネットワークチェックプロセス
    /// <para> => ローカルおよびインターネットの接続確認や特定URLへ接続の可否など。 </para>
    /// </summary>
    public class NetworkCheckProcess : _Process
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ネットワークチェックプロセス／コンストラクタ
        /// </summary>
        public NetworkCheckProcess()
            :base()
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

        /// <summary> ネットワークが有効であるかを確認します。
        /// <para> -> 有効であればTrue, 無効であればFalseを返却します。 </para>
        /// </summary>
        /// <returns> 有効:True / 無効:False </returns>
        public Task<bool> GetIsNetworkAvailableAsync()
        {
            return new Task<bool>(() => this.GetIsNetworkAvailable());
        }
        /// <summary> ネットワークが有効であるかを確認します。
        /// <para> -> 有効であればTrue, 無効であればFalseを返却します。 </para>
        /// </summary>
        /// <returns> 有効:True / 無効:False </returns>
        public bool GetIsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続不可能であればExceptionを返却します。</para>
        /// </summary>
        /// <param name="stringURI"> string: 接続を確認したいURIの文字列を指定します。 </param>
        /// <returns></returns>
        public Task CheckWebResponseAsync(string stringURI)
        {
            return new Task(() => this.CheckWebResponse(new Uri(stringURI)));
        }
        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続不可能であればExceptionを返却します。</para>
        /// </summary>
        /// <param name="stringURI"> string: 接続を確認したいURIの文字列を指定します。 </param>
        /// <returns></returns>
        public void CheckWebResponse(string stringURI)
        {
            try
            {
                this.CheckWebResponse(new Uri(stringURI));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続不可能であればExceptionを返却します。</para>
        /// </summary>
        /// <param name="uri"> Uri: 接続を確認したいURIを指定します。 </param>
        /// <returns></returns>
        public Task CheckWebResponseAsync(Uri uri)
        {
            return new Task(() => this.CheckWebResponse(uri));
        }
        /// <summary> 指定のURIへ接続可能かを確認します。
        /// <para> -> 接続不可能であればExceptionを返却します。</para>
        /// </summary>
        /// <param name="uri"> Uri: 接続を確認したいURIを指定します。 </param>
        /// <returns></returns>
        public void CheckWebResponse(Uri uri)
        {
            HttpWebRequest webreq = null;
            HttpWebResponse webres = null;
            try
            {
                //HttpWebRequestの作成
                webreq = (HttpWebRequest)WebRequest.Create(uri);
                //メソッドをHEADにする
                webreq.Method = "GET";
                //受信する
                webres = (HttpWebResponse)webreq.GetResponse();
                //応答ステータスコードを表示
                Console.WriteLine(webres.StatusCode);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (webres != null)
                {
                    webres.Close();
                }
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
