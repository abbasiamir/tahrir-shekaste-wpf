using Microsoft.Win32;
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
using System.Windows.Threading;

namespace Tahrir
{
    /// <summary>
    /// Interaction logic for Windowpics.xaml
    /// </summary>
    public partial class Windowpics : Window
    {
        public Windowpics()
        {
            InitializeComponent();
            fillWords();
            font.SelectedIndex = 0;
        }
        
        void fillWords()
        {
            xml x = new xml();
            words.ItemsSource = x.wordlist(font.Text).OrderBy(a => a);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            dialog.Multiselect = true;
            if ((bool)dialog.ShowDialog())
            {
                progress.Maximum = dialog.FileNames.Count();
                int i = 0;
                string[] picnames = dialog.FileNames;
                foreach (string picname in picnames)
                {
                    string word = picname.Remove(0, picname.LastIndexOf("\\") );
                    word = word.Remove(word.IndexOf("."));
                    picnameLabel.Dispatcher.Invoke(() =>picnameLabel.Content = picname, DispatcherPriority.Background);
                    Picture pic = new Picture();
                    xml x = new xml();
                    if (!x.RegisteredPic(picname,font.Text))
                        pic.Save(picname,font.Text);
                    i++;
                    progress.Dispatcher.Invoke(() => progress.Value = i, DispatcherPriority.Background);
                }
            }
        }

        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.progress.Value = e.NewValue;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            xml x = new xml();
            x.RemoveImage(words.Text,font.Text);
            fillWords();
        }
    }
}
