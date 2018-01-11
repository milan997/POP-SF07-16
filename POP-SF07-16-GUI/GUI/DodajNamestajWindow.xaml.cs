using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DodajNamestajWindow.xaml
    /// </summary>
    public partial class DodajNamestajWindow : Window
    {
        public KupljeniNamestaj original;
        public KupljeniNamestaj kopija;

        ICollectionView view;

        Operacija operacija;

        Namestaj Namestaj;
        Prodaja p;


        public DodajNamestajWindow(Prodaja p, KupljeniNamestaj kn, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = kn;
            this.p = p;
            kopija = kn.Clone() as KupljeniNamestaj;
            this.DataContext = kopija;
            this.operacija = operacija;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
            dgNamestaj.ItemsSource = view;
            dgNamestaj.DataContext = Namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgNamestaj.SelectedItem = kopija.Namestaj;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {

                kopija.Prodaja = p;
                kopija.Namestaj = dgNamestaj.SelectedItem as Namestaj;
                this.DialogResult = true;
            }
            else if (mbr == MessageBoxResult.No)
            {
                this.DialogResult = false;
            }
            /*
            this.DialogResult = true;
            this.Close();
            */
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            if (header == "Id" || header == "Obrisan" || header == "KupljeniNamestajLista" || header == "KupljenaDodatnaUslugaLista") //Navodimo ime kolone koju ne zelimo da prikazemo
                e.Cancel = true;
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
