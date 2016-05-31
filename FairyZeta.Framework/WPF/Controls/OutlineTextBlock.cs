using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FairyZeta.Framework.WPF.Controls
{
    public class OutlineTextBlock : FrameworkElement
    {
        private FormattedText FormattedText;
        private Geometry TextGeometry;

        public DropShadowEffect TextShadowEffect { get; set; }

        public OutlineTextBlock()
        {
            this.TextDecorations = new TextDecorationCollection();
        }

        #region DependencyProperty
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextInvalidated));

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register(
            "TextAlignment", typeof(TextAlignment), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextDecorationsProperty = DependencyProperty.Register(
            "TextDecorations", typeof(TextDecorationCollection), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextTrimmingProperty = DependencyProperty.Register(
            "TextTrimming", typeof(TextTrimming), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register(
            "TextWrapping", typeof(TextWrapping), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(TextWrapping.NoWrap, OnFormattedTextUpdated));

        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
            "Fill", typeof(Brush), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(Brushes.Red, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
            "Stroke", typeof(Brush), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
            "StrokeThickness", typeof(double), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.AddOwner(
            typeof(OutlineTextBlock), new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontSizeProperty = TextElement.FontSizeProperty.AddOwner(
            typeof(OutlineTextBlock), new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontStretchProperty = TextElement.FontStretchProperty.AddOwner(
            typeof(OutlineTextBlock), new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.AddOwner(
            typeof(OutlineTextBlock), new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.AddOwner(
            typeof(OutlineTextBlock), new FrameworkPropertyMetadata(OnFormattedTextUpdated));

        public static readonly DependencyProperty TextShadowEffectProperty = DependencyProperty.Register(
            "TextShadowEffect", typeof(DropShadowEffect), typeof(OutlineTextBlock),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty DrawingReverseModeProperty
            = DependencyProperty.Register("DrawingReverseMode", typeof(bool), typeof(OutlineTextBlock), new FrameworkPropertyMetadata(false, OnDrawingReverseModeChanged));

        #endregion

        #region BindProperty
        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        public FontFamily FontFamily
        {
            get { return (FontFamily)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public FontStretch FontStretch
        {
            get { return (FontStretch)GetValue(FontStretchProperty); }
            set { SetValue(FontStretchProperty, value); }
        }

        public FontStyle FontStyle
        {
            get { return (FontStyle)GetValue(FontStyleProperty); }
            set { SetValue(FontStyleProperty, value); }
        }

        public FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection)this.GetValue(TextDecorationsProperty); }
            set { this.SetValue(TextDecorationsProperty, value); }
        }

        public TextTrimming TextTrimming
        {
            get { return (TextTrimming)GetValue(TextTrimmingProperty); }
            set { SetValue(TextTrimmingProperty, value); }
        }

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public bool DrawingReverseMode
        {
            get { return (bool)GetValue(DrawingReverseModeProperty); }
            set { SetValue(DrawingReverseModeProperty, value); }
        }
        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.StrokeThickness <= 0d)
            {
                if (this.FormattedText == null)
                {
                    this.EnsureFormattedText();
                }

                drawingContext.DrawText(this.FormattedText, new Point());
            }
            else
            {
                this.EnsureGeometry();

                if (this.DrawingReverseMode)
                {
                    // ２重処理して、アウトライン=>メインテキストの順番に描画する
                    drawingContext.DrawGeometry(null, new Pen(this.Stroke, this.StrokeThickness), this.TextGeometry);
                    drawingContext.DrawGeometry(this.Fill, null, this.TextGeometry);
                }
                else
                {
                    // 通常通り、メインテキスト=>アウトラインの順番に描画する
                    drawingContext.DrawGeometry(this.Fill, new Pen(this.Stroke, this.StrokeThickness), this.TextGeometry);
                }  
            }

        }

        protected override Size MeasureOverride(Size availableSize)
        {
            this.EnsureFormattedText();

            if (this.FormattedText != null)
            {
                this.FormattedText.MaxTextWidth = Math.Min(3579139, availableSize.Width);
                this.FormattedText.MaxTextHeight = availableSize.Height > 0.0d ? availableSize.Height : 1.0d;
                return new Size(this.FormattedText.Width * 1.05d, this.FormattedText.Height);
            }
            else
            {
                return new Size();
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.EnsureFormattedText();

            if (this.FormattedText != null)
            {
                this.FormattedText.MaxTextWidth = finalSize.Width > 0.0d ? finalSize.Width : 1.0d;
                this.FormattedText.MaxTextHeight = finalSize.Height > 0.0d ? finalSize.Height : 1.0d;
            }

            this.TextGeometry = null;

            return finalSize;
        }

        private static void OnFormattedTextInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var outlinedTextBlock = (OutlineTextBlock)dependencyObject;
            outlinedTextBlock.FormattedText = null;
            outlinedTextBlock.TextGeometry = null;

            outlinedTextBlock.InvalidateMeasure();
            outlinedTextBlock.InvalidateVisual();
        }

        private static void OnFormattedTextUpdated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var outlinedTextBlock = (OutlineTextBlock)dependencyObject;
            outlinedTextBlock.UpdateFormattedText();
            outlinedTextBlock.TextGeometry = null;

            outlinedTextBlock.InvalidateMeasure();
            outlinedTextBlock.InvalidateVisual();
        }

        private static void OnDrawingReverseModeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var outlinedTextBlock = (OutlineTextBlock)dependencyObject;
            outlinedTextBlock.UpdateFormattedText();
            outlinedTextBlock.TextGeometry = null;

            outlinedTextBlock.InvalidateMeasure();
            outlinedTextBlock.InvalidateVisual();
        }
        
        private void EnsureFormattedText()
        {
            if (this.Text == null)
            {
                return;
            }
            
            this.FormattedText = new FormattedText(
                this.Text,
                CultureInfo.CurrentUICulture,
                this.FlowDirection,
                new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch),
                this.FontSize,
                //Brushes.Black,
                this.Fill,
                new NumberSubstitution(),
                TextFormattingMode.Display);
            

            this.UpdateFormattedText();
        }

        private void UpdateFormattedText()
        {
            if (this.FormattedText == null)
            {
                return;
            }

            this.FormattedText.MaxLineCount = this.TextWrapping == TextWrapping.NoWrap ? 1 : int.MaxValue;
            this.FormattedText.TextAlignment = this.TextAlignment;
            this.FormattedText.Trimming = this.TextTrimming;

            this.FormattedText.SetFontSize(this.FontSize);
            this.FormattedText.SetFontStyle(this.FontStyle);
            this.FormattedText.SetFontWeight(this.FontWeight);
            this.FormattedText.SetFontFamily(this.FontFamily);
            this.FormattedText.SetFontStretch(this.FontStretch);
            this.FormattedText.SetTextDecorations(this.TextDecorations);
        }

        private  void EnsureGeometry()
        {
            if (this.TextGeometry != null)
            {
                return;
            }

            if (this.FormattedText == null)
            {
                this.EnsureFormattedText();
            }

            if (this.FormattedText == null)
                return;

            this.TextGeometry = this.FormattedText.BuildGeometry(new Point());
        }
    }
    
}