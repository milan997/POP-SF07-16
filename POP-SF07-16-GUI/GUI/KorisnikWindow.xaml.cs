using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
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
using static POP_SF07_16_GUI.Utils.Enum;

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        Korisnik original;
        Korisnik kopija;

        Operacija operacija;

        public KorisnikWindow(Korisnik k, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = k;
            kopija = k.Clone() as Korisnik;
            this.DataContext = kopija;
            this.operacija = operacija;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
            //cbTipKorisnika.SelectedItem = TipKorisnika.Prodavac;

            if (operacija == Operacija.POGLED)
            {
                tbIme.IsReadOnly = true;
                tbPrezime.IsReadOnly = true;
                tbKorisnickoIme.IsReadOnly = true;
                tbLozinka.IsReadOnly = true;

                cbTipKorisnika.IsReadOnly = true;

                btPotvrdi.Visibility = Visibility.Collapsed;
                btOtkazi.Visibility = Visibility.Collapsed;
            }
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (operacija == Operacija.DODAVANJE) // Ako dodajemo objekat
                {
                    KorisnikDAO.Add(kopija);
                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.Obrisan = kopija.Obrisan;
                    original.Ime = kopija.Ime;
                    original.Prezime = kopija.Prezime;
                    original.KorIme = kopija.KorIme;
                    original.Lozinka = kopija.Lozinka;
                    original.TipKorisnika = kopija.TipKorisnika;

                    KorisnikDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = KorisnikDAO.GetList();
                    lista[original.Id] = kopija;
                }

            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
