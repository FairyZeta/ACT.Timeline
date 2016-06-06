using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FairyZeta.Framework.WPF.Controls;

namespace FairyZeta.FF14.ACT.Timeline.Core.WPF.Controls
{
    public class TimelineProgressBar : ExtendProgressBar
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        public static readonly DependencyProperty CastTimeProperty =
                    DependencyProperty.Register("CastTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnCastTimeChanged));
        public static readonly DependencyProperty TimeFromStartProperty =
                    DependencyProperty.Register("TimeFromStart", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnTimeFromStartChanged));
        public static readonly DependencyProperty BarActiveTimeProperty =
                    DependencyProperty.Register("BarActiveTime", typeof(double), typeof(TimelineProgressBar), new FrameworkPropertyMetadata(0d, OnBarActiveTimeChanged));

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
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/


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


    }
}
