using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Controls
{
    public class TimelineProgressBar : ProgressBar
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/


        public static readonly DependencyProperty GradientColor1Property =
                    DependencyProperty.Register("GradientColor1", typeof(Color), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));
        public static readonly DependencyProperty GradientColor2Property =
                    DependencyProperty.Register("GradientColor2", typeof(Color), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));
        public static readonly DependencyProperty GradientColor3Property =
                    DependencyProperty.Register("GradientColor3", typeof(Color), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(default(Color), OnColorChanged));

        public static readonly DependencyProperty CastTimeProperty =
                    DependencyProperty.Register("CastTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnCastTimeChanged));
        public static readonly DependencyProperty TimeFromStartProperty =
                    DependencyProperty.Register("TimeFromStart", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnTimeFromStartChanged));
        public static readonly DependencyProperty BarActiveTimeProperty =
                    DependencyProperty.Register("BarActiveTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnBarActiveTimeChanged));

        public static readonly DependencyProperty GradientStop1StartTimeProperty =
                    DependencyProperty.Register("GradientStop1StartTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnGradientStopTimeChanged));
        public static readonly DependencyProperty GradientStop1EndTimeProperty =
                    DependencyProperty.Register("GradientStop1EndTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnGradientStopTimeChanged));
        public static readonly DependencyProperty GradientStop2StartTimeProperty =
                    DependencyProperty.Register("GradientStop2StartTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnGradientStopTimeChanged));
        public static readonly DependencyProperty GradientStop2EndTimeProperty =
                    DependencyProperty.Register("GradientStop2EndTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnGradientStopTimeChanged));


        /// <summary> (Dependency) グラデーションカラー1 </summary>
        public Color GradientColor1
        {
            get { return (Color)GetValue(GradientColor1Property); }
            set { SetValue(GradientColor1Property, value); }
        }
        /// <summary> (Dependency) グラデーションカラー2 </summary>
        public Color GradientColor2
        {
            get { return (Color)GetValue(GradientColor2Property); }
            set { SetValue(GradientColor2Property, value); }
        }
        /// <summary> (Dependency) グラデーションカラー3 </summary>
        public Color GradientColor3
        {
            get { return (Color)GetValue(GradientColor3Property); }
            set { SetValue(GradientColor3Property, value); }
        }

        /// <summary> (Dependency) Color1~2へのグラデーション開始時間 </summary>
        public double GradientStop1StartTime
        {
            get { return (double)GetValue(GradientStop1StartTimeProperty); }
            set { SetValue(GradientStop1StartTimeProperty, value); }
        }
        /// <summary> (Dependency) Color1~2へのグラデーション終了時間 </summary>
        public double GradientStop1EndTime
        {
            get { return (double)GetValue(GradientStop1EndTimeProperty); }
            set { SetValue(GradientStop1EndTimeProperty, value); }
        }
        /// <summary> (Dependency) Color2~3へのグラデーション開始時間 </summary>
        public double GradientStop2StartTime
        {
            get { return (double)GetValue(GradientStop2StartTimeProperty); }
            set { SetValue(GradientStop2StartTimeProperty, value); }
        }
        /// <summary> (Dependency) Color2~3へのグラデーション終了時間 </summary>
        public double GradientStop2EndTime
        {
            get { return (double)GetValue(GradientStop2EndTimeProperty); }
            set { SetValue(GradientStop2EndTimeProperty, value); }
        }

        public double CastTime
        {
            get { return (double)GetValue(TimeFromStartProperty); }
            set { SetValue(TimeFromStartProperty, value); }
        }

        public double TimeFromStart
        {
            get { return (double)GetValue(TimeFromStartProperty); }
            set { SetValue(TimeFromStartProperty, value); }
        }
        /// <summary> (Dependency) バーが動き出す時間 </summary>
        public double BarActiveTime
        {
            get { return (double)GetValue(BarActiveTimeProperty); }
            set { SetValue(BarActiveTimeProperty, value); }
        }

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        public TimelineProgressBar()
            : base()
        {
            base.Loaded += TimelineProgressBar_Loaded;
            base.ValueChanged += TimelineProgressBar_ValueChanged;
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> ColorChanged変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimelineProgressBar ctrl = obj as TimelineProgressBar;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient();
            }
        }
        /// <summary> GradientStopTime変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnGradientStopTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimelineProgressBar ctrl = obj as TimelineProgressBar;
            if (ctrl != null)
            {
                ctrl.CalculateNewGradient();
            }
        }

        /// <summary> TimeFromStart変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnCastTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimelineProgressBar ctrl = obj as TimelineProgressBar;
            if (ctrl != null)
            {
                Console.WriteLine("OnCastTimeChanged");
            }
        }
        /// <summary> TimeFromStart変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnTimeFromStartChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimelineProgressBar ctrl = obj as TimelineProgressBar;
            if (ctrl != null)
            {
                ctrl.Minimum = (double)e.NewValue - ctrl.BarActiveTime;
                Console.WriteLine("OnTimeFromStartChanged");
            }
        }

        /// <summary> BarActiveTime変更時のコールバック
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnBarActiveTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimelineProgressBar ctrl = obj as TimelineProgressBar;
            if (ctrl != null)
            {
                ctrl.Minimum = ctrl.TimeFromStart - (double)e.NewValue;
                Console.WriteLine("OnBarActiveTimeChanged");
            }
        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

        private void TimelineProgressBar_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateNewGradient();
        }

        private void TimelineProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateNewGradient();
        }

        private void CalculateNewGradient()
        {
                var brush = new LinearGradientBrush();
                brush.StartPoint = new Point(1.0, 0.5);
                brush.EndPoint = new Point(0.0, 0.5);

                double progress = base.Maximum - base.Value;

                if (progress <= 0)
                {

                }
                else if (progress < this.GradientStop2StartTime)
                {
                    var newGradientStop2 = new GradientStop(this.GradientColor3, this.GradientStop2EndTime - progress);
                    var newGradientStop1 = new GradientStop(this.GradientColor2, this.GradientStop2StartTime - progress);
                    brush.GradientStops.Add(newGradientStop2);
                    brush.GradientStops.Add(newGradientStop1);
                }
                else if (progress < this.GradientStop1StartTime)
                {
                    var newGradientStop2 = new GradientStop(this.GradientColor2, this.GradientStop1EndTime - progress);
                    var newGradientStop1 = new GradientStop(this.GradientColor1, this.GradientStop1StartTime - progress);
                    brush.GradientStops.Add(newGradientStop2);
                    brush.GradientStops.Add(newGradientStop1);
                }
                else
                {
                    var newGradientStop = new GradientStop(this.GradientColor1, 0);
                    brush.GradientStops.Add(newGradientStop);
                }
                

            base.Foreground  = brush;
        }
    }
}
