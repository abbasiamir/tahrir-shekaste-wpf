using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tahrir
{
    class MyCanvas:Canvas
    {
        public int number { get; set; }
        Point pressedPoint = new Point();
        bool pressed = false;
        public Address address = new Address();
        public MyCanvas()
        {
            //this.MouseDown += MyCanvas_MouseDown;
            //this.MouseMove += MyCanvas_MouseMove;
            //this.MouseUp += MyCanvas_MouseUp;
        }

        private void MyCanvas_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Released)
                pressed = false;
        }

        private void MyCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MyStackPanel parent =(MyStackPanel) this.Parent;
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                /* GeneralTransform gt = this.TransformToVisual(Workspace.frame);
                 Point offset = gt.Transform(new Point(0, 0));
                 double controlTop = offset.Y;
                 double controlLeft = offset.X;
                 Point point = e.GetPosition(Workspace.frame);
                     double diffX = -pressedPoint.X + point.X;
                     double diffY = -pressedPoint.Y + point.Y;

                 this.Arrange(new Rect(new Point(diffX,diffY),new Point(diffX+this.ActualWidth,diffY+this.ActualHeight)));
                 //this.ArrangeOverride(new Size(this.ActualWidth, this.ActualHeight));
                 Canvas.SetZIndex(this, 10);
                 pressedPoint.X += diffX;
                 pressedPoint.Y += diffY;*/
            }
        }

        private void MyCanvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                
                    Contex.subword.address.fillAddress(UIETypes.SubWord, this);

                if (!Contex.Isselected)
                    pressedPoint = e.GetPosition(Workspace.frame);
            }
            
        }
    }
}
