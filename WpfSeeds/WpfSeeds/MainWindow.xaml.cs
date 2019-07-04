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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TbCount.Text, out double tbValue))
            {
                Slider.Value = tbValue;
                //MainCanvas.Draw(100, tbValue);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TbCount.Text = Slider.Value.ToString();
            MainCanvas.Draw(200, Slider.Value);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //double max = Slider.Maximum;
            //Task.Factory.StartNew(() =>
            //{
            //    double value = 0.3;
            //    while (value < max)
            //    {
            //        value += 0.00001;
            //        Thread.Sleep(10);
            //        Dispatcher.Invoke(() =>
            //        {
            //            Slider.Value = value;
            //        });
            //    }
            //});
        }
    }
}
