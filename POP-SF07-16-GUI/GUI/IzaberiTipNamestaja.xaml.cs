using POP_SF07_16.Model;
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
    /// Interaction logic for IzaberiTipNamestaja.xaml
    /// </summary>
    public partial class IzaberiTipNamestaja : Window
    {
        ICollectionView view;

        public TipNamestaja IzabranTipNamestaja;

        public IzaberiTipNamestaja()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipNamestajaLista);
            dgTipNamestaja.ItemsSource = view;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            IzabranTipNamestaja = dgTipNamestaja.SelectedItem as TipNamestaja;
            this.DialogResult = true;
            this.Close();
        }

        private void AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            if (header == "Id" || header == "Obrisan") //Navodimo ime kolone koju ne zelimo da prikazemo
                e.Cancel = true;
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
