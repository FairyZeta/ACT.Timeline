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
    /// <summary> FZ／ImageTabItem
    /// </summary>
    public partial class ImageTabItem : TabItem
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty DefaultImageProperty =
            DependencyProperty.Register("DefaultImage", typeof(ImageSource), typeof(ImageTabItem), new FrameworkPropertyMetadata(default(ImageSource), OnDefaultImageChanged));
        public static readonly DependencyProperty IsSelectedImageProperty =
            DependencyProperty.Register("IsSelectedImage", typeof(ImageSource), typeof(ImageTabItem), new FrameworkPropertyMetadata(default(ImageSource), OnIsSelectedImageChanged));
        public static readonly DependencyProperty IsFocusedImageProperty =
            DependencyProperty.Register("IsFocusedImage", typeof(ImageSource), typeof(ImageTabItem), new FrameworkPropertyMetadata(default(ImageSource), OnIsFocusedImageChanged));
        public static readonly DependencyProperty IsMouseOverImageProperty =
            DependencyProperty.Register("IsMouseOverImage", typeof(ImageSource), typeof(ImageTabItem), new FrameworkPropertyMetadata(default(ImageSource), OnIsMouseOverImageChanged));
        public static readonly DependencyProperty IsDisabledImageProperty =
            DependencyProperty.Register("IsDisabledImage", typeof(ImageSource), typeof(ImageTabItem), new FrameworkPropertyMetadata(default(ImageSource), OnIsDisabledImageChanged));

        /// <summary> (Dependency) デフォルトイメージ </summary>
        public ImageSource DefaultImage
        {
            get 
            {
                var img = (ImageSource)GetValue(DefaultImageProperty);
                if (img != null)
                    return img;

                return null;
            }
            set { SetValue(DefaultImageProperty, value); }
        }
        /// <summary> (Dependency) 選択中イメージ </summary>
        public ImageSource IsSelectedImage
        {
            get 
            {
                var img = (ImageSource)GetValue(IsSelectedImageProperty);
                if (img != null)
                    return img;

                return this.DefaultImage;
            }
            set {  SetValue(IsSelectedImageProperty, value); }
        }
        /// <summary> (Dependency) フォーカス中イメージ </summary>
        public ImageSource IsFocusedImage
        {
            get
            {
                var img = (ImageSource)GetValue(IsFocusedImageProperty);
                if (img != null)
                    return img;

                return this.DefaultImage;
            }
            set { SetValue(IsFocusedImageProperty, value); }
        }
        /// <summary> (Dependency) マウスオーバー中イメージ </summary>
        public ImageSource IsMouseOverImage
        {
            get
            {
                var img = (ImageSource)GetValue(IsMouseOverImageProperty);
                if (img != null)
                    return img;

                return this.DefaultImage;
            }
            set { SetValue(IsMouseOverImageProperty, value); }
        }
        /// <summary> (Dependency) 無効状態イメージ </summary>
        public ImageSource IsDisabledImage
        {
            get
            {
                var img = (ImageSource)GetValue(IsDisabledImageProperty);
                if (img != null)
                    return img;

                return this.DefaultImage;
            } 
            set { SetValue(IsDisabledImageProperty, value); }
        }

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> FZ／ImageTabItem／コンストラクタ
        /// </summary>
        public ImageTabItem()
        {
            InitializeComponent();
        }

      /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> DefaultImage変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnDefaultImageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ImageTabItem ctrl = obj as ImageTabItem;
            ImageSource source = e.NewValue as ImageSource;
            if (ctrl != null)
            {
                if (ctrl.IsSelectedImage == null)
                    ctrl.IsSelectedImage = source;

                if (ctrl.IsFocusedImage == null)
                    ctrl.IsFocusedImage = source;

                if (ctrl.IsMouseOverImage == null)
                    ctrl.IsMouseOverImage = source;

                if (ctrl.IsDisabledImage == null)
                    ctrl.IsDisabledImage = source;
            }
        }

        /// <summary> IsSelectedImage変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnIsSelectedImageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ImageTabItem ctrl = obj as ImageTabItem;
            if (ctrl != null)
            {
            }
        }

        /// <summary> IsMouseOverImage変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnIsMouseOverImageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ImageTabItem ctrl = obj as ImageTabItem;
            if (ctrl != null)
            {
            }
        }

        /// <summary> IsFocusedImage変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnIsFocusedImageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ImageTabItem ctrl = obj as ImageTabItem;
            if (ctrl != null)
            {
            }
        }

        /// <summary> IsDisabledImage変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnIsDisabledImageChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ImageTabItem ctrl = obj as ImageTabItem;
            if (ctrl != null)
            {
            }
        }
    }
}
