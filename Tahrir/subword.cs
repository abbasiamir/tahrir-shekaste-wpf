using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahrir
{
    class subword:MyStackPanel
    {
        public Address address = new Address();
        public subword()
        {
            this.MouseDown += Subword_MouseDown;
        }

        private void Subword_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {

                Contex.subword.address.fillAddress(UIETypes.SubWord, this);

                
            }

        }
    }
}
