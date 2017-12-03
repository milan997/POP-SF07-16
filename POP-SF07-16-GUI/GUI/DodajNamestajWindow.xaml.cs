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

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for DodajNamestajWindow.xaml
    /// </summary>
    public partial class DodajNamestajWindow : Window
    {
        ICollectionView view;
        Namestaj IzabraniNamestaj;
        public KupljeniNamestaj KupljeniNamestaj = new KupljeniNamestaj();


        public DodajNamestajWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.NamestajLista);
            dgNamestaj.ItemsSource = view;
            dgNamestaj.DataContext = KupljeniNamestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
