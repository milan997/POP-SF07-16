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
using static POP_SF07_16_GUI.Utils.Enum;

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        TipNamestaja original;
        TipNamestaja kopija;

        Operacija operacija;

        public TipNamestajaWindow(TipNamestaja tn, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = tn;
            kopija = tn.Clone() as TipNamestaja;
            this.DataContext = kopija;
            this.operacija = operacija;
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if (operacija == Operacija.DODAVANJE) // Ako dodajemo objekat
                {
                    TipNamestajaDAL.Add(kopija);

                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.Naziv = kopija.Naziv;
                    original.Obrisan = kopija.Obrisan;

                    TipNamestajaDAL.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = TipNamestajaDAL.GetList();
                    lista[original.Id] = kopija;
                }

            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
