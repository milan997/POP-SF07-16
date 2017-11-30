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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        Akcija original;
        Akcija kopija;
        //public Akcija IzabranaAkcija { get; set; } //Selektovana akcija u data-gridu
        bool jesteDodavanje = false;

        public AkcijaWindow()
        {
            //Konstruktor bez parametara, poziva se prilikom dodavanja akcije
            InitializeComponent();

            /*

            */
            jesteDodavanje = true;
            /*
            akcija = new Akcija();
            this.DataContext = akcija;
            akcija.DatumPocetka = DateTime.Today;
            akcija.DatumZavrsetka = DateTime.Today;
            */
        }

        public AkcijaWindow(Akcija a)
        {
            //Konstruktor kome prosledjuemo akciju koju zelimo da izmenimo
           

            InitializeComponent();

            original = a;
            kopija = a.Clone() as Akcija;
            this.DataContext = kopija;
            //tbPopust.Text = akcija.Popust.ToString();
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            /*
            if(akcija.DatumPocetka == null || akcija.DatumZavrsetka == null || akcija.Popust.ToString() == "")
            {
                MessageBox.Show("Niste uneli sve podatke!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (akcija.DatumZavrsetka < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Ne mozete izabrati datum koji je prosao!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dpDatumPocetka.SelectedDate >= dpDatumZavrsetka.SelectedDate )
            {
                MessageBox.Show("Akcija se zavrsava pre nego sto pocinje?!?!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Decimal.TryParse(tbPopust.Text.Trim(), out decimal popust))
            {
                MessageBox.Show("Napravili ste gresku prilikom unosa popusta!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (popust < 0 || popust > 100)
            {
                MessageBox.Show("Popust mora biti izmedju 0 i 100!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (NapravljeneIzmene() == false)
            {
                MessageBox.Show("Niste izvrsili nijednu izmenu", "!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            */
            
            if(MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)
                     == MessageBoxResult.Yes)
            {
                if(jesteDodavanje) // Ako dodajemo objekat
                {
                    //DODAVANJE 
                    AkcijaDAL.Add(kopija);
                }
                else if (!jesteDodavanje) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.DatumPocetka = kopija.DatumPocetka;
                    original.DatumZavrsetka = kopija.DatumZavrsetka;
                    original.Popust = kopija.Popust;
                    original.Obrisan = kopija.Obrisan;

                    var lista = AkcijaDAL.GetList();
                    lista[original.Id] = kopija;
                    AkcijaDAL.UpdateList(lista);
                    /*
                    //IZMENA
                    akcija.DatumPocetka = (DateTime) dpDatumPocetka.SelectedDate.Value;
                    akcija.DatumZavrsetka = (DateTime) dpDatumZavrsetka.SelectedDate.Value;
                    akcija.Popust = popust;
                    AkcijaDAL.Update(akcija);
                    */
                }
                this.Close();
            }
            else if (MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question)
                   == MessageBoxResult.No)
            {
                if (!jesteDodavanje)
                {
                    var lista = AkcijaDAL.GetList();
                    lista[original.Id] = kopija;
                }
                
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
            /*
            //Dodavanje
            if (akcija == null && dpDatumPocetka.SelectedDate == DateTime.Today
                && dpDatumZavrsetka.SelectedDate == DateTime.Today && tbPopust.Text.Trim() == "")
                    return false;
            //Izmena
            else if (akcija != null && dpDatumPocetka.SelectedDate == akcija.DatumPocetka
                && dpDatumZavrsetka.SelectedDate == akcija.DatumZavrsetka && akcija.Popust.ToString() == tbPopust.Text.Trim())
                    return false;
            */
            //Ako nije palo ni na jednom 'testu', vracamo true sto znaci da je promena izvrsena
            return true;
        }

        private void Handle(object sender, KeyEventArgs e)
        {
            //Funkcija za 'hendlanje evenata', poziva se za sve 'hendlove'
            if (e.Key == Key.Escape)
                Handlers.HandleEsc(sender, e, NapravljeneIzmene());
            if (sender is DatePicker && e.Key == Key.Space)
                Handlers.HandleDatePicker(sender, e);
        }
    }
}