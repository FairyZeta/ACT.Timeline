using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace FairyZeta.Framework.WPF.Controls
{
    public abstract class LoadingSegments : LoadingRingBase
    {
        #region Count
        private static readonly DependencyProperty _countProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(LoadingSegments),
            new UIPropertyMetadata(16, new PropertyChangedCallback((o, e) =>
            {
                LoadingSegments s = o as LoadingSegments;
                if (s != null) s.OnCountChanged((int)e.OldValue, (int)e.NewValue);
            })));

        protected int _count = (int)_countProperty.DefaultMetadata.DefaultValue;
        protected void OnCountChanged(int oldValue, int newValue)
        {
            if (oldValue == newValue) return;
            _count = newValue;
            Init(_canvas.Width, _canvas.Height);
        }
        /// <summary>セグメント数を取得・設定する</summary>
        public int Count
        {
            get { return (int)GetValue(_countProperty); }
            set { SetValue(_countProperty, value); }
        }
        #endregion // Count

        protected override void UpdateAnimation()
        {
            int num = _canvas.Children.Count;

            if (_loading && _animStoryboard != null) _animStoryboard.Stop();

            double[] opacities = new double[_count];
            double dop = 1 / (double)(opacities.Length - 0.5);
            for (int n = 0; n < opacities.Length; n++)
            {
                opacities[n] = 1 - Math.Pow(dop * n, 1);
            }

            int i = 0;
            _animStoryboard = new Storyboard();
            foreach (var child in _canvas.Children)
            {
                if (!(child is Shape)) continue;

                Shape el = (Shape)child;
                el.Opacity = opacities[i % opacities.Length];
                DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
                anim.Duration = new Duration(TimeSpan.FromSeconds(_duration));
                for (int j = 0; j < opacities.Length; j++)
                {
                    anim.KeyFrames.Add(new DiscreteDoubleKeyFrame(
                        opacities[(j + (_count - i)) % opacities.Length],
                        KeyTime.FromPercent(j / (double)opacities.Length)));
                }
                Storyboard.SetTarget(anim, el);
                Storyboard.SetTargetProperty(anim, new PropertyPath("Opacity"));
                _animStoryboard.Children.Add(anim);

                i++;
            }
            _animStoryboard.AutoReverse = false;
            _animStoryboard.RepeatBehavior = RepeatBehavior.Forever;

            if (_loading) _animStoryboard.Begin();
        }
    }
}
