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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tahrir
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        //private void Convert_Click()
        //{
        //    Windowpics window = new Windowpics();
        //    window.Show();
        //}
        void start()
        {
            
            font.Focusable = false;
            font.SelectionChanged += Font_SelectionChanged;
            font.SelectedIndex = 0;
            Font.font = font.Text;
            this.WindowState = WindowState.Maximized;
            ScrollViewer scroll = new ScrollViewer();
            scroll.Focusable = false;
            scroll.Content = Workspace.frame;
            MainGrid.Children.Add(scroll);
        }

        private void Font_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Font.font = font.Text;
        }

        private void font_Selected(object sender, RoutedEventArgs e)
        {
            Font.font = font.Text;
        }
    }
}
