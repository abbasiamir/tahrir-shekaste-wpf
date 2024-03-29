using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tahrir
{
    static class Contex
    {
        public static Color color = Colors.Black;
        public static bool Isselected = false;
        public static Path selectedPath = new Path();
        public static Point selectedPoint = new Point();
        public static subword subword = new subword();
    }
}
