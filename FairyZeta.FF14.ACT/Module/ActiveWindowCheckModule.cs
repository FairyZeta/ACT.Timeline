using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FairyZeta.Framework;

namespace FairyZeta.FF14.ACT.Module
{
    /// <summary> ACT/アクティブウィンドウチェックモジュール
    /// </summary>
    public class ActiveWindowCheckModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        /// <summary> ACT/アクティブウィンドウチェックモジュール／コンストラクタ
        /// </summary>
        public ActiveWindowCheckModule()
            : base()
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

        /// <summary> ACT本体またはFF14のウィンドウがアクティブかを確認し、bool値を返します。
        /// <para> ※64Bitじゃないと落ちる可能性有、注意 </para>
        /// </summary>
        /// <returns></returns>
        public bool ActRelationWindowActiveCheck()
        {
            try
            {
                uint pid;
                var hWndFg = WindowsServices.GetForegroundWindow();
                if (hWndFg == IntPtr.Zero)
                {
                    // アクティブウィンドウ無し
                    return false;
                }

                WindowsServices.GetWindowThreadProcessId(hWndFg, out pid);
                var exePath = System.Diagnostics.Process.GetProcessById((int)pid).MainModule.FileName;

                if (Path.GetFileName(exePath.ToString()) == "ffxiv.exe" ||
                    Path.GetFileName(exePath.ToString()) == "ffxiv_dx11.exe" ||
                    exePath.ToString() == System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ExecutionEngineException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary> ACT本体のウィンドウがアクティブかを確認し、Bool値を返します。
        /// </summary>
        /// <returns></returns>
        //public bool ActWindowActiveCheck()
        //{
        //    return true;
        //}

        /// <summary> FF14のウィンドウがアクティブかを確認し、Bool値を返します。
        /// </summary>
        /// <returns></returns>
        //public bool FF14WindowActiveCheck()
        //{
        //    return true;
        //}

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/



    }
}
