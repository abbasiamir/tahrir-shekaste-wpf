using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Tahrir
{
    class line:MyCanvas
    {
        public List<Word> words = new List<Word>();
       public line()
        {
           
            this.KeyDown += Lin_KeyDown;
            this.MouseDown += Line_MouseDown;
            this.Loaded += Line_Loaded;
            this.FlowDirection = FlowDirection.RightToLeft;
            //this.Orientation = Orientation.Horizontal;
            this.HorizontalAlignment = HorizontalAlignment.Right;
            Thickness m = new Thickness(10);
            this.Margin = m;
            this.Width = 400;
            


        }

        private void Line_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
            if (CaretPos.linepos != -1)
            {
                caret.clear();
            }
            CaretPos.linepos = 0;
            StackPanel caretpanel = new StackPanel();
            caretpanel.Focusable = false;
            caretpanel.Children.Add(caret.Make(50));
            this.Children.Add(caretpanel);
            SetCaretPos.FromLine(this);
        }

        private void Line_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
            
            }
        
        private void Lin_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            type.ln = this;
            type.typing(e.Key);
        }
        
        
    }
}
