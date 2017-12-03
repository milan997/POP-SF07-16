using POP_SF07_16.Model;
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

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public enum Operacija { DODAVANJE , IZMENA}

        Korisnik original;
        Korisnik kopija;

        public KorisnikWindow()
        {
            InitializeComponent();

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
            cbTipKorisnika.SelectedItem = TipKorisnika.Prodavac;


        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
