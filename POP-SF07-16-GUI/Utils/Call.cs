using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF07_16_GUI.Utils
{
    public static class Call
    {
        //Spaghetti klasa, trpamo svasta
        public static void CheckOnClose(Window window)
        {
            //Funkcija pita da li zelimo da sacuvamo izmene, prosto
            //Izdvojena je iz razloga lakseg odrzavanja, ako nekad budemo zeleli izmeniti mozemo sa jednog mesta
            if (MessageBox.Show("Izmene nece biti sacuvane, da li ste sigurni?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation)
                == MessageBoxResult.Yes)
                    window.Close();
        }
    }
}
