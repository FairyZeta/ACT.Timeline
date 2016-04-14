using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FairyZeta.Framework.WPF.Controls
{
    public class LoadingDottedRing : LoadingSegments
    {
        protected override void AddChildren(double width, double height)
        {
            _canvas.Children.Clear();

            double d = 0; // 現在の角度
            double dd = Math.PI * 2 / (double)_count; // ドット毎の角度変化
            double cr = Math.Min(width, height) / ((double)_count + 2); // ドットの半径
            double r = Math.Min(width, height) / 2.0 - cr; // 円の半径
            double cx = width / 2.0; // 中心点x
            double cy = height / 2.0; // 中心点y

            for (int i = 0; i < _count; i++)
            {
                // 1ドット作る
                double x = cx + r * Math.Cos(d);
                double y = cy + r * Math.Sin(d);

                Ellipse el = new Ellipse();
                el.Width = cr * 2; el.Height = cr * 2;
                el.Fill = _ringFill;
                el.Stroke = _ringStroke;
                Canvas.SetLeft(el, x - cr);
                Canvas.SetTop(el, y - cr);
                _canvas.Children.Add(el);

                d += dd; // 角度更新
            }

            UpdateAnimation();
        }
    }
}
