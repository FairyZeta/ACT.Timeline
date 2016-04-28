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
    /// <summary> IntUpDownControl
    /// </summary>
    public partial class IntUpDownControl : UserControl
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty ChangedValueProperty =
                    DependencyProperty.Register("ChangedValue", typeof(int), typeof(IntUpDownControl), new FrameworkPropertyMetadata(0, OnValueChanged));

        public static readonly DependencyProperty UpValueProperty =
                    DependencyProperty.Register("UpValue", typeof(int), typeof(IntUpDownControl), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty DownValueProperty =
                    DependencyProperty.Register("DownValue", typeof(int), typeof(IntUpDownControl), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MinValueProperty =
                    DependencyProperty.Register("MinValue", typeof(int), typeof(IntUpDownControl), new FrameworkPropertyMetadata(-1000000, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static readonly DependencyProperty MaxValueProperty =
                    DependencyProperty.Register("MaxValue", typeof(int), typeof(IntUpDownControl), new FrameworkPropertyMetadata(1000000, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary> (Dependency) 変更対象のint </summary>
        public int ChangedValue
        {
            get { return (int)GetValue(ChangedValueProperty); }
            set { SetValue(ChangedValueProperty, value); }
        }
        /// <summary> (Dependency) upによる上昇int(規定値: 1) </summary>
        public int UpValue
        {
            get { return (int)GetValue(UpValueProperty); }
            set { SetValue(UpValueProperty, value); }
        }
        /// <summary> (Dependency) downによる下降int(規定値:-1) </summary>
        public int DownValue
        {
            get { return (int)GetValue(DownValueProperty); }
            set { SetValue(DownValueProperty, value); }
        }
        /// <summary> (Dependency) intの最小値 </summary>
        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        /// <summary> (Dependency) intの最大値 </summary>
        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> DoubleUpDownControl／コンストラクタ
        /// </summary>
        public IntUpDownControl()
        {
            InitializeComponent();

            this.RootGrid.DataContext = this;
            this.ChangedValue = 0;

            this.ValueBox.PreviewKeyDown += this.ValueBox_PreviewKeyDown;
            
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
            IntUpDownControl ctrl = obj as IntUpDownControl;
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
                int i = Convert.ToInt32(tb.Text);
                this.ChangedValue = i;
                this.ValueBox.Text = i.ToString();
            }
            catch
            {
                this.ValueBox.Text = reset;
                return;
            }

        }

        private void ValueBox_PreviewKeyDown(object sender, KeyEventArgs e)
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
