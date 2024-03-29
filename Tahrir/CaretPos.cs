using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahrir
{
    static class CaretPos
    {
        static public int page{get;set;}
        static public int column { get; set; }
        static public int paragraph { get; set; }
        static public int line { get; set; }
        static public int linepos { get; set; } = -1;
        
    }
}
