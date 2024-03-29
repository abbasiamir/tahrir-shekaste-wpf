using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tahrir
{
    /// <summary>
    /// Interaction logic for WindowName.xaml
    /// </summary>
    public partial class WindowName : Window
    {
        public WindowName()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Workspace workspace = new Workspace(nameBox.Text);
            this.Close();
        }
    }
}
