using POP_SF07_16.Model;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        private TipNamestaja tipNamestaja;

        public enum TipOperacije
        {
            DODAVANJE,
            IZMENA
        }

        private TipOperacije operacija;

        // PROSLEDJUJEMO NOVOM PROZORU TIP NAMESTAJA, ODNOSNO BILO KOJI ENTITET, KOJI ZELIMO IZMENITI
        public TipNamestajaWindow(TipNamestaja tipNamestaja, TipOperacije operacija)
        {
            InitializeComponent();

            InicijalizujPodatke(tipNamestaja);
        }

        private void InicijalizujPodatke(TipNamestaja tipNamestaja)
        {
            this.tipNamestaja = tipNamestaja;
            tbNaziv.Text = tipNamestaja.Naziv;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case TipOperacije.DODAVANJE:
                    break;
                case TipOperacije.IZMENA:
                    // OVAKOE NESTO IDE OVO : var izabraniTipNamestaja = (TipNamestaja)lbtipNamestaja.SelectedItem(); // OVAKO NESTO
                    break;
                default:
                    break;
            }
            string naziv = tbNaziv.Text;
            var listaTipNamestaja = Projekat.Instance.TipNamestajaLista;

            tipNamestaja = new TipNamestaja()
            {
                Id = listaTipNamestaja.Count() + 1,
                Naziv = naziv
            };

            listaTipNamestaja.Add(tipNamestaja);
            Projekat.Instance.TipNamestajaLista = listaTipNamestaja;
        }
    }
}
