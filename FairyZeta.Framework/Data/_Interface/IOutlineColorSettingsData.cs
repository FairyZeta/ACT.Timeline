using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.Framework.Data
{
    /// <summary> [IF] FZ／アウトラインカラー設定
    /// </summary>
    public interface IOutlineColorSettingsData
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 内部テキストカラー
        /// </summary>
        Color InnerTextColor { get; set; }

        /// <summary> 縁取りテキストカラー
        /// </summary>
        Color OutlineTextColor { get; set; }

        /// <summary> シャドウカラー
        /// </summary>
        Color ShadowColor { get; set; }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
