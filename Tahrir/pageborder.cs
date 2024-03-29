using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tahrir
{
    class pageborder:Border
    {
        public Page page = new Page();
        Size size = new Size();
        public PageSetup pagesetup = new PageSetup();
        public pageborder()
        {
            this.Focusable = false;
            this.Child = page;
            Thickness thickness = new Thickness(2);
            this.BorderThickness = thickness;
            this.BorderBrush = System.Windows.Media.Brushes.Black;
            this.Background = System.Windows.Media.Brushes.White;
            pagesetup.PageSize = "A4";
            size  = pagesetup.getsize();
            this.Height = size.Height;
            this.Width = size.Width;
        }
    }
}
