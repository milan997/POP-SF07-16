using POP_SF07_16.Model;
using POP_SF07_16.Utils;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public Akcija IzabranaAkcija { get; set; }
        public DodatnaUsluga IzabranaDodatnaUsluga { get; set; }
        public Korisnik IzabranKorisnik { get; set; }
        public Namestaj IzabranNamestaj { get; set; }
        public Salon IzabranSalon { get; set; }
        public TipNamestaja IzabranTipNamestaja { get; set; }

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
            dgTipNamestaja.ItemsSource = viewSalon;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
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
                //dgAkcija.Items.Refresh();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUsluga novaDodatnaUsluga = new DodatnaUsluga();
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(novaDodatnaUsluga);
                w.ShowDialog();
            }
            else if (tab == "Korisnici")
            {
                KorisnikWindow w = new KorisnikWindow();
                w.ShowDialog();
            }
            else if (tab == "Namestaj")
            {
                NamestajWindow w = new NamestajWindow();
                w.ShowDialog();
            }
            else if (tab == "Salon")
            {
                SalonWindow w = new SalonWindow();
                w.ShowDialog();
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestajaWindow w = new TipNamestajaWindow();
                w.ShowDialog();
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if (tab == "Akcije")
            {
                AkcijaWindow w = new AkcijaWindow(IzabranaAkcija);
                w.ShowDialog();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(dgDodatnaUsluga.SelectedItem as DodatnaUsluga);
                w.ShowDialog();
            }
            else if (tab == "Korisnici")
            {
                KorisnikWindow w = new KorisnikWindow(dgKorisnik.SelectedItem as Korisnik);
                w.ShowDialog();
            }
            else if (tab == "Namestaj")
            {
                NamestajWindow w = new NamestajWindow();
                w.ShowDialog();
            }
            else if (tab == "Salon")
            {
                SalonWindow w = new SalonWindow();
                w.ShowDialog();
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestajaWindow w = new TipNamestajaWindow();
                w.ShowDialog();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if (tab == "Akcije")
            {
                Akcija selektovanaAkcija = IzabranaAkcija;
                selektovanaAkcija.Obrisan = true;
                AkcijaDAL.Update(selektovanaAkcija);
                //Projekat.Instance.AkcijaLista.Remove(selektovanaAkcija);
            }
            else if (tab == "Dodatne Usluge")
            {
                
            }
            else if (tab == "Korisnici")
            {
                
            }
            else if (tab == "Namestaj")
            {
                
            }
            else if (tab == "Salon")
            {
                
            }
            else if (tab == "Tipovi Namestaja")
            {
                
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
