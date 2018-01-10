using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public KupljeniNamestaj IzabranKupljenNamestaj { get; set; }
        public KupljenaDodatnaUsluga IzabranKupljenaDodatnaUsluga { get; set; }

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

            viewDodatneUsluge = CollectionViewSource.GetDefaultView(kopija.KupljenaDodatnaUslugaLista);
            dgDodatneUsluge.ItemsSource = viewDodatneUsluge;
            dgDodatneUsluge.DataContext = this;
            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (operacija == Operacija.POGLED)
            {
                dpDatumProdaje.IsEnabled = false;
                tbBrojRacuna.IsReadOnly = true;
                tbKupac.IsReadOnly = true;

                ObrisiNamestaj.Visibility = Visibility.Collapsed;
                IzmeniNamestaj.Visibility = Visibility.Collapsed;
                DodajNamestaj.Visibility = Visibility.Collapsed;

                ObrisiUsluge.Visibility = Visibility.Collapsed;
                IzmeniUsluge.Visibility = Visibility.Collapsed;
                DodajUsluge.Visibility = Visibility.Collapsed;

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
                    ProdajaDAO.Add(kopija);
                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.BrRacuna = kopija.BrRacuna;
                    original.DatumProdaje = kopija.DatumProdaje;
                    original.Kupac = kopija.Kupac;

                    original.KupljenaDodatnaUslugaLista = kopija.KupljenaDodatnaUslugaLista;
                    original.KupljeniNamestajLista = kopija.KupljeniNamestajLista;

                    ProdajaDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = ProdajaDAO.GetList();
                    lista[original.Id] = kopija;
                }
            }
        }

        /////////////////////////
        /// Kupljeni Namestaj ///
        /////////////////////////
        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajWindow dnw = new DodajNamestajWindow(kopija, new KupljeniNamestaj());

            if (dnw.ShowDialog() == true)
            {
                ObservableCollection<KupljeniNamestaj> lista = kopija.KupljeniNamestajLista;

                //Proveravamo da li namestaj vec postoji u prodaji! Ako postoji, samo mu dodamo novu kolicinu
                bool postoji = false;
                foreach(KupljeniNamestaj kn in lista)
                {
                    if(kn.Namestaj.Id == dnw.kopija.Namestaj.Id)
                    {
                        kn.Kolicina += dnw.kopija.Kolicina;
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    lista.Add(dnw.kopija);
                }
                kopija.KupljeniNamestajLista = lista;
            }
            viewKupljeniNamestaj = CollectionViewSource.GetDefaultView(kopija.KupljeniNamestajLista);
            dgKupljeniNamestaj.ItemsSource = viewKupljeniNamestaj;
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajWindow dnw = new DodajNamestajWindow(kopija, IzabranKupljenNamestaj, Operacija.IZMENA);
            if (dnw.ShowDialog() == true)
            {
                ObservableCollection<KupljeniNamestaj> lista = kopija.KupljeniNamestajLista;

                //Stari objekat izbacujem iz liste u svakom slucaju
                lista.Remove(IzabranKupljenNamestaj);
                
                //Proveravamo da li namestaj vec postoji u prodaji! Ako postoji, samo mu dodamo novu kolicinu
                bool postoji = false;
                foreach (KupljeniNamestaj kn in lista)
                {
                    if (kn.Namestaj.Id == dnw.kopija.Namestaj.Id)
                    {
                        kn.Kolicina += dnw.kopija.Kolicina;
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    lista.Add(dnw.kopija);
                }
                
                kopija.KupljeniNamestajLista = lista;
            }
            viewKupljeniNamestaj = CollectionViewSource.GetDefaultView(kopija.KupljeniNamestajLista);
            dgKupljeniNamestaj.ItemsSource = viewKupljeniNamestaj;
        }

        private void ObrisiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            KupljeniNamestaj kn = dgKupljeniNamestaj.SelectedItem as KupljeniNamestaj;
            kn.Obrisan = true;
            //kopija.KupljeniNamestajLista.Remove(kn);
        }

       
        ///////////////////////////////
        /// Kupljene Dodatne Usluge ///
        ///////////////////////////////
        private void DodajUsluge_Click(object sender, RoutedEventArgs e)
        {
            DodajDodatnaUslugaWindow dduw = new DodajDodatnaUslugaWindow(kopija, new KupljenaDodatnaUsluga());

            if (dduw.ShowDialog() == true)
            {
                ObservableCollection<KupljenaDodatnaUsluga> lista = kopija.KupljenaDodatnaUslugaLista;

                //Proveravamo da li dodatna usluga vec postoji u prodaji! Ako postoji, samo dodamo novu kolicinu
                bool postoji = false;
                foreach (KupljenaDodatnaUsluga kdu in lista)
                {
                    if (kdu.DodatnaUsluga.Id == dduw.kopija.DodatnaUsluga.Id)
                    {
                        kdu.Kolicina += dduw.kopija.Kolicina;
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    lista.Add(dduw.kopija);
                }
                kopija.KupljenaDodatnaUslugaLista = lista;
            }
            viewDodatneUsluge = CollectionViewSource.GetDefaultView(kopija.KupljenaDodatnaUslugaLista);
            dgDodatneUsluge.ItemsSource = viewDodatneUsluge;
        }

        private void IzmeniUsluge_Click(object sender, RoutedEventArgs e)
        {
            DodajDodatnaUslugaWindow dduw = new DodajDodatnaUslugaWindow(kopija, IzabranKupljenaDodatnaUsluga, Operacija.IZMENA);
            if (dduw.ShowDialog() == true)
            {
                ObservableCollection<KupljenaDodatnaUsluga> lista = kopija.KupljenaDodatnaUslugaLista;

                //Stari objekat izbacujem iz liste u svakom slucaju
                lista.Remove(IzabranKupljenaDodatnaUsluga);

                //Proveravamo da li namestaj vec postoji u prodaji! Ako postoji, samo mu dodamo novu kolicinu
                bool postoji = false;
                foreach (KupljenaDodatnaUsluga kdu in lista)
                {
                    if (kdu.DodatnaUsluga.Id == dduw.kopija.DodatnaUsluga.Id)
                    {
                        kdu.Kolicina += dduw.kopija.Kolicina;
                        postoji = true;
                        break;
                    }
                }
                if (!postoji)
                {
                    lista.Add(dduw.kopija);
                }

                kopija.KupljenaDodatnaUslugaLista = lista;
            }
            viewDodatneUsluge = CollectionViewSource.GetDefaultView(kopija.KupljenaDodatnaUslugaLista);
            dgDodatneUsluge.ItemsSource = viewDodatneUsluge;
        }

        private void ObrisiUsluge_Click(object sender, RoutedEventArgs e)
        {
            KupljenaDodatnaUsluga kdu = dgDodatneUsluge.SelectedItem as KupljenaDodatnaUsluga;
            kdu.Obrisan = true;
            //kopija.KupljeniNamestajLista.Remove(kn);
        }



        ////////////////////
        /// Otkazi dugme ///
        ////////////////////
        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
