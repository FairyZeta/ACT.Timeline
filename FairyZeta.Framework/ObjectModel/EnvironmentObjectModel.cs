using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Framework.Data;

namespace FairyZeta.Framework.ObjectModel
{
    /// <summary> FZ／環境情報オブジェクトモデル
    /// </summary>
    public class EnvironmentObjectModel
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OS環境情報データ
        /// </summary>
        public OsEnvironmentData OsEnvironmentData { get; private set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／OS環境情報オブジェクトモデル／コンストラクタ
        /// </summary>
        public EnvironmentObjectModel()
            : base()
        {
            this.initObjectModel();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> オブジェクトモデルの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initObjectModel()
        {
            this.OsEnvironmentData = new OsEnvironmentData();
            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OS環境情報を確認し、自身の環境情報データに格納します。
        /// </summary>
        /// <returns>  </returns>
        public bool CreateOsEnvironment()
        {
            this.OsEnvironmentData.IsOperating64Bit = System.Environment.Is64BitOperatingSystem;
            this.OsEnvironmentData.IsProcess64Bit = System.Environment.Is64BitProcess;

            this.OsEnvironmentData.OperatingSystem = System.Environment.OSVersion;
            this.OsEnvironmentData.RunCLR = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            this.OsEnvironmentData.BuildCLR = System.Reflection.Assembly.GetExecutingAssembly().ImageRuntimeVersion;

            string osBit = string.Empty;
            if (this.OsEnvironmentData.IsOperating64Bit)
            {
                osBit = " - 64bit";
            }
            else
            {
                osBit = " - 32bit";
            }


            return true;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
