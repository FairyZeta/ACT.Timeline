using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FairyZeta.Framework.Data
{
    public class AseColorEntryData : _BlockData
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public byte B { get; set; }

        public byte G { get; set; }

        public byte R { get; set; }

        public AseColorType Type { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/
        
        public AseColorEntryData()
        { 
        }

        //public ColorEntryData(Color color)
        //  : this(color.name, color)
        //{ 
        //}

        public AseColorEntryData(string name, Color color)
          : this(name, color.R, color.G, color.B)
        { 
        }

        public AseColorEntryData(byte r, byte g, byte b)
          : this(null, r, g, b)
        { 
        }

        public AseColorEntryData(string name, byte r, byte g, byte b)
          : this()
        {
          this.Name = name;
          this.R = r;
          this.G = g;
          this.B = b;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        public Color ToColor()
        {
            return Color.FromArgb(0xFF, this.R, this.G, this.B);
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

  }
}
