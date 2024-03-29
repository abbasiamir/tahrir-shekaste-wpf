using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tahrir
{
    class PageSetup
    {
        public string PageSize { get; set; }
        public string font { get; set; }
        public PageSetup()
        {
            font = Font.font;
        }
        public Size getsize()
        {
            Size size = new Size();
            switch (PageSize)
            {

                case "A5":
                    {
                        size.Width = Dpi.GetDpiX() * 5.826;
                        size.Height = Dpi.GetDpiY() * 8.267;
                        return size;
                    }
                case "A4":
                    {
                        size.Width = Dpi.GetDpiX() * 8.3;
                        size.Height = Dpi.GetDpiY() * 11.7;
                        return size; ;
                    }
                case "A3":
                    {
                        size.Width = Dpi.GetDpiX() * 11.7;
                        size.Height = Dpi.GetDpiY() * 16.5;
                        return size; ;
                    }
                case "A2":
                    {
                        size.Width = Dpi.GetDpiX() * 16.535;
                        size.Height = Dpi.GetDpiY() * 23.385;
                        return size; ;
                    }
                case "A1":
                    {
                        size.Width = Dpi.GetDpiX() * 23.4;
                        size.Height = Dpi.GetDpiY() * 33.1;
                        return size; ;
                    }
            }
            return size;
        }
    }
}
