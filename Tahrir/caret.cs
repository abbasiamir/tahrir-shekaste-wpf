using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Tahrir
{
    static class caret
    {
        public static Path Make(int size)
        {
       
            LineGeometry line = new LineGeometry(new Point(0, 0), new Point(0, size));
            Path path = new Path();
            path.Data = line;
            path.Stroke = System.Windows.Media.Brushes.Black;
            path.StrokeThickness =2;
            System.Windows.Media.Animation.DoubleAnimation animation1 = new System.Windows.Media.Animation.DoubleAnimation(1, .9, TimeSpan.FromSeconds(.2));
            System.Windows.Media.Animation.DoubleAnimation animation2 = new System.Windows.Media.Animation.DoubleAnimation(.9, 0, TimeSpan.FromSeconds(.1));
            System.Windows.Media.Animation.DoubleAnimation animation3 = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(.2));
            Storyboard sb = new Storyboard();
            sb.Duration = TimeSpan.FromSeconds(.5);
            sb.Children.Add(animation1);
            sb.Children.Add(animation2);
            sb.Children.Add(animation3);
            Storyboard.SetTarget(animation1, path);
            Storyboard.SetTarget(animation2, path);
            Storyboard.SetTarget(animation3, path);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Path.OpacityProperty));
            Storyboard.SetTargetProperty(animation2, new PropertyPath(Path.OpacityProperty));
            Storyboard.SetTargetProperty(animation3, new PropertyPath(Path.OpacityProperty));
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
            return path;

        }
        public static void clear()
        {
            line ln = Workspace.frame.pagesborder[CaretPos.page].page.columnborders[CaretPos.column].column.paragraphs[CaretPos.paragraph].lines[CaretPos.line];
            ln.Children.RemoveAt(CaretPos.linepos);
        }
    }
}
