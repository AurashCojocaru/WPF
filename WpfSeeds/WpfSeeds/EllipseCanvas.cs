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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSeeds
{
    public class EllipseCanvas : Canvas
    {
        public void Draw(int count, double ratio)
        {
            this.Children.Clear();
            double distance = 10;
            double currentRatio = 0;

            for (int i = 0; i < count; i++)
            {
                //get seed
                Ellipse ellipse = SeedFactory.CreateSeed();
                //center
                double left = (this.ActualWidth - ellipse.ActualWidth) / 2;
                double top = (this.ActualHeight - ellipse.ActualHeight) / 2;

                //get seed
                left += distance * Math.Cos(Math.PI * GetValueInDegrees(currentRatio) / 180.0);
                top += distance * Math.Sin(Math.PI * GetValueInDegrees(currentRatio) / 180.0);

                SetLeft(ellipse, left);
                SetTop(ellipse, top);
                this.Children.Add(ellipse);

                currentRatio += ratio;

                distance += 1;
            }
        }

        public double GetValueInDegrees(double value)
        {
            return value * 360;
        }
    }
}
