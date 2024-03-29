using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tahrir
{
    class Paragraph:MyStackPanel
    {
        public List<line> lines { get; set; }
        public Paragraph()
        {
            this.Focusable = false;
            lines = new List<line>();
            line ln = new line();
            ln.number = 0;
            lines.Add(ln);
            this.Children.Add(lines[0]);
          
        }
    }
}
