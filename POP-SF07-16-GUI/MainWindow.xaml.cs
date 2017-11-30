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
        public Akcija IzabranaAkcija { get; set; }

        public MainWindow()
        {
            /*
            var pw = new KorisnikWindow();
            pw.ShowDialog();
            */
            InitializeComponent();
                        
            viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijaLista);
            viewAkcija.Filter = FilteredAkcija;
            dgAkcija.ItemsSource = viewAkcija;
            dgAkcija.DataContext = this;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgDodatnaUsluga.ItemsSource = DodatnaUslugaDAL.GetList();
            dgDodatnaUsluga.DataContext = this;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
            dgDodatnaUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgKorisnik.ItemsSource = KorisnikDAL.GetList();
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgNamestaj.ItemsSource = NamestajDAL.GetList();
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgSalon.ItemsSource = Projekat.Instance.SalonLista; //IZMENI OVO
            dgSalon.DataContext = this;
            dgSalon.IsSynchronizedWithCurrentItem = true;
            dgSalon.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgTipNamestaja.ItemsSource = TipNamestajaDAL.GetList();
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

        private void btnDodajTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            //var window = new TipNamestajaWindow();
            //window.ShowDialog();
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
                AkcijaWindow w = new AkcijaWindow();
                w.ShowDialog();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUslugaWindow w = new DodatnaUslugaWindow();
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
                AkcijaWindow w = new AkcijaWindow(dgAkcija.SelectedItem as Akcija);
                w.ShowDialog();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(dgDodatnaUsluga.SelectedItem as DodatnaUsluga);
                w.ShowDialog();
            }
            else if (tab == "Korisnici")
            {
                KorisnikWindow w = new KorisnikWindow(/*dgKorisnik.SelectedItem as Korisnik*/);
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
