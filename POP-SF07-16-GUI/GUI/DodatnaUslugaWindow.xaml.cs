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

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        DodatnaUsluga dodatnaUsluga;
        string naziv;

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
                naziv = tbNaziv.Text;
            }
            else if (!Double.TryParse(tbCena.Text.Trim(), out double cena))
            {
                MessageBox.Show("Napravili ste gresku prilikom unosa cene!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cena <= 0)
            {
                MessageBox.Show("Cena mora biti veca od nule!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dodatnaUsluga != null && dodatnaUsluga.Cena == cena && dodatnaUsluga.Naziv == naziv)
            {
                MessageBox.Show("Niste izvrsili nijednu izmenu", "!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNo, MessageBoxImage.Question)
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
                    dodatnaUsluga.Naziv = naziv;

                    DodatnaUslugaDAL.Update(dodatnaUsluga);
                }
                this.Close();
            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
