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
using static POP_SF07_16_GUI.Utils.Enum;

namespace POP_SF07_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        DodatnaUsluga original;
        DodatnaUsluga kopija;

        Operacija operacija;
        
        public DodatnaUslugaWindow(DodatnaUsluga du, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            original = du;
            kopija = du.Clone() as DodatnaUsluga;
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
                    DodatnaUslugaDAO.Add(kopija);

                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.Cena = kopija.Cena;
                    original.Obrisan = kopija.Obrisan;
                    original.Naziv = kopija.Naziv;

                    DodatnaUslugaDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = DodatnaUslugaDAO.GetList();
                    lista[original.Id] = kopija;
                }

            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        
        private void Handle(object sender, KeyEventArgs e)
        {
            //Funkcija za 'hendlanje evenata', poziva se za sve 'hendlove'
            if (e.Key == Key.Escape)
                Handlers.HandleEsc(sender, e);
        }
        
    }
}
