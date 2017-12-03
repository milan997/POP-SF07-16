using POP_SF07_16.Model;
using POP_SF07_16.Utils;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static POP_SF07_16_GUI.Utils.Enum;

namespace POP_SF07_16_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tab;

        ICollectionView viewAkcija;
        ICollectionView viewDodatnaUsluga;
        ICollectionView viewKorisnik;
        ICollectionView viewNamestaj;
        ICollectionView viewSalon;
        ICollectionView viewTipNamestaja;
        ICollectionView viewProdaja;

        public Akcija IzabranaAkcija { get; set; }
        public DodatnaUsluga IzabranaDodatnaUsluga { get; set; }
        public Korisnik IzabraniKorisnik { get; set; }
        public Namestaj IzabraniNamestaj { get; set; }
        public Salon IzabraniSalon { get; set; }
        public TipNamestaja IzabraniTipNamestaja { get; set; }
        public Prodaja IzabranaProdaja { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijaLista);
            dgAkcija.ItemsSource = viewAkcija;
            dgAkcija.DataContext = this;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewDodatnaUsluga = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUslugaLista);
            dgDodatnaUsluga.ItemsSource = viewDodatnaUsluga;
            dgDodatnaUsluga.DataContext = this;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
            dgDodatnaUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewKorisnik = CollectionViewSource.GetDefaultView(Projekat.Instance.KorisnikLista);
            dgKorisnik.ItemsSource = viewKorisnik;
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
            dgNamestaj.ItemsSource = viewNamestaj;
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewSalon = CollectionViewSource.GetDefaultView(Projekat.Instance.SalonLista);
            dgSalon.ItemsSource = viewSalon;
            dgSalon.DataContext = this;
            dgSalon.IsSynchronizedWithCurrentItem = true;
            dgSalon.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            viewTipNamestaja = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestajaLista);
            dgTipNamestaja.ItemsSource = viewTipNamestaja;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
            viewProdaja = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaLista);
            dgProdaja.ItemsSource = viewProdaja;
            dgProdaja.DataContext = this;
            dgProdaja.IsSynchronizedWithCurrentItem = true;
            dgProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            
        }

        private bool FilteredAkcija(object obj)
        {
            Akcija akcijaZaFilter = (Akcija)obj;
            if (akcijaZaFilter.Obrisan == true)
            {
                return false;
            }
            else
            {
                return true;
            }
            // return ((Akcija)obj).Obrisan == false;     JEDNA LINIJA!!!!
            // return !((Akcija)obj).Obrisan;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if(tab == "Akcije")
            {
                Akcija novaAkcija = new Akcija();
                AkcijaWindow w = new AkcijaWindow(novaAkcija);
                w.ShowDialog();
                viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijaLista);
                dgAkcija.ItemsSource = viewAkcija;
                //dgAkcija.Items.Refresh();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUsluga novaDodatnaUsluga = new DodatnaUsluga();
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(novaDodatnaUsluga);
                w.ShowDialog();
                viewDodatnaUsluga = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUslugaLista);
                dgDodatnaUsluga.ItemsSource = viewDodatnaUsluga;

            }
            else if (tab == "Korisnici")
            {

                Korisnik noviKorisnik = new Korisnik();
                KorisnikWindow w = new KorisnikWindow(noviKorisnik);
                w.ShowDialog();
                viewKorisnik = CollectionViewSource.GetDefaultView(Projekat.Instance.KorisnikLista);
                dgKorisnik.ItemsSource = viewKorisnik;
            }
            else if (tab == "Namestaj")
            {
                Namestaj noviNamestaj = new Namestaj();
                NamestajWindow w = new NamestajWindow(noviNamestaj);
                w.ShowDialog();
                viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
                dgNamestaj.ItemsSource = viewNamestaj;
            }
            else if (tab == "Prodaja")
            {
                Prodaja novaProdaja= new Prodaja();
                //ProdajaWindow w = new ProdajaWindow(novaProdaja);
                //w.ShowDialog();
                viewProdaja = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaLista);
                dgProdaja.ItemsSource = viewProdaja;
            }
            else if (tab == "Salon")
            {
                Salon noviSalon = new Salon();
                SalonWindow w = new SalonWindow(noviSalon);
                w.ShowDialog();
                viewSalon = CollectionViewSource.GetDefaultView(Projekat.Instance.SalonLista);
                dgSalon.ItemsSource = viewSalon;
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestaja noviTipNamestaja = new TipNamestaja();
                TipNamestajaWindow w = new TipNamestajaWindow(noviTipNamestaja);
                w.ShowDialog();
                viewTipNamestaja = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestajaLista);
                dgTipNamestaja.ItemsSource = viewTipNamestaja;
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if (tab == "Akcije")
            {
                AkcijaWindow w = new AkcijaWindow(IzabranaAkcija, Operacija.IZMENA);
                w.ShowDialog();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(IzabranaDodatnaUsluga, Operacija.IZMENA);
                w.ShowDialog();
            }
            else if (tab == "Korisnici")
            {
                KorisnikWindow w = new KorisnikWindow(IzabraniKorisnik, Operacija.IZMENA);
                w.ShowDialog();
            }
            else if (tab == "Namestaj")
            {
                NamestajWindow w = new NamestajWindow(IzabraniNamestaj, Operacija.IZMENA);
                w.ShowDialog();
            }
            else if (tab == "Prodaja")
            {
                //ProdajaWindow w = new ProdajaWindow(IzabranaProdaja, Operacija.IZMENA);
                //w.ShowDialog();
            }
            else if (tab == "Salon")
            {
                SalonWindow w = new SalonWindow(IzabraniSalon, Operacija.IZMENA);
                w.ShowDialog();
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestajaWindow w = new TipNamestajaWindow(IzabraniTipNamestaja, Operacija.IZMENA);
                w.ShowDialog();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if (tab == "Akcije")
            {
                Akcija izabranaAkcija = IzabranaAkcija;
                izabranaAkcija.Obrisan = true;
                AkcijaDAL.Update(izabranaAkcija);
                //Projekat.Instance.AkcijaLista.Remove(selektovanaAkcija);
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUsluga izabranaDodatnaUsluga = IzabranaDodatnaUsluga;
                izabranaDodatnaUsluga.Obrisan = true;
                DodatnaUslugaDAL.Update(izabranaDodatnaUsluga);
            }
            else if (tab == "Korisnici")
            {
                Korisnik izabraniKorisnik = IzabraniKorisnik;
                izabraniKorisnik.Obrisan = true;
                KorisnikDAL.Update(izabraniKorisnik);
            }
            else if (tab == "Prodaja")
            {
                MessageBox.Show("Ne mozete obrisati prodaju!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tab == "Namestaj")
            {
                Namestaj izabraniNamestaj = IzabraniNamestaj;
                izabraniNamestaj.Obrisan = true;
                NamestajDAL.Update(izabraniNamestaj);
            }
            else if (tab == "Salon")
            {
                Salon izabraniSalon = IzabraniSalon;
                izabraniSalon.Obrisan = true;
                SalonDAL.Update(izabraniSalon);
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestaja izabraniTipNamestaja = IzabraniTipNamestaja;
                izabraniTipNamestaja.Obrisan = true;
                TipNamestajaDAL.Update(izabraniTipNamestaja);
            }
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.Column.Header.ToString() == "Id") //Navodimo ime kolone koju ne zelimo da prikazemo
            {
                e.Cancel = true;
            }
        }
    }
}
