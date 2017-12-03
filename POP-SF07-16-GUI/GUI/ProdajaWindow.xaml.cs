using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        Prodaja original;
        Prodaja kopija;

        Operacija operacija;

        ICollectionView viewKupljeniNamestaj;
        ICollectionView viewDodatneUsluge;

        public ProdajaWindow(Prodaja p, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = p;
            kopija = p.Clone() as Prodaja;
            this.DataContext = kopija;
            this.operacija = operacija;
            
            viewKupljeniNamestaj = CollectionViewSource.GetDefaultView(kopija.KupljeniNamestajLista);
            dgKupljeniNamestaj.ItemsSource = viewKupljeniNamestaj;
            dgKupljeniNamestaj.DataContext = this;
            dgKupljeniNamestaj.IsSynchronizedWithCurrentItem = true;
            dgKupljeniNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewDodatneUsluge = CollectionViewSource.GetDefaultView(kopija.DodatnaUslugaLista);
            dgDodatneUsluge.ItemsSource = viewDodatneUsluge;
            dgDodatneUsluge.DataContext = this;
            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (operacija == Operacija.DODAVANJE) // Ako dodajemo objekat
                {
                    ProdajaDAL.Add(kopija);

                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.BrRacuna = kopija.BrRacuna;
                    original.DatumProdaje = kopija.DatumProdaje;
                    original.DodatnaUslugaID = kopija.DodatnaUslugaID;
                    original.DodatnaUslugaLista = kopija.DodatnaUslugaLista;
                    original.Kupac = kopija.Kupac;
                    original.KupljeniNamestajID = kopija.KupljeniNamestajID;
                    original.KupljeniNamestajLista = kopija.KupljeniNamestajLista;

                    ProdajaDAL.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = ProdajaDAL.GetList();
                    lista[original.Id] = kopija;
                }
            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajUsluge_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
