using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FairyZeta.Framework.WPF.Controls
{
    public class LoadingArc : LoadingRingBase
    {       
        #region Angle
        private static readonly DependencyProperty _angleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(LoadingArc),
            new UIPropertyMetadata(90.0, new PropertyChangedCallback((o, e) =>
            {
                LoadingArc s = o as LoadingArc;
                if (s != null) s.OnAngleChanged((double)e.OldValue, (double)e.NewValue);
            })));

        protected double _angle = (double)_angleProperty.DefaultMetadata.DefaultValue;
        protected void OnAngleChanged(double oldValue, double newValue)
        {
            if (oldValue == newValue) return;
            _angle = newValue;
            AddChildren(canvas.Width, canvas.Height);
        }
        public double Angle
        {
            get { return (double)GetValue(_angleProperty); }
            set { SetValue(_angleProperty, value); }
        }
        #endregion

        #region Round
        private static readonly DependencyProperty _roundProperty =
            DependencyProperty.Register("Round", typeof(bool), typeof(LoadingArc),
            new UIPropertyMetadata(false, new PropertyChangedCallback((o, e) =>
            {
                LoadingArc s = o as LoadingArc;
                if (s != null) s.OnRoundChanged((bool)e.OldValue, (bool)e.NewValue);
            })));
        protected bool _round = (bool)_roundProperty.DefaultMetadata.DefaultValue;
        protected void OnRoundChanged(bool oldValue, bool newValue)
        {
            if (oldValue == newValue) return;
            _round = newValue;
            AddChildren(canvas.Width, canvas.Height);
        }
        public bool Round
        {
            get { return (bool)GetValue(_roundProperty); }
            set { SetValue(_roundProperty, value); }
        }
        #endregion // Round

        #region RingRatio
        private static readonly DependencyProperty _ratioProperty =
            DependencyProperty.Register("RingRatio", typeof(double), typeof(LoadingArc),
            new UIPropertyMetadata(0.75, new PropertyChangedCallback((o, e) =>
            {
                LoadingArc s = o as LoadingArc;
                if (s != null) s.OnRingRatioChanged((double)e.OldValue, (double)e.NewValue);
            })));

        protected double _ratio = (double)_ratioProperty.DefaultMetadata.DefaultValue;
        protected void OnRingRatioChanged(double oldValue, double newValue)
        {
            if (oldValue == newValue) return;
            if (newValue < 0.0) newValue = 0.0;
            if (newValue > 1.0) newValue = 1.0;
            _ratio = newValue;
            AddChildren(canvas.Width, canvas.Height);
        }
        public double RingRatio
        {
            get { return (double)GetValue(_ratioProperty); }
            set { SetValue(_ratioProperty, value); }
        }
        #endregion

        protected override void AddChildren(double width, double height)
        {
            _canvas.Children.Clear();

            double angle = _angle * (2 * Math.PI / 360.0);
            Point cp = new Point(width / 2.0, height / 2.0); // 中心点
            double lr = Math.Min(width, height) / 2.0; // 外側円弧半径
            double sr = lr * _ratio; // 内側円弧半径

            Point ap1 = new Point(cp.X + lr * Math.Cos(0), cp.Y + lr * Math.Sin(0)); // 外側円弧開始点
            Point ap2 = new Point(cp.X + lr * Math.Cos(angle), cp.Y + lr * Math.Sin(angle)); // 外側円弧終了点
            Point sap1 = new Point(cp.X + sr * Math.Cos(0), cp.Y + sr * Math.Sin(0)); // 内側円弧開始点
            Point sap2 = new Point(cp.X + sr * Math.Cos(angle), cp.Y + sr * Math.Sin(angle)); // 内側円弧終了点

            double ssr = Math.Sqrt((ap1.X - sap1.X) * (ap1.X - sap1.X) + (ap1.Y - sap1.Y) * (ap1.Y - sap1.Y)) / 2.0;

            Path pp = new Path();
            pp.Data = new PathGeometry(new List<PathFigure>()
            {
                new PathFigure(ap1, new List<PathSegment>() {
                    new ArcSegment(ap2, new Size(lr, lr), angle, angle > Math.PI, 
                        SweepDirection.Clockwise, true),
                    _round ?
                        (PathSegment)(new ArcSegment(sap2, new Size(ssr, ssr), 
                            Math.PI, false, SweepDirection.Clockwise, true)) :
                        (PathSegment)(new LineSegment(sap2, true)),
                    new ArcSegment(sap1, new Size(sr, sr), angle, angle > Math.PI, 
                        SweepDirection.Counterclockwise, true),
                    _round ?
                        (PathSegment)(new ArcSegment(ap1, new Size(ssr, ssr),
                            Math.PI, false, SweepDirection.Clockwise, true)) :
                        (PathSegment)(new LineSegment(ap1, true)),
                }, true),
            });

            pp.Fill = _ringFill;
            pp.Stroke = _ringStroke;
            _canvas.Children.Add(pp);

            pp.RenderTransform = new RotateTransform(0, cp.X, cp.Y);

            UpdateAnimation();
        }

        protected override void UpdateAnimation()
        {
            if (_loading && _animStoryboard != null) _animStoryboard.Stop();

            _animStoryboard = new Storyboard();

            foreach (var pp in _canvas.Children)
            {
                if (!(pp is Shape)) continue;

                DoubleAnimation anim = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(_duration));

                Storyboard.SetTarget(anim, pp as Shape);
                Storyboard.SetTargetProperty(anim, new PropertyPath("RenderTransform.Angle"));
                _animStoryboard.Children.Add(anim);
            }

            _animStoryboard.AutoReverse = false;
            _animStoryboard.RepeatBehavior = RepeatBehavior.Forever;

            if (_loading) _animStoryboard.Begin();
        }
    }
}
