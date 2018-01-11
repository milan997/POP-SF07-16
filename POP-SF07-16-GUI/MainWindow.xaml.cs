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
            viewAkcija.Filter = Filter<Akcija>;

            viewDodatnaUsluga = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUslugaLista);
            dgDodatnaUsluga.ItemsSource = viewDodatnaUsluga;
            dgDodatnaUsluga.DataContext = this;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
            dgDodatnaUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewDodatnaUsluga.Filter = Filter<DodatnaUsluga>;

            viewKorisnik = CollectionViewSource.GetDefaultView(Projekat.Instance.KorisnikLista);
            dgKorisnik.ItemsSource = viewKorisnik;
            dgKorisnik.DataContext = this;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewKorisnik.Filter = Filter<Korisnik>;

            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
            dgNamestaj.ItemsSource = viewNamestaj;
            dgNamestaj.DataContext = this;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewNamestaj.Filter = Filter<Namestaj>;

            viewSalon = CollectionViewSource.GetDefaultView(Projekat.Instance.SalonLista);
            dgSalon.ItemsSource = viewSalon;
            dgSalon.DataContext = this;
            dgSalon.IsSynchronizedWithCurrentItem = true;
            dgSalon.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewSalon.Filter = Filter<Salon>;

            viewTipNamestaja = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestajaLista);
            dgTipNamestaja.ItemsSource = viewTipNamestaja;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            viewTipNamestaja.Filter = Filter<TipNamestaja>;
            
            viewProdaja = CollectionViewSource.GetDefaultView(Projekat.Instance.ProdajaLista);
            dgProdaja.ItemsSource = viewProdaja;
            dgProdaja.DataContext = this;
            dgProdaja.IsSynchronizedWithCurrentItem = true;
            dgProdaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            // Ako ulogovani nije admin
            if (Projekat.Instance.LogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac)
            {
                tiSalon.Visibility = Visibility.Collapsed;
                tiTipNamestaja.Visibility = Visibility.Collapsed;
                tiKorisnik.Visibility = Visibility.Collapsed;

                tbc.SelectedItem = tiProdaja;
                
                btnObrisi.Visibility = Visibility.Collapsed;
            }
            
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            tab = (tbc.SelectedItem as TabItem).Header.ToString();

            if (Projekat.Instance.LogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac && tab != "Prodaja")
            {
                MessageBox.Show("Nemate privilegiju!!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(tab == "Akcije")
            {
                Akcija novaAkcija = new Akcija();
                AkcijaWindow w = new AkcijaWindow(novaAkcija);
                w.ShowDialog();

                viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijaLista);
                dgAkcija.ItemsSource = viewAkcija;
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
                ProdajaWindow w = new ProdajaWindow(novaProdaja);
                w.ShowDialog();

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

            if (Projekat.Instance.LogovaniKorisnik.TipKorisnika == TipKorisnika.Prodavac && tab != "Prodaja")
            {
                MessageBox.Show("Nemate privilegiju!!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dgAkcija.SelectedItem == null && dgDodatnaUsluga.SelectedItem == null && dgKorisnik.SelectedItem == null && dgNamestaj.SelectedItem == null
                && dgProdaja.SelectedItem == null && dgSalon.SelectedItem == null && dgTipNamestaja.SelectedItem == null)
            {
                MessageBox.Show("Nista nije selektovano!!!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
                ProdajaWindow w = new ProdajaWindow(IzabranaProdaja, Operacija.IZMENA);
                w.ShowDialog();
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

            if (tab == "Prodaja")
            {
                MessageBox.Show("Ne mozete obrisati prodaju!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (dgAkcija.SelectedItem == null && dgDodatnaUsluga.SelectedItem == null && dgKorisnik.SelectedItem == null && dgNamestaj.SelectedItem == null
                && dgProdaja.SelectedItem == null && dgSalon.SelectedItem == null && dgTipNamestaja.SelectedItem == null)
            {
                MessageBox.Show("Nista nije selektovano!!!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
               

            MessageBoxResult mbr = MessageBox.Show("Da li ste sigurni da zelite da brisete?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (mbr != MessageBoxResult.Yes)
                return;

            if (tab == "Akcije")
            {
                Akcija izabranaAkcija = IzabranaAkcija;
                izabranaAkcija.Obrisan = true;
                AkcijaDAO.Update(izabranaAkcija);

                viewAkcija.Filter = Filter<Akcija>;
                dgAkcija.ItemsSource = viewAkcija;
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUsluga izabranaDodatnaUsluga = IzabranaDodatnaUsluga;
                izabranaDodatnaUsluga.Obrisan = true;
                DodatnaUslugaDAO.Update(izabranaDodatnaUsluga);

                viewDodatnaUsluga.Filter = Filter<DodatnaUsluga>;
                dgDodatnaUsluga.ItemsSource = viewDodatnaUsluga;
            }
            else if (tab == "Korisnici")
            {
                Korisnik izabraniKorisnik = IzabraniKorisnik;
                izabraniKorisnik.Obrisan = true;
                KorisnikDAO.Update(izabraniKorisnik);

                viewKorisnik.Filter = Filter<Korisnik>;
                dgKorisnik.ItemsSource = viewKorisnik;
            }
            else if (tab == "Prodaja")
            {
                MessageBox.Show("Ne mozete obrisati prodaju!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tab == "Namestaj")
            {
                Namestaj izabraniNamestaj = IzabraniNamestaj;
                izabraniNamestaj.Obrisan = true;
                NamestajDAO.Update(izabraniNamestaj);

                viewNamestaj.Filter = Filter<Namestaj>;
                dgNamestaj.ItemsSource = viewNamestaj;
            }
            else if (tab == "Salon")
            {
                Salon izabraniSalon = IzabraniSalon;
                izabraniSalon.Obrisan = true;
                SalonDAO.Update(izabraniSalon);

                viewSalon.Filter = Filter<Salon>;
                dgSalon.ItemsSource = viewSalon;
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestaja izabraniTipNamestaja = IzabraniTipNamestaja;
                TipNamestajaDAO.Delete(izabraniTipNamestaja);

                viewTipNamestaja.Filter = Filter<TipNamestaja>;
                dgTipNamestaja.ItemsSource = viewTipNamestaja;


                viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
                viewNamestaj.Filter = Filter<Namestaj>;
                dgNamestaj.ItemsSource = viewNamestaj;
            }
        }

        private void btnPogled_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem == null && dgDodatnaUsluga.SelectedItem == null && dgKorisnik.SelectedItem == null && dgNamestaj.SelectedItem == null
                && dgProdaja.SelectedItem == null && dgSalon.SelectedItem == null && dgTipNamestaja.SelectedItem == null)
            {
                MessageBox.Show("Nista nije selektovano!!!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            tab = (tbc.SelectedItem as TabItem).Header.ToString();
            if (tab == "Akcije")
            {
                AkcijaWindow w = new AkcijaWindow(IzabranaAkcija, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Dodatne Usluge")
            {
                DodatnaUslugaWindow w = new DodatnaUslugaWindow(IzabranaDodatnaUsluga, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Korisnici")
            {
                KorisnikWindow w = new KorisnikWindow(IzabraniKorisnik, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Namestaj")
            {
                NamestajWindow w = new NamestajWindow(IzabraniNamestaj, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Prodaja")
            {
                ProdajaWindow w = new ProdajaWindow(IzabranaProdaja, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Salon")
            {
                SalonWindow w = new SalonWindow(IzabraniSalon, Operacija.POGLED);
                w.ShowDialog();
            }
            else if (tab == "Tipovi Namestaja")
            {
                TipNamestajaWindow w = new TipNamestajaWindow(IzabraniTipNamestaja, Operacija.POGLED);
                w.ShowDialog();
            }
        }

        private void AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            if (header == "Id" || header == "Obrisan" || header == "KupljeniNamestajLista" || header == "KupljenaDodatnaUslugaLista") //Navodimo ime kolone koju ne zelimo da prikazemo
                e.Cancel = true;
        }

        // FILTER
        private bool Filter<T>(object obj) where T : class
        {
            T t = obj as T;
            bool? obrisan = false;
            try { obrisan = t.GetType().GetProperty("Obrisan").GetValue(obj) as bool?; } catch { }
            if (obrisan == true)
                return false;
            if(t is Namestaj)
            {
                Namestaj namestaj = t as Namestaj;
                // Znam da je odvratno...
                if (!(namestaj.Naziv.ToLower()).Contains(tbNaziv.Text.ToLower().Trim()))
                    return false;
                else if (!(namestaj.Sifra.ToLower()).Contains(tbSifra.Text.ToLower().Trim()))
                    return false;
                else if (tn != null && (namestaj.TipNamestaja == null || namestaj.TipNamestaja.Id != tn.Id))
                    return false;     
            }

            else if(t is Prodaja)
            {
                Prodaja prodaja = t as Prodaja;

                if (!(prodaja.Kupac.ToLower()).Contains(tbKupac.Text.ToLower().Trim()))
                    return false;
                if (!(prodaja.BrRacuna.ToLower()).Contains(tbBrojRacuna.Text.ToLower().Trim()))
                    return false;
                if (dpOd != null && dpOd.SelectedDate > prodaja.DatumProdaje)
                    return false;
                if (dpDo != null && dpDo.SelectedDate < prodaja.DatumProdaje)
                    return false;

                if (nn != null)
                {
                    foreach (KupljeniNamestaj kn in prodaja.KupljeniNamestajLista)
                    {
                        if (kn.Namestaj.Id == nn.Id)
                        {
                            // Ako pronadje namestaj moze da vrati true jer su sve ostale provere izvrsene
                            return true;
                        }
                    }
                }
                // Posto je prosao sve provere, ako je trazeni namestaj null moze vrati true
                else if (nn == null)
                    return true;

                // Ako nije vratio true u petlji gore, vratice false ovde
                return false;


            }

            else if(t is Korisnik)
            {
                Korisnik korisnik = t as Korisnik;
                if (!(korisnik.Ime.ToLower()).Contains(tbIme.Text.ToLower().Trim()))
                    return false;
                if (!(korisnik.Prezime.ToLower()).Contains(tbPrezime.Text.ToLower().Trim()))
                    return false;
                if (!(korisnik.KorIme.ToLower()).Contains(tbKorisnickoIme.Text.ToLower().Trim()))
                    return false;
            }

            else if (t is Akcija)
            {
                Akcija akcija = t as Akcija;
                if (checkBoxAkcije.IsChecked.GetValueOrDefault())
                {
                    if (akcija.DatumPocetka > DateTime.Today.Date)
                        return false;
                    if (akcija.DatumZavrsetka < DateTime.Today.Date)
                        return false;
                }
            }

            // Ako prodje sve provere!!!
            return true; 
        }

        // Pretraga namestaj
        private TipNamestaja tn = null;

        private void namestaj_LostFocus(object sender, RoutedEventArgs e)
        {
            viewNamestaj.Filter = Filter<Namestaj>;
            dgNamestaj.ItemsSource = viewNamestaj;
        }

        private void izaberiTipNamestaj_Click(object sender, RoutedEventArgs e)
        {
            IzaberiTipNamestaja itn = new IzaberiTipNamestaja();
            if (itn.ShowDialog() == true)
            {
                tn = itn.IzabranTipNamestaja;
                tbTipNamestaja.Text = tn.Naziv;
            }
        }

        private void ocistiTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            tn = null;
            tbTipNamestaja.Text = "";
        }

        // Pretraga prodaja
        Namestaj nn = null;

        private void prodaja_LostFocus(object sender, RoutedEventArgs e)
        {
            viewProdaja.Filter = Filter<Prodaja>;
            dgProdaja.ItemsSource = viewProdaja;
        }

        private void ponistiPretraguProdaje_Click(object sender, RoutedEventArgs e)
        {
            tbBrojRacuna.Text = "";
            tbKupac.Text = "";
            dpOd.SelectedDate = null;
            dpDo.SelectedDate = null;

            nn = null;
            tbNamestaj.Text = "";

            prodaja_LostFocus(sender, e);
        }

        private void izaberiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            IzaberiNamestaj @in = new IzaberiNamestaj();
            if (@in.ShowDialog() == true)
            {
                nn = @in.IzabranNamestaj;
                tbNamestaj.Text = nn.Naziv;
            }
        }

        private void ocistiNamestaj_Click(object sender, RoutedEventArgs e)
        {
            nn = null;
            tbNamestaj.Text = "";
        }
        
        // Pretraga korisnika
        private void korisnik_LostFocus(object sender, RoutedEventArgs e)
        {
            viewKorisnik.Filter = Filter<Korisnik>;
            dgKorisnik.ItemsSource = viewKorisnik;
        }

        // Pretraga akcija
        private void aktuleneAkcije_Click(object sender, RoutedEventArgs e)
        {
            viewAkcija.Filter = Filter<Akcija>;
            dgAkcija.ItemsSource = viewAkcija;
        }
    }
}
