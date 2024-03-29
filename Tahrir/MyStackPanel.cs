using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tahrir
{
    class MyStackPanel:StackPanel
    {
        public int number { get; set; }
        public Address address = new Address();
    }
}
