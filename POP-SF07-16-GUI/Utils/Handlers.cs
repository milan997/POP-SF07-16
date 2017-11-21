using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace POP_SF07_16_GUI.Utils
{
    public static class Handlers
    {
        public static void HandleEsc(object sender, KeyEventArgs e, Boolean napravljeneIzmene)
        {
            //Funkcija reaguje na pritisak ESC tastera, ako je ista uneseno u prozor pitace da li 
            // zelimo da sacuvamo izmene, ako nije - prosto ce zatvoriti dijalog
            if (e.Key == Key.Escape)
            {
                Window w;
                try { w = sender as Window; }
                catch (InvalidCastException ex) { return; }
                
                if (napravljeneIzmene == false)
                    w.Close();
                else
                    Call.CheckOnClose(w);
            }
        }

        public static void HandleDatePicker(object sender, KeyEventArgs e)
        {
            //Funkcija koja otvara DatePicker ukoliko pritisnemo 'space' dok je u fokusu

            if (e.Key == Key.Space) 
            {
                DatePicker dp = sender as DatePicker;
                dp.IsDropDownOpen = true;
            }
        }
    }
}
