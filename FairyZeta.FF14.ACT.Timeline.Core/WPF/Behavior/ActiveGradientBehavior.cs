using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Behavior
{
    /// <summary> オーバーレイ／アクティブゲージビヘイビア
    /// </summary>
    public class ActiveGradientBehavior : Behavior<RangeBase>
    {
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
                "SourceBrush", typeof(LinearGradientBrush), typeof(ActiveGradientBehavior), new UIPropertyMetadata(null));

        #endregion
            
        private void CalculateNewGradient(double progress)
        {
            var brush = new LinearGradientBrush();
            brush.StartPoint = SourceBrush.StartPoint;
            brush.EndPoint = SourceBrush.EndPoint;

            if (progress <= 0)
            {

            }
            else if (progress < 5)
            {
                var newGradientStop2 = new GradientStop(SourceBrush.GradientStops[2].Color, 3 - progress);
                var newGradientStop1 = new GradientStop(SourceBrush.GradientStops[1].Color, 5 - progress);
                brush.GradientStops.Add(newGradientStop2);
                brush.GradientStops.Add(newGradientStop1);
            }
            else if (progress < 9)
            {
                var newGradientStop2 = new GradientStop(SourceBrush.GradientStops[1].Color, 7 - progress);
                var newGradientStop1 = new GradientStop(SourceBrush.GradientStops[0].Color, 9 - progress);
                brush.GradientStops.Add(newGradientStop2);
                brush.GradientStops.Add(newGradientStop1);
            }
            else
            {
                var newGradientStop = new GradientStop(SourceBrush.GradientStops[0].Color, 0);
                brush.GradientStops.Add(newGradientStop);
            }

            ApplyNewGradient(brush);
        }

        private void ApplyNewGradient(LinearGradientBrush brush)
        {
            AssociatedObject.Foreground = brush;
        }
        
    }
}
