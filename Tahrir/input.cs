using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tahrir
{
    static class input
    {
        public static string getletter(Key key)
        {
            switch (key)
            {
                case Key.K:
                       return "ن";
                case Key.L:
                        return "م";
                case Key.F:
                    return "ب";
                case Key.S:
                    return "س";
                case Key.H:
                    return "ا";
                case Key.G:
                    return "ل";
                case Key.I:
                    return "ه";
            }
            return "";
        }
    }
}
