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
    /// <summary>
    /// LoadingRing.xaml の相互作用ロジック
    /// </summary>
    public abstract partial class LoadingRingBase : UserControl
    {
        public LoadingRingBase() {
            InitializeComponent();
            _canvas = canvas;
            _canvas.SizeChanged += (s, e) => { Init(e.NewSize.Width, e.NewSize.Height); };
        }

        #region properties

        #region RingFill
        private static readonly DependencyProperty _ringFillProperty =
            DependencyProperty.Register("RingFill", typeof(Brush), typeof(LoadingRingBase),
            new UIPropertyMetadata(new SolidColorBrush(SystemColors.MenuHighlightColor),
                new PropertyChangedCallback((o, e) =>
                {
                    LoadingRingBase s = o as LoadingRingBase;
                    if (s != null) s.OnRingFillChanged((Brush)e.OldValue, (Brush)e.NewValue);
                })));

        protected Brush _ringFill = (Brush)_ringFillProperty.DefaultMetadata.DefaultValue;
        protected void OnRingFillChanged(Brush oldValue, Brush newValue)
        {
            if (oldValue == newValue) return;
            _ringFill = newValue;
            UpdateColor();
        }
        /// <summary>各セグメントの中身を塗りつぶすブラシを取得・設定する</summary>
        public Brush RingFill
        {
            get { return (Brush)GetValue(_ringFillProperty); }
            set { SetValue(_ringFillProperty, value); }
        }
        #endregion // RingFill

        #region RingStroke
        private static readonly DependencyProperty _ringStrokeProperty =
            DependencyProperty.Register("RingStroke", typeof(Brush), typeof(LoadingRingBase),
            new UIPropertyMetadata(null, new PropertyChangedCallback((o, e) =>
            {
                LoadingRingBase s = o as LoadingRingBase;
                if (s != null) s.OnRingStrokeChanged((Brush)e.OldValue, (Brush)e.NewValue);
            })));

        protected Brush _ringStroke = (Brush)_ringStrokeProperty.DefaultMetadata.DefaultValue;
        protected void OnRingStrokeChanged(Brush oldValue, Brush newValue)
        {
            if (oldValue == newValue) return;
            _ringStroke = newValue;
            UpdateColor();
        }
        /// <summary>各セグメントのアウトラインを描画するブラシを取得・設定する</summary>
        public Brush RingStroke
        {
            get { return (Brush)GetValue(_ringStrokeProperty); }
            set { SetValue(_ringStrokeProperty, value); }
        }
        #endregion // RingStroke

        #region IsLoading
        private static readonly DependencyProperty _loadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(LoadingRingBase),
            new UIPropertyMetadata(true, new PropertyChangedCallback((o, e) =>
            {
                LoadingRingBase s = o as LoadingRingBase;
                if (s != null) s.OnLoadingChanged((bool)e.OldValue, (bool)e.NewValue);
            })));

        protected bool _loading = true;
        protected void OnLoadingChanged(bool oldValue, bool newValue)
        {
            if (oldValue == newValue) return;
            _loading = newValue;
            if (_animStoryboard != null)
            {
                if (_loading) _animStoryboard.Begin();
                else _animStoryboard.Stop();
            }
        }
        /// <summary>ローディング状態かどうかを取得・設定する</summary>
        public bool IsLoading
        {
            get { return (bool)GetValue(_loadingProperty); }
            set { SetValue(_loadingProperty, value); }
        }
        #endregion // IsLoading

        #region Duration
        private static readonly DependencyProperty _durationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(LoadingRingBase),
            new UIPropertyMetadata(1.5, new PropertyChangedCallback((o, e) =>
            {
                LoadingRingBase s = o as LoadingRingBase;
                if (s != null) s.OnDurationChanged((double)e.OldValue, (double)e.NewValue);
            })));

        protected double _duration = (double)_durationProperty.DefaultMetadata.DefaultValue;
        protected void OnDurationChanged(double oldValue, double newValue)
        {
            if (oldValue == newValue) return;
            _duration = newValue;
            UpdateAnimation();
        }
        /// <summary>一周するのにかかる時間(秒)を取得・設定する</summary>
        public double Duration
        {
            get { return (double)GetValue(_durationProperty); }
            set { SetValue(_durationProperty, value); }
        }
        #endregion // Duration

        #region Text
        private static readonly DependencyProperty _textProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LoadingRingBase),
            new UIPropertyMetadata(null, new PropertyChangedCallback((o, e) =>
            {
                LoadingRingBase s = o as LoadingRingBase;
                if (s != null) s.OnTextChanged((string)e.OldValue, (string)e.NewValue);
            })));

        protected string _text = (string)_textProperty.DefaultMetadata.DefaultValue;
        protected void OnTextChanged(string oldValue, string newValue)
        {
            if (oldValue == newValue) return;
            _text = newValue;
        }
        /// <summary>円の中心に表示する文字列を取得・設定する</summary>
        public string Text
        {
            get { return (string)GetValue(_textProperty); }
            set { SetValue(_textProperty, value); }
        }
        #endregion // Text

        #endregion // properties

        /// <summary>アニメーション</summary>
        protected Storyboard _animStoryboard;
        protected Canvas _canvas;

        protected void Init(double width, double height)
        {
            AddChildren(width, height);
            UpdateAnimation();
        }

        /// <summary>
        /// キャンバス内の要素を作成する
        /// </summary>
        /// <param name="width">キャンバスの幅</param>
        /// <param name="height">キャンバスの高さ</param>
        protected abstract void AddChildren(double width, double height);

        protected virtual void UpdateColor()
        {
            foreach (var child in _canvas.Children)
            {
                if (!(child is Shape)) continue;

                Shape el = (Shape)child;
                el.Fill = _ringFill;
                el.Stroke = _ringStroke;
            }
        }

        protected abstract void UpdateAnimation();
    }
}
