using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tahrir
{
    class ColumnBorder:Border
    {
        public Column column = new Column();
        public ColumnBorder()
        {
            this.Child = column;
        }
    }
}
