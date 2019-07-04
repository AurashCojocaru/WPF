using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfSeeds
{
    public static class SeedFactory
    {
        public static Ellipse CreateSeed()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.StrokeThickness = 2;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            return ellipse;
        }
    }
}
