using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PublishTool.Views
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        public string Message { get; set; }
        public MessageWindow(string Msg)
        {
            InitializeComponent();
            DataContext = this;
            Message = Msg;
        }
      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var LoadAnimation = new DoubleAnimation();
            LoadAnimation.Duration = new Duration(TimeSpan.Parse("0:0:1"));
            LoadAnimation.From = 0.1;
            LoadAnimation.To = 1;
            LoadAnimation.EasingFunction = new ElasticEase()
            {
                EasingMode = EasingMode.EaseOut,
                Springiness = 8
            };
            var LoadClock = LoadAnimation.CreateClock();
            Scale.ApplyAnimationClock(ScaleTransform.ScaleXProperty, LoadClock);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var UnLoadAnimation = new DoubleAnimation();
            UnLoadAnimation.Duration = new Duration(TimeSpan.Parse("0:0:0.3"));
            UnLoadAnimation.From = 1;
            UnLoadAnimation.To = 0.01;
            var LoadClock = UnLoadAnimation.CreateClock();
            LoadClock.Completed += (a, b) =>
            {
                DialogResult = true;
            };
            Scale.ApplyAnimationClock(ScaleTransform.ScaleXProperty, LoadClock);
        }
    }
}
