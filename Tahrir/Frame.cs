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
    class Frame:StackPanel
    {
        public List<pageborder> pagesborder { get; set; }
        StackPanel space = new StackPanel() { Height = 70 };
        public Frame()
        {
            this.Focusable = false;
            this.MouseMove += Frame_MouseMove;
            this.MouseDown += Frame_MouseDown;
            pagesborder = new List<pageborder>();
            pagesborder.Add(new pageborder());
            pagesborder.Add(new pageborder());
            pagesborder[0].page.number=0;
            this.Children.Add(pagesborder[0]);
            this.Children.Add(space);
           }

        private void Frame_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                subword subword = (subword)Contex.subword.address.getElement(UIETypes.SubWord);
                Point point = e.GetPosition(this);
                subword.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                subword.Arrange(new Rect((point.X - Contex.selectedPoint.X) * 5, (point.Y - Contex.selectedPoint.Y) * 5, subword.DesiredSize.Width, subword.DesiredSize.Height));
                UpdateLayout();
            }
        }

        private void Frame_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (Contex.Isselected && Contex.selectedPoint != e.GetPosition(Workspace.frame))
            //{
            //    Contex.Isselected = false;
            //    //GeneralTransform gt = canvas.TransformToVisual(Workspace.frame);
            //    //Point offset = gt.Transform(new Point(0, 0));
            //    //double controlTop = offset.Y;
            //    //double controlLeft = offset.X;

            //}
        }
    }
}
