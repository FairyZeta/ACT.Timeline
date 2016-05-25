using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Interop;

namespace FairyZeta.Framework
{
    public static class FrameworkSettings
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> CPUレンダーモード
        /// <para> => [True] Cpu Render / [False] GPU Render </para>
        /// </summary>
        public static bool CpuRenderMode
        {
            set
            {
                if(value)
                {
                    RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
                }
                else
                {
                    RenderOptions.ProcessRenderMode = RenderMode.Default;
                }
            }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
      
      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/
        
      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/
      
      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/
      

    }
}
