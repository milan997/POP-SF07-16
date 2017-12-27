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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        Salon original;
        Salon kopija;

        Operacija operacija;

        public SalonWindow(Salon s, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = s;
            kopija = s.Clone() as Salon;
            this.DataContext = kopija;
            this.operacija = operacija;
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (operacija == Operacija.DODAVANJE) // Ako dodajemo objekat
                {
                    SalonDAO.Add(kopija);

                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.Obrisan = kopija.Obrisan;
                    original.Adresa = kopija.Adresa;
                    original.BrRacuna = kopija.BrRacuna;
                    original.Email = kopija.Email;
                    original.MaticniBroj = kopija.MaticniBroj;
                    original.Pib = kopija.Pib;
                    original.Naziv = kopija.Naziv;
                    original.Telefon = kopija.Telefon;
                    original.WebAdresa = kopija.WebAdresa;

                    SalonDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = SalonDAO.GetList();
                    lista[original.Id] = kopija;
                }

            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
