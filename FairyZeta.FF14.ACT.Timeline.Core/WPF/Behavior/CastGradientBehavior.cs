using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Behavior
{
    /// <summary> オーバーレイ／キャストゲージビヘイビア
    /// </summary>
    public class CastGradientBehavior : Behavior<RangeBase>
    {
        public static readonly DependencyProperty ColorChangedProperty =
                    DependencyProperty.Register("ColorChanged", typeof(Color), typeof(CastGradientBehavior), new FrameworkPropertyMetadata(default(Color), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnColorChanged));

        /// <summary> (Dependency) 変更対象カラー </summary>
        public Color ColorChanged
        {
            get { return (Color)GetValue(ColorChangedProperty); }
            set { SetValue(ColorChangedProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.ValueChanged += AssociatedObject_ValueChanged;

            var sourceBrush = AssociatedObject.Foreground as LinearGradientBrush;
            if (sourceBrush != null)
            {
                SourceBrush = sourceBrush;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.ValueChanged -= AssociatedObject_ValueChanged;
        }

        /// <summary> ColorChanged変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            CastGradientBehavior ctrl = obj as CastGradientBehavior;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient(ctrl.Progress);
            }
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateNewGradient(Progress);
        }

        private void AssociatedObject_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateNewGradient(Progress);
        }

        private double Progress
        {
            get { return AssociatedObject.Maximum - AssociatedObject.Value; }
        }

        #region SourceBrush

        public LinearGradientBrush SourceBrush
        {
            get { return (LinearGradientBrush)GetValue(SourceBrushProperty); }
            set { SetValue(SourceBrushProperty, value); }
        }

        public static readonly DependencyProperty SourceBrushProperty =
            DependencyProperty.Register(
                "SourceBrush", typeof(LinearGradientBrush), typeof(CastGradientBehavior), new UIPropertyMetadata(null));

        #endregion
            
        private void CalculateNewGradient(double progress)
        {
            var brush = new LinearGradientBrush();
            brush.StartPoint = SourceBrush.StartPoint;
            brush.EndPoint = SourceBrush.EndPoint;

            if (progress <= 0)
            {

            }
            else if (progress < 2)
            {
                var newGradientStop1 = new GradientStop(SourceBrush.GradientStops[2].Color, 1 - progress);
                var newGradientStop2 = new GradientStop(SourceBrush.GradientStops[1].Color, 2 - progress);
                brush.GradientStops.Add(newGradientStop1);
                brush.GradientStops.Add(newGradientStop2);
            }
            else
            {
                var newGradientStop1 = new GradientStop(SourceBrush.GradientStops[1].Color, 2 - progress);
                var newGradientStop2 = new GradientStop(SourceBrush.GradientStops[0].Color, 3 - progress);
                brush.GradientStops.Add(newGradientStop1);
                brush.GradientStops.Add(newGradientStop2);
            }

            ApplyNewGradient(brush);
        }

        private void ApplyNewGradient(LinearGradientBrush brush)
        {
            AssociatedObject.Foreground = brush;
        }
    }
    
}
