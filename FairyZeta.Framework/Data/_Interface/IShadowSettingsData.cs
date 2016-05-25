using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.Framework.Data
{
    /// <summary> [IF] FZ／シャドウ設定
    /// </summary>
    public interface IShadowSettingsData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> シャドウカラー
        /// </summary>
        Color ShadowColor { get; set; }

        /// <summary> シャドウの有効状態 
        /// </summary>    
        bool ShadowEnabled { get; set; }

        /// <summary> シャドウの強さ 
        /// </summary>    
        double ShadowLevel { get; set; }

        /// <summary> シャドウの深さ 
        /// </summary>    
        double ShadowDepth { get; set; }

        /// <summary> シャドウの強さ 
        /// </summary>    
        double ShadowDirection { get; set; }

        /// <summary> シャドウの透過率 
        /// </summary>    
        double ShadowOpacity { get; }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
