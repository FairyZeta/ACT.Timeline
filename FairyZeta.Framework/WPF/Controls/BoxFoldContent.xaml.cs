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
    /// <summary> BoxFoldContent
    /// </summary>
    public partial class BoxFoldContent : UserControl
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty InnerDataTemplateProperty =
                    DependencyProperty.Register("InnerDataTemplate", typeof(DataTemplate), typeof(BoxFoldContent), new FrameworkPropertyMetadata(default(DataTemplate), OnInnerDataTemplateChanged));
        public static readonly DependencyProperty InnerDataContextProperty =
                    DependencyProperty.Register("InnerDataContext", typeof(object), typeof(BoxFoldContent), new FrameworkPropertyMetadata(null, OnInnerDataContextChanged));
        public static readonly DependencyProperty TitleProperty =
                    DependencyProperty.Register("Title", typeof(string), typeof(BoxFoldContent), new FrameworkPropertyMetadata(string.Empty, OnTitleChanged));
        public static readonly DependencyProperty TitleFontSizeProperty =
                    DependencyProperty.Register("TitleFontSize", typeof(double), typeof(BoxFoldContent), new FrameworkPropertyMetadata(12.0));
        public static readonly DependencyProperty IsContentOpenProperty =
                    DependencyProperty.Register("IsContentOpen", typeof(bool), typeof(BoxFoldContent), new FrameworkPropertyMetadata(true));
        public static readonly DependencyProperty BoxFoldTypeProperty =
                    DependencyProperty.Register("BoxFoldType", typeof(BoxFoldType), typeof(BoxFoldContent), new FrameworkPropertyMetadata(BoxFoldType.SimpleBox));
        public static readonly DependencyProperty ContentMinHeightProperty =
                    DependencyProperty.Register("ContentMinHeight", typeof(double), typeof(BoxFoldContent), new FrameworkPropertyMetadata(0.0));


        /// <summary> (Dependency) InnerDataTemplate </summary>
        public DataTemplate InnerDataTemplate
        {
            get { return (DataTemplate)GetValue(InnerDataTemplateProperty); }
            set { SetValue(InnerDataTemplateProperty, value); }
        }
        /// <summary> (Dependency) InnerDataContext </summary>
        public object InnerDataContext
        {
            get { return (object)GetValue(InnerDataContextProperty); }
            set { SetValue(InnerDataContextProperty, value); }
        }
        /// <summary> (Dependency) InnerDataTemplate </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        /// <summary> (Dependency) InnerDataTemplate </summary>
        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }
        /// <summary> (Dependency) InnerDataTemplate </summary>
        public bool IsContentOpen
        {
            get { return (bool)GetValue(IsContentOpenProperty); }
            set { SetValue(IsContentOpenProperty, value); }
        }
        /// <summary> (Dependency) BoxFoldType </summary>
        public BoxFoldType BoxFoldType
        {
            get { return (BoxFoldType)GetValue(BoxFoldTypeProperty); }
            set { SetValue(BoxFoldTypeProperty, value); }
        }
        /// <summary> (Dependency) ContentMinHeight </summary>
        public double ContentMinHeight
        {
            get { return (double)GetValue(ContentMinHeightProperty); }
            set { SetValue(ContentMinHeightProperty, value); }
        }


        public bool IsFoldEnabled { get; set; }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public BoxFoldContent()
        {
            InitializeComponent();
            this.RootGrid.DataContext = this;
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ControlTemplate変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnInnerDataTemplateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BoxFoldContent ctrl = obj as BoxFoldContent;
            if (ctrl != null)
            {
                ctrl.InnerContent.ContentTemplate = (DataTemplate)e.NewValue;
            }
        }
        /// <summary> Title変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnTitleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
        }
        /// <summary> InnerDataContext変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnInnerDataContextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            BoxFoldContent ctrl = obj as BoxFoldContent;
            if (ctrl != null)
            {
                //ctrl.InnerContent.Content = (object)e.NewValue;
            }
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
