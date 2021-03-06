﻿using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.Utils;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        Akcija original;
        Akcija kopija;
        
        Operacija operacija;
        
        public AkcijaWindow(Akcija a, Operacija operacija = Operacija.DODAVANJE)
        {
            InitializeComponent();

            
            original = a;
            kopija = a.Clone() as Akcija;
            this.DataContext = kopija;
            this.operacija = operacija;

            if(operacija == Operacija.POGLED)
            {
                dpDatumPocetka.IsEnabled = false;
                dpDatumZavrsetka.IsEnabled = false;
                tbNaziv.IsReadOnly = true;
                tbPopust.IsReadOnly = true;
                btPotvrdi.Visibility = Visibility.Collapsed;
                btOtkazi.Visibility = Visibility.Collapsed;
            }
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Da li zelite da sacuvate izmene?", "???", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                if(operacija == Operacija.DODAVANJE) // Ako dodajemo objekat
                {
                    AkcijaDAO.Add(kopija);
                }
                else if (operacija == Operacija.IZMENA) // Ako menjamo objekat, akciju
                {
                    original.Id = kopija.Id;
                    original.DatumPocetka = kopija.DatumPocetka;
                    original.DatumZavrsetka = kopija.DatumZavrsetka;
                    original.Naziv = kopija.Naziv;
                    original.Popust = kopija.Popust;
                    original.Obrisan = kopija.Obrisan;

                    AkcijaDAO.Update(kopija);
                }
                this.Close();
            }
            else if (mbr == MessageBoxResult.No)
            {
                if (operacija == Operacija.IZMENA)
                {
                    var lista = AkcijaDAO.GetList();
                    lista[original.Id] = kopija;
                }
                
            }
        }

        private void btOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }








        private void Handle(object sender, KeyEventArgs e)
        {
            //Funkcija za 'hendlanje evenata', poziva se za sve 'hendlove'
            if (e.Key == Key.Escape)
                Handlers.HandleEsc(sender, e);
            if (sender is DatePicker && e.Key == Key.Space)
                Handlers.HandleDatePicker(sender, e);
        }
        
    }
}