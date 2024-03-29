using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tahrir
{
    static class Dpi
    {
        static public double DpiX { get; set; }
        static public double DpiY { get; set; }
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hDc, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);
        public const int LOGPIXELSX = 88;
        public const int LOGPIXELSY = 90;
        public static double GetDpiX()
        {

            IntPtr DC = GetDC(IntPtr.Zero);
            if (DC != IntPtr.Zero)
            {
                return GetDeviceCaps(DC, LOGPIXELSX);
            }
            ReleaseDC(IntPtr.Zero, DC);
            return 0;
        } 
        public static double GetDpiY()
        {

            IntPtr DC = GetDC(IntPtr.Zero);
            if (DC != IntPtr.Zero)
            {
                return GetDeviceCaps(DC, LOGPIXELSY);
            }
            ReleaseDC(IntPtr.Zero, DC);
            return 0;
        }
    }
}
