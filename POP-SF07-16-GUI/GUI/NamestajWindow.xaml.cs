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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        Namestaj original;
        Namestaj kopija;


        Operacija operacija;

        public NamestajWindow(Namestaj n, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = n;
            kopija = n.Clone() as Namestaj;
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
                    NamestajDAO.Add(kopija);

                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.Cena = kopija.Cena;
                    original.Obrisan = kopija.Obrisan;
                    original.Naziv = kopija.Naziv;
                    original.Sifra = kopija.Sifra;
                    original.Akcija = kopija.Akcija;
                    //original.AkcijaID = kopija.AkcijaID;
                    original.KolicinaUMagacinu = kopija.KolicinaUMagacinu;
                    original.TipNamestaja = kopija.TipNamestaja;
                    //original.TipNamestajaID = kopija.TipNamestajaID;
                    
                    NamestajDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = NamestajDAO.GetList();
                    lista[original.Id] = kopija;
                }

            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void izaberiTipNamestaj_Click(object sender, RoutedEventArgs e)
        {
            IzaberiTipNamestaja itn = new IzaberiTipNamestaja();
            if (itn.ShowDialog() == true)
            {
                kopija.TipNamestaja = itn.IzabranTipNamestaja;
            }
        }

        private void izaberiAkcija_Click(object sender, RoutedEventArgs e)
        {
            IzaberiAkcija ia = new IzaberiAkcija();
            if (ia.ShowDialog() == true)
            {
                kopija.Akcija = ia.IzabranaAkcija;
            }
        }
    }
}
