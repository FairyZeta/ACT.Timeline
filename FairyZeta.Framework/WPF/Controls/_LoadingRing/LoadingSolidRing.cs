using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FairyZeta.Framework.WPF.Controls
{
    public class LoadingSolidRing : LoadingSegments
    {
        #region AngleGap
        private static readonly DependencyProperty _angleGapProperty =
            DependencyProperty.Register("AngleGap", typeof(double), typeof(LoadingSolidRing),
            new UIPropertyMetadata(5.0, new PropertyChangedCallback((o, e) =>
            {
                LoadingSolidRing s = o as LoadingSolidRing;
                if (s != null) s.OnAngleGapChanged((double)e.OldValue, (double)e.NewValue);
            })));

        protected double _angleGap = (double)_angleGapProperty.DefaultMetadata.DefaultValue;
        protected void OnAngleGapChanged(double oldValue, double newValue)
        {
            if (oldValue == newValue) return;
            _angleGap = newValue;
            AddChildren(canvas.Width, canvas.Height);
        }
        public double AngleGap
        {
            get { return (double)GetValue(_angleGapProperty); }
            set { SetValue(_angleGapProperty, value); }
        }
        #endregion

        #region RingRatio
        private static readonly DependencyProperty _ratioProperty =
            DependencyProperty.Register("RingRatio", typeof(double), typeof(LoadingSolidRing),
            new UIPropertyMetadata(0.75, new PropertyChangedCallback((o, e) =>
                {
                    LoadingSolidRing s = o as LoadingSolidRing;
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

            double angleGapRad = _angleGap * (2 * Math.PI / 360.0); // セグメント間の角度ギャップ(ラジアン)

            Point cp = new Point(width / 2.0, height / 2.0); // 中心点
            double lr = Math.Min(width, height) / 2.0; // 外側円弧半径
            double sr = lr * _ratio; // 内側円弧半径
            double d = 0; // 現在の角度
            double dd = (2 * Math.PI - _count * angleGapRad) / (double)_count; // 1セグメントの角度

            List<PathFigure> pfs = new List<PathFigure>();
            for (int i = 0; i < _count; i++)
            {
                Point ap1 = new Point(cp.X + lr * Math.Cos(d), cp.Y + lr * Math.Sin(d)); // 外側円弧開始点
                Point ap2 = new Point(cp.X + lr * Math.Cos(d + dd), cp.Y + lr * Math.Sin(d + dd)); // 外側円弧終了点
                Point sap1 = new Point(cp.X + sr * Math.Cos(d), cp.Y + sr * Math.Sin(d)); // 内側円弧開始点
                Point sap2 = new Point(cp.X + sr * Math.Cos(d + dd), cp.Y + sr * Math.Sin(d + dd)); // 内側円弧終了点

                // 1セグメント作る
                Path pp = new Path();
                pp.Data = new PathGeometry(new List<PathFigure>()
                {
                    new PathFigure(ap1, new List<PathSegment>() {
                        new ArcSegment(ap2, new Size(lr, lr), dd, dd > Math.PI, 
                            SweepDirection.Clockwise, true),
                        new LineSegment(sap2, true),
                        new ArcSegment(sap1, new Size(sr, sr), dd, dd > Math.PI, 
                            SweepDirection.Counterclockwise, true),
                        new LineSegment(ap1, true)
                    }, true),
                });
                pp.Fill = _ringFill;
                pp.Stroke = _ringStroke;
                _canvas.Children.Add(pp);

                d += dd + angleGapRad; // 角度更新
            }

            UpdateAnimation();
        }
    }
}
