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
using FairyZeta.Framework.WPF.ViewModels;
using FairyZeta.Framework;
using FairyZeta.Framework.Data;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Views
{
    /// <summary> FontDialogView
    /// </summary>
    public partial class FontEditView : UserControl
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> (Dependency) 変更対象フォントデータ </summary>
        public static readonly DependencyProperty EditFontInfoProperty =
                    DependencyProperty.Register("EditFontInfo", typeof(FontInfo), typeof(FontEditView), new FrameworkPropertyMetadata(new FontInfo(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnEditFontChanged));

        /// <summary> (Dependency) 変更対象フォントデータ </summary>
        public FontInfo EditFontInfo
        {
            get { return (FontInfo)GetValue(EditFontInfoProperty); }
            set { SetValue(EditFontInfoProperty, value); }
        }
        
        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public FontEditView()
        {
            this.InitializeComponent();
            this.RootGrid.DataContext = this;
            
            this.Loaded += (s, e) =>
            {
                this.ShowFontInfo();

                // リストボックスにフォーカスを設定する
                ListBox box;

                box = this.FontStyleListBox;
                if (box.SelectedItem != null)
                {
                    var item = box.ItemContainerGenerator.ContainerFromItem(box.SelectedItem) as ListBoxItem;
                    if (item != null)
                    {
                        item.Focus();
                    }
                }

                box = this.FontFamilyListBox;
                if (box.SelectedItem != null)
                {
                    var item = box.ItemContainerGenerator.ContainerFromItem(box.SelectedItem) as ListBoxItem;
                    if (item != null)
                    {
                        item.Focus();
                    }
                }
            };


            this.FontFamilyListBox.SelectionChanged += this.FontFamilyListBox_SelectionChanged;
            this.FontStyleListBox.SelectionChanged += this.FontStyleListBox_SelectionChanged;
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> EditFontInfo変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnEditFontChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            FontEditView v = obj as FontEditView;
            FontInfo f = e.NewValue as FontInfo;
            if(v != null && f != null)
            {
                //v.setFont();
                v.ShowFontInfo();
            }
        }


        private void FontFamilyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FontStyleListBox.SelectedIndex = 0;
            this.editFontChanged();
        }
        private void FontStyleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.editFontChanged();
        }
                
        private void ShowFontInfo()
        {
            if (EditFontInfo == null)
                return;

            //this.FontSizeTextBox.Text = this.EditFontInfo.Size.ToString("N1");

            int i = 0;
            foreach (FontFamily item in this.FontFamilyListBox.Items)
            {
                if (this.EditFontInfo.Family != null)
                {
                    if (item.Source == this.EditFontInfo.Family.Source ||
                        item.FamilyNames.Any(x => x.Value == this.EditFontInfo.Family.Source))
                    {
                        break;
                    }
                }

                i++;
            }

            if (i < this.FontFamilyListBox.Items.Count)
            {
                this.FontFamilyListBox.SelectedIndex = i;
                this.FontFamilyListBox.ScrollIntoView(this.FontFamilyListBox.Items[i]);
            }

            this.FontStyleListBox.SelectedItem = this.EditFontInfo.Typeface;
        }

        private void setFont()
        {
            this.PreviewTextBlock.FontSize = this.EditFontInfo.Size;
            this.PreviewTextBlock.FontFamily = this.EditFontInfo.Family;
            this.PreviewTextBlock.FontStretch = this.EditFontInfo.Stretch;
            this.PreviewTextBlock.FontWeight = this.EditFontInfo.Weight;
            this.PreviewTextBlock.FontStyle = this.EditFontInfo.Style;
        }

        private void editFontChanged()
        {
            FontInfo fi = this.PreviewTextBlock.GetFontInfo();

            this.EditFontInfo.FamilyName = fi.FamilyName;
            this.EditFontInfo.StyleString = fi.StyleString;
            this.EditFontInfo.WeightString = fi.WeightString;
            this.EditFontInfo.StretchString = fi.StretchString;
            
        }
    }
}
