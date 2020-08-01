using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace TrafficLight
{
    public partial class MainWindow : Window
    {
        List<Brush> colors;
        int index = 1;
        public MainWindow()
        {
            InitializeComponent();

            colors = new List<Brush>();
            colors.Add(Brushes.Green);
            colors.Add(Brushes.Yellow);
            colors.Add(Brushes.Red);
            colors.Add(Brushes.Yellow);
            this.Background = colors.Last();
            System.Timers.Timer timer = new System.Timers.Timer(1500);
            timer.Elapsed += test;
            timer.Start();
        }
        private void test(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                this.Background = colors[index % 4]; index++;
                this.Title = (index % 4).ToString();
            }));
        }
    }
}