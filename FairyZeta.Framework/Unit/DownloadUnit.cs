using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Process;

namespace FairyZeta.Framework.Unit
{
    /// <summary> FZ／ダウンロードユニット／コンストラクタ
    /// </summary>
    public class DownloadUnit : _Unit
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ネットワーク確認プロセス
        /// </summary>
        private NetworkCheckProcess networkCheckProcess;
        /// <summary> ファイルダウンロードプロセス
        /// </summary>
        private FileDownloadProcess fileDownloadProcess;

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ダウンロードユニット／コンストラクタ
        /// </summary>
        public DownloadUnit()
            : base()
        {
            this.initUnit();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ユニットの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initUnit()
        {
            this.networkCheckProcess = new NetworkCheckProcess();
            this.fileDownloadProcess = new FileDownloadProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ネットワークチェック後、ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="stringURI"> string: ダウンロード先のURIを文字列で指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。 </param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public async Task<bool> FileDownloadAsync(string stringURI, string SavePath, string SaveFileName, SaveType saveType)
        {
            if (!await this.networkCheckProcess.GetIsNetworkAvailableAsync())
            {
                return false;
            }

            await this.networkCheckProcess.CheckWebResponseAsync(stringURI);

            return await this.fileDownloadProcess.FileDownloadAsync(stringURI, SavePath, SaveFileName, saveType);
        }
        /// <summary> ネットワークチェック後、ファイルをインターネット上からダウンロードし、保存します。
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
            try
            {
                if (!this.networkCheckProcess.GetIsNetworkAvailable())
                {
                    return false;
                }
                this.networkCheckProcess.CheckWebResponse(stringURI);

                this.fileDownloadProcess.FileDownload(stringURI, SavePath, SaveFileName, saveType);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        /// <summary> ネットワークチェック後、ファイルをインターネット上からダウンロードし、保存します。
        /// <para> -> ダウンロードから保存まで成功した場合は True、失敗した場合は False を返却します。</para>
        /// <para> #- 指定パスまでのフォルダが存在しない場合は、作成します。 </para>
        /// <para> #- 保存の方法は SaveType の引数で指定します。 </para>
        /// </summary>
        /// <param name="stringURI"> string: ダウンロード先のURIを文字列で指定します。 </param>
        /// <param name="SavePath"> string: 保存パスを指定します。 [!]ファイル名は含めません。 </param>
        /// <param name="SaveFileName"> string: セーブするファイル名を指定します。</param>
        /// <param name="saveType"> SaveType: 保存の方法を指定します。</param>
        /// <returns></returns>
        public async Task<bool> FileDownloadAsync(Uri pUri, string SavePath, string SaveFileName, SaveType saveType)
        {
            if (!await this.networkCheckProcess.GetIsNetworkAvailableAsync())
            {
                return false;
            }

            await this.networkCheckProcess.CheckWebResponseAsync(pUri);

            return await this.fileDownloadProcess.FileDownloadAsync(pUri, SavePath, SaveFileName, saveType);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
