using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Windows.Media.Animation;

namespace FairyZeta.Framework.WPF.Controls
{
    /// <summary> DoubleUpDownControl
    /// </summary>
    public partial class DoubleUpDownControl : UserControl
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty ChangedValueProperty =
                    DependencyProperty.Register("ChangedValue", typeof(double), typeof(DoubleUpDownControl), new FrameworkPropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty UpValueProperty =
                    DependencyProperty.Register("UpValue", typeof(double), typeof(DoubleUpDownControl), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty DownValueProperty =
                    DependencyProperty.Register("DownValue", typeof(double), typeof(DoubleUpDownControl), new FrameworkPropertyMetadata(-1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MinValueProperty =
                    DependencyProperty.Register("MinValue", typeof(double), typeof(DoubleUpDownControl), new FrameworkPropertyMetadata(-1000000.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxValueProperty =
                    DependencyProperty.Register("MaxValue", typeof(double), typeof(DoubleUpDownControl), new FrameworkPropertyMetadata(1000000.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary> (Dependency) 変更対象のdouble </summary>
        public double ChangedValue
        {
            get { return (double)GetValue(ChangedValueProperty); }
            set 
            {
                SetValue(ChangedValueProperty, value); 
            }
        }
        /// <summary> (Dependency) upによる上昇double(規定値: 1.0) </summary>
        public double UpValue
        {
            get { return (double)GetValue(UpValueProperty); }
            set { SetValue(UpValueProperty, value); }
        }
        /// <summary> (Dependency) downによる下降double(規定値:-1.0) </summary>
        public double DownValue
        {
            get { return (double)GetValue(DownValueProperty); }
            set { SetValue(DownValueProperty, value); }
        }
        /// <summary> (Dependency) doubleの最小値 </summary>
        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        /// <summary> (Dependency) doubleの最大値 </summary>
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ValueUpDownControl／コンストラクタ
        /// </summary>
        public DoubleUpDownControl()
        {
            InitializeComponent();

            this.RootGrid.DataContext = this;
            this.ChangedValue = 0.0;

            this.ValueBox.TextChanged += this.textChanged;
            this.ValueBox.PreviewKeyDown += this.keyDown;

            this.ValueUpButton.Click += (s, e) => this.valueUp();
            this.ValueDownButton.Click += (s, e) => this.valueDown();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> UpDownValue変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            DoubleUpDownControl ctrl = obj as DoubleUpDownControl;
            if (ctrl != null)
            {
                ctrl.ValueBox.Text = e.NewValue.ToString();
            }
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (NumericTextBox)sender;
            if (tb == null)
            {
                return;
            }
            else if (tb.Text == this.ValueBox.Text)
            {
                return;
            }


            string reset = tb.Text;

            try
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    this.ValueBox.Text = "0";
                    return;
                }
                double d = Convert.ToDouble(tb.Text);
                this.ChangedValue = d;
                this.ValueBox.Text = d.ToString();
            }
            catch
            {
                this.ValueBox.Text = reset;
                return;
            }

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.IsDown && e.Key == Key.Up)
            {
                this.valueUp();
            }
            else if (e.IsDown && e.Key == Key.Down)
            {
                this.valueDown();
            }
        } 

        /// <summary> 値の上昇を実行します。
        /// </summary>
        private void valueUp()
        {
            if (this.ChangedValue < this.MaxValue)
                this.ChangedValue += this.UpValue;
        }

        /// <summary> 値の下降を実行します。
        /// </summary>
        private void valueDown()
        {
            if (this.ChangedValue > this.MinValue)
                this.ChangedValue += this.DownValue;
        }
    }
}
