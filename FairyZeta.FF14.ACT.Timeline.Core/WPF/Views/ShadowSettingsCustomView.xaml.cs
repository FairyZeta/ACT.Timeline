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
    /// <summary> ShadowSettingsCustomView
    /// </summary>
    public partial class ShadowSettingsCustomView : UserControl
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty ShadowSettingsDataProperty =
                    DependencyProperty.Register("ShadowSettingsData"
                                                , typeof(ShadowSettingsData)
                                                , typeof(ShadowSettingsCustomView)
                                                , new FrameworkPropertyMetadata(null, OnShadowSettingsDataChanged));

        public static readonly DependencyProperty BaseEditParamProperty =
                    DependencyProperty.Register("BaseEditParam"
                                                , typeof(ColorEditTarget)
                                                , typeof(ShadowSettingsCustomView)
                                                , new FrameworkPropertyMetadata(ColorEditTarget.Non, OnBaseEditParamChanged));

        public static readonly DependencyProperty ShadowEditParamProperty =
                    DependencyProperty.Register("ShadowEditParam"
                                                , typeof(ColorEditTarget)
                                                , typeof(ShadowSettingsCustomView)
                                                , new FrameworkPropertyMetadata(ColorEditTarget.Non, OnShadowEditParamChanged));

        public static readonly DependencyProperty ColorEditCommandProperty =
                    DependencyProperty.Register("ColorEditCommand"
                                                , typeof(DelegateCommand<ColorEditTarget?>)
                                                , typeof(ShadowSettingsCustomView)
                                                , new FrameworkPropertyMetadata(null, OnEditCommandChanged));

        /// <summary> (Dependency) シャドウ設定データ </summary>
        public ShadowSettingsData ShadowSettingsData
        {
            get { return (ShadowSettingsData)GetValue(ShadowSettingsDataProperty); }
            set { SetValue(ShadowSettingsDataProperty, value); }
        }
        /// <summary> (Dependency) ベース変更パラメータ </summary>
        public ColorEditTarget BaseEditParam
        {
            get { return (ColorEditTarget)GetValue(BaseEditParamProperty); }
            set { SetValue(BaseEditParamProperty, value); }
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

        /// <summary> ShadowSettingsCustomView／コンストラクタ
        /// </summary>
        public ShadowSettingsCustomView()
        {
            this.InitializeComponent();

            this.RootGrid.DataContext = this;
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ShadowSettingsData変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnShadowSettingsDataChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ShadowSettingsCustomView ctrl = obj as ShadowSettingsCustomView;
            if (ctrl != null)
            {
            }
        }

        /// <summary> BaseEditParam変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnBaseEditParamChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ShadowSettingsCustomView ctrl = obj as ShadowSettingsCustomView;
            if (ctrl != null)
            {
                ctrl.BaseColorEditButton.CommandParameter = e.NewValue;
            }
        }
        /// <summary> ShadowEditParam変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnShadowEditParamChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ShadowSettingsCustomView ctrl = obj as ShadowSettingsCustomView;
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
            ShadowSettingsCustomView ctrl = obj as ShadowSettingsCustomView;
            if (ctrl != null)
            {
                ctrl.BaseColorEditButton.Command = (DelegateCommand<ColorEditTarget?>)e.NewValue;
                ctrl.ShadowColorEditButton.Command = (DelegateCommand<ColorEditTarget?>)e.NewValue;
            }
        }


    }
}
