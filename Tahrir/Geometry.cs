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
    class shap
    {
        List<Path> paths = new List<Path>();
         List<List<Point>> wordData = new List<List<Point>>();
         PathGeometry pathgeometry = new PathGeometry();
         Polyline polyline = new Polyline();
         public List<Path> MakePolygon(string word,string font)
        {
            xml x = new xml();
            wordData = x.ReadImage(word,font);
            Point start = new Point();
            Point end = new Point();
            if (wordData != null)
            {
                foreach (List<Point> seg in wordData)
                {
                    PointCollection pointcollect = new PointCollection();
                    for (int i = 0; i < seg.Count; i++)
                    {

                        pointcollect.Add(seg[i]);
                        if (i == 0)
                            start = new Point(seg[i].X, seg[i].Y);
                        if (i == seg.Count - 1)
                            end = new Point(seg[i].X, seg[i].Y);
                    }
                    PolyLineSegment polylinesegment = new PolyLineSegment();
                    polylinesegment.Points = pointcollect;
                    PathFigure pathfigure = new PathFigure();
                    pathfigure.Segments.Add(polylinesegment);
                    pathfigure.StartPoint = start;
                    pathgeometry = new PathGeometry();
                    pathgeometry.Figures.Add(pathfigure);
                    Path path = new Path();
                    SolidColorBrush brush = new SolidColorBrush(Colors.Black);
                    path.Data = pathgeometry;
                    path.Fill = brush;
                    //path.MouseMove += Path_MouseMove;
                    path.MouseDown += Path_MouseDown;
                    paths.Add(path);
                }
            
               
                return paths;

            }
            return null;
        }
       
        private void Path_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Path p = new Path();
            p = (Path)sender;
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                Contex.selectedPath = p;
                if(!Contex.Isselected)
                    Contex.selectedPoint = e.GetPosition(Workspace.frame);
                Contex.Isselected = true;
            }
        }

        private void Path_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
           
        }
    }
}
