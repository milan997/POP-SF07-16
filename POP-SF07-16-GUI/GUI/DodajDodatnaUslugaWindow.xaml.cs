using POP_SF07_16.Model;
using POP_SF07_16_GUI.Model;
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
    /// Interaction logic for DodajDodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodajDodatnaUslugaWindow : Window
    {
        public KupljenaDodatnaUsluga original;
        public KupljenaDodatnaUsluga kopija;

        ICollectionView view;

        Operacija operacija;

        DodatnaUsluga DodatnaUsluga;
        Prodaja p;

        public DodajDodatnaUslugaWindow(Prodaja p, KupljenaDodatnaUsluga kdu, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = kdu;
            this.p = p;
            kopija = kdu.Clone() as KupljenaDodatnaUsluga;
            this.DataContext = kopija;
            this.operacija = operacija;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUslugaLista);
            dgDodatnaUsluga.ItemsSource = view;
            dgDodatnaUsluga.DataContext = DodatnaUsluga;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
            dgDodatnaUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            dgDodatnaUsluga.SelectedItem = kopija.DodatnaUsluga;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {

                kopija.Prodaja = p;
                kopija.DodatnaUsluga = dgDodatnaUsluga.SelectedItem as DodatnaUsluga;
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

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
