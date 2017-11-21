using POP_SF07_16.Model;
using POP_SF07_16.Utils;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF07_16_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var pw = new KorisnikWindow();
            pw.ShowDialog();
            //InitializeComponent();

            //OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbTipNamestaja.Items.Clear();

            foreach (var tipNamestaja in Projekat.Instance.TipNamestajaLista)
            {
                lbTipNamestaja.Items.Add(tipNamestaja);
            }

            //lbNamestaj.; POSTAVI NA NAJGORNJI ITEM DA JE SELEKTOVANO
            // pastebin.com/u50U4AeE
        }

        private void btnDodajTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            //var window = new TipNamestajaWindow();
            //window.ShowDialog();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
