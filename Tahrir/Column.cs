using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tahrir
{
    class Column:MyStackPanel
    {
        public List<Paragraph> paragraphs { get; set; }
        public Column()
        {
            this.Focusable = false;
            paragraphs = new List<Paragraph>();
           paragraphs.Add(new Paragraph());
            paragraphs[0].number = 0;
            this.Children.Add(paragraphs[0]);
           
        }
    }
}
