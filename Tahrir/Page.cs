using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tahrir
{
    class Page:MyStackPanel
    {
        public List<ColumnBorder> columnborders { get; set; }
        public PageSetup pagesetup = new PageSetup();
        public Page()
        {
            //this.MouseDown += Page_MouseDown;
            this.Focusable = false;
            columnborders = new List<ColumnBorder>();
            columnborders.Add(new ColumnBorder());
            columnborders[0].column.number = 0;
            this.Children.Add(columnborders[0]);
            
        }

        private void Page_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*if (Contex.Isselected&&Contex.selectedPoint!=e.GetPosition(Workspace.frame))
            {
                Path path = Contex.selectedPath;
                Point point = e.GetPosition(this);
                path.Arrange(new Rect(point.X, point.Y, path.ActualWidth + point.X, path.ActualHeight + point.Y));
                path.Fill = Brushes.Black;
                Contex.Isselected = false;
            }*/
        }
    }
}
