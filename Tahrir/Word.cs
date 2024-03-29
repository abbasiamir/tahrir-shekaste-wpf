using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tahrir
{
    class Word:MyStackPanel
    {
        public string word { get; set; }
        public Word()
        {
            this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
            this.MouseDown += Word_MouseDown;
        }

        private void Word_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                caret.clear();
                if (e.GetPosition(this).X > this.ActualWidth / 2)
                {
                    SetCaretPos.FromWord(this);
                }
                if (e.GetPosition(this).X <= this.ActualWidth / 2)
                {
                    SetCaretPos.FromWord(this);
                    CaretPos.linepos++;
                }

                StackPanel caretstack = new StackPanel();
                caretstack.Children.Add(caret.Make(50));
                line ln =(line) this.Parent;
                ln.Children.Insert(CaretPos.linepos, caretstack);

            }
        }
    }
}
