using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace CreateMapSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dax = new DoubleAnimation();
            //指定起点
            dax.From = 0;
            //指定终点
            Random rdm = new Random();
            dax.To = 1000;
            //dax.By = 100D;
            //day.By = 100D;
            //指定时长
            Duration duration = new Duration(TimeSpan.FromMilliseconds(1500));
            dax.Duration = duration;
            //动画主体是TranslatTransform变形，而非Button
            this.tt.BeginAnimation(TranslateTransform.XProperty, dax);
        }
    }
}
