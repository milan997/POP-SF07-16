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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        Akcija akcija = null;

        public AkcijaWindow()
        {
            //Konstruktor bez parametara, poziva se prilikom dodavanja akcije
            InitializeComponent();
            dpDatumPocetka.SelectedDate = DateTime.Now;
            dpDatumZavrsetka.SelectedDate = DateTime.Now;
        }

        public AkcijaWindow(Akcija a)
        {
            //Konstruktor kome prosledjuemo akciju koju zelimo da izmenimo
            akcija = a;
            InitializeComponent();
            dpDatumPocetka.SelectedDate = akcija.DatumPocetka;
            dpDatumZavrsetka.SelectedDate = akcija.DatumZavrsetka;
            tbPopust.Text = (akcija.Popust).ToString();
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if(dpDatumPocetka.SelectedDate == null || dpDatumZavrsetka.SelectedDate == null || tbPopust.Text == "")
            {
                MessageBox.Show("Niste uneli sve podatke!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (dpDatumZavrsetka.SelectedDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Ne mozete izabrati datum koji je prosao!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (dpDatumPocetka.SelectedDate >= dpDatumZavrsetka.SelectedDate )
            {
                MessageBox.Show("Akcija se zavrsava pre nego sto pocinje?!?!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (!Decimal.TryParse(tbPopust.Text.Trim(), out decimal popust))
            {
                MessageBox.Show("Napravili ste gresku prilikom unosa popusta!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (popust < 0 || popust > 100)
            {
                MessageBox.Show("Popust mora biti izmedju 0 i 100!", "!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            } else if (akcija != null && dpDatumPocetka.SelectedDate == akcija.DatumPocetka 
                && dpDatumZavrsetka.SelectedDate == akcija.DatumZavrsetka && popust == akcija.Popust)
            {
                MessageBox.Show("Niste izvrsili nijednu izmenu", "!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            else if(MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                if(akcija == null)
                {
                    //DODAVANJE 
                    akcija = new Akcija();
                    akcija.DatumPocetka = (DateTime) dpDatumPocetka.SelectedDate.Value;
                    akcija.DatumZavrsetka = (DateTime) dpDatumZavrsetka.SelectedDate.Value;
                    akcija.Popust = popust;
                    AkcijaDAL.Add(akcija);
                } else if (akcija != null)
                {
                    //IZMENA
                    akcija.DatumPocetka = (DateTime) dpDatumPocetka.SelectedDate.Value;
                    akcija.DatumZavrsetka = (DateTime) dpDatumZavrsetka.SelectedDate.Value;
                    akcija.Popust = popust;
                    AkcijaDAL.Update(akcija);
                }
                this.Close();
            } 
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Izmene nece biti sacuvane, da li ste sigurni?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation)
                == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
