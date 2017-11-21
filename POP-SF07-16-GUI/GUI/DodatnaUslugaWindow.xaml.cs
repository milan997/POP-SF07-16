using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.Utils;
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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        DodatnaUsluga dodatnaUsluga;

        public DodatnaUslugaWindow()
        {
            InitializeComponent();
        }

        public DodatnaUslugaWindow(DodatnaUsluga du)
        {
            InitializeComponent();
            tbNaziv.Text = du.Naziv;
            tbCena.Text = du.Cena.ToString();
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text == "" || tbCena.Text == "")
            {
                MessageBox.Show("Niste uneli sve podatke!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Double.TryParse(tbCena.Text.Trim(), out double cena))
            {
                MessageBox.Show("Napravili ste gresku prilikom unosa cene!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cena <= 0)
            {
                MessageBox.Show("Cena mora biti veca od nule!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!NapravljeneIzmene())
            {
                MessageBox.Show("Niste izvrsili nijednu izmenu", "!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                if (dodatnaUsluga == null)
                {
                    //DODAVANJE 
                    dodatnaUsluga = new DodatnaUsluga()
                    {
                        Naziv = tbNaziv.Text,
                        Cena = cena
                    };
                    DodatnaUslugaDAL.Add(dodatnaUsluga);
                }
                else if (dodatnaUsluga != null)
                {
                    //IZMENA
                    dodatnaUsluga.Cena = cena;
                    dodatnaUsluga.Naziv = tbNaziv.Text.Trim();

                    DodatnaUslugaDAL.Update(dodatnaUsluga);
                }
                this.Close();
            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
            if (NapravljeneIzmene())
                Call.CheckOnClose(this);
            else
                Close();
        }

        private Boolean NapravljeneIzmene()
        {
            //Funkcija proverava dva slucaja:
            //  1.) ako je u pitanju dodavanje, proverava da li je ista upisano u polja, ako nije vraca false
            //  2.) ako je u pitanju izmena, proverava da li je ista menjano, ako nije vraca false

            //Dodavanje
            if (dodatnaUsluga == null && tbNaziv.Text.Trim() == "" && tbNaziv.Text.Trim() == "")
                return false;
            //Izmena
            else if (dodatnaUsluga != null && tbNaziv.Text.Trim() == dodatnaUsluga.Naziv 
                && tbCena.Text.Trim() == dodatnaUsluga.Cena.ToString())
                return false;

            //Ako nije palo ni na jednom 'testu', vracamo true sto znaci da je promena izvrsena
            return true;
        }

        private void Handle(object sender, KeyEventArgs e)
        {
            //Funkcija za 'hendlanje evenata', poziva se za sve 'hendlove'
            if (e.Key == Key.Escape)
                Handlers.HandleEsc(sender, e, NapravljeneIzmene());
        }
    }
}
