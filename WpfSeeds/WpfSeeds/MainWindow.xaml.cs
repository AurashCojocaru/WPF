using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSeeds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private volatile bool _shouldAnimate = false;

        public MainWindow()
        {
            InitializeComponent();
            TbCount.TextChanged += TbCount_TextChanged;
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TbCount.TextChanged -= TbCount_TextChanged;
            Loaded -= MainWindow_Loaded;
            Closing -= MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetInterval();
        }

        private void SetInterval()
        {
            if (double.TryParse(TbCount.Text, out double tbValue))
            {
                Slider.Value = tbValue;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TbCount.Text = Slider.Value.ToString();
            MainCanvas.Draw(200, Slider.Value);
        }
        private void TbCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetInterval();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            _shouldAnimate = !_shouldAnimate;
            BtnStart.Content = _shouldAnimate ? "Stop" : "Start";

            if (_shouldAnimate && double.TryParse(TbCount.Text, out double tbValue))
            {
                double max = Slider.Maximum;
                Task.Factory.StartNew(() =>
                {
                    double value = tbValue;
                    while (value < max && _shouldAnimate)
                    {
                        value += 0.00001;
                        Thread.Sleep(10);
                        Dispatcher.Invoke(() =>
                        {
                            Slider.Value = value;
                        });
                    }
                });
            }
        }

    }
}
