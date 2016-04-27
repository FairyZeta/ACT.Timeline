using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.Views;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;

namespace FairyZeta.FF14.ACT.Timeline.FormsTest
{
    public partial class Form1 : Form
    {
        PluginApplicationViewModel vm; 

        public Form1()
        {
            InitializeComponent();

            
            var view = this.elementHost1.Child as PluginApplicationView;
            this.vm = view.DataContext as PluginApplicationViewModel;
            vm.ApplicationSetup();

            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.vm.ApplicationExit();
        }
    }
}
