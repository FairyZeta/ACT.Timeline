using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using FairyZeta.Framework.Data;
using FairyZeta.FF14.ACT.Timeline.Core.WPF.ViewModels;
using Prism.Commands;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Views
{
    /// <summary> OutlineTextCustomView
    /// </summary>
    public partial class OutlineTextCustomView : UserControl
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty OutlineTextDataProperty =
                    DependencyProperty.Register("OutlineTextData"
                                                , typeof(OutlineTextData)
                                                , typeof(OutlineTextCustomView)
                                                , new FrameworkPropertyMetadata(null, OnOutlineTextDataChanged));

        public static readonly DependencyProperty InnerEditParamProperty =
                    DependencyProperty.Register("InnerEditParam"
                                                , typeof(ColorEditTarget)
                                                , typeof(OutlineTextCustomView)
                                                , new FrameworkPropertyMetadata(ColorEditTarget.Non, OnInnerEditParamChanged));

        public static readonly DependencyProperty OutlineEditParamProperty =
                    DependencyProperty.Register("OutlineEditParam"
                                                , typeof(ColorEditTarget)
                                                , typeof(OutlineTextCustomView)
                                                , new FrameworkPropertyMetadata(ColorEditTarget.Non, OnOutlineEditParamChanged));

        public static readonly DependencyProperty ShadowEditParamProperty =
                    DependencyProperty.Register("ShadowEditParam"
                                                , typeof(ColorEditTarget)
                                                , typeof(OutlineTextCustomView)
                                                , new FrameworkPropertyMetadata(ColorEditTarget.Non, OnShadowEditParamChanged));

        public static readonly DependencyProperty ColorEditCommandProperty =
                    DependencyProperty.Register("ColorEditCommand"
                                                , typeof(DelegateCommand<ColorEditTarget?>)
                                                , typeof(OutlineTextCustomView)
                                                , new FrameworkPropertyMetadata(null, OnEditCommandChanged));

        /// <summary> (Dependency) アウトライン設定データ </summary>
        public OutlineTextData OutlineTextData
        {
            get { return (OutlineTextData)GetValue(OutlineTextDataProperty); }
            set { SetValue(OutlineTextDataProperty, value); }
        }
        /// <summary> (Dependency) 内部変更パラメータ </summary>
        public ColorEditTarget InnerEditParam
        {
            get { return (ColorEditTarget)GetValue(InnerEditParamProperty); }
            set { SetValue(InnerEditParamProperty, value); }
        }
        /// <summary> (Dependency) 縁取り変更パラメータ </summary>
        public ColorEditTarget OutlineEditParam
        {
            get { return (ColorEditTarget)GetValue(OutlineEditParamProperty); }
            set { SetValue(OutlineEditParamProperty, value); }
        }
        /// <summary> (Dependency) シャドウ変更パラメータ </summary>
        public ColorEditTarget ShadowEditParam
        {
            get { return (ColorEditTarget)GetValue(ShadowEditParamProperty); }
            set { SetValue(ShadowEditParamProperty, value); }
        }

        /// <summary> (Dependency) シャドウ変更パラメータ </summary>
        public DelegateCommand<ColorEditTarget?> ColorEditCommand
        {
            get { return (DelegateCommand<ColorEditTarget?>)GetValue(ShadowEditParamProperty); }
            set { SetValue(ShadowEditParamProperty, value); }
        }
        
        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OutlineTextCustomView／コンストラクタ
        /// </summary>
        public OutlineTextCustomView()
        {
            this.InitializeComponent();

            this.RootGrid.DataContext = this;
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> OutlineTextData変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnOutlineTextDataChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            OutlineTextCustomView ctrl = obj as OutlineTextCustomView;
            if (ctrl != null)
            {
            }
        }

        /// <summary> InnerEditParam変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnInnerEditParamChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            OutlineTextCustomView ctrl = obj as OutlineTextCustomView;
            if (ctrl != null)
            {
                ctrl.InnerColorEditButton.CommandParameter = e.NewValue;
            }
        }
        /// <summary> OutlineEditParam変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnOutlineEditParamChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            OutlineTextCustomView ctrl = obj as OutlineTextCustomView;
            if (ctrl != null)
            {
                ctrl.OutlineColorEditButton.CommandParameter = e.NewValue;
            }
        }
        /// <summary> ShadowEditParam変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnShadowEditParamChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            OutlineTextCustomView ctrl = obj as OutlineTextCustomView;
            if (ctrl != null)
            {
                ctrl.ShadowColorEditButton.CommandParameter = e.NewValue;
            }
        }
        /// <summary> EditCommand変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnEditCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            OutlineTextCustomView ctrl = obj as OutlineTextCustomView;
            if (ctrl != null)
            {
                ctrl.InnerColorEditButton.Command = (DelegateCommand<ColorEditTarget?>)e.NewValue;
                ctrl.OutlineColorEditButton.Command = (DelegateCommand<ColorEditTarget?>)e.NewValue;
                ctrl.ShadowColorEditButton.Command = (DelegateCommand<ColorEditTarget?>)e.NewValue;
            }
        }


    }
}
