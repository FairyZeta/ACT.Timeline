using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;

namespace FairyZeta.FF14.ACT.Timeline.Core.Forms
{
    public partial class ACTTabPageControl : UserControl
    {
        public PluginApplicationView PluginApplicationView
        {
            get { return this.pluginApplicationView1;  }
        }

        public ACTTabPageControl()
        {
            InitializeComponent();
        }
    }
}
