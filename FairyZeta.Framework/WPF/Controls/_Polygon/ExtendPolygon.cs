using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace FairyZeta.Framework.WPF.Controls
{
    /// <summary> FZ／機能拡張型ポリゴン
    /// </summary>
    public class ExtendPolygon : Shape
    {
        private Geometry _DefiningGeometry;
        protected override Geometry DefiningGeometry 
        {
            get { return this._DefiningGeometry; }
        }
    }
}
