using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Prodaja : INotifyPropertyChanged
    {
        private int id;

        private List<int> kupljeniNamestajID;
        private DateTime datumProdaje;
        private string brRacuna;
        private string kupac;
        private List<int> dodatneUslugeID;

        public const double PDV = 0.02;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public List<int> KupljeniNamestajID
        {
            get { return kupljeniNamestajID; }
            set
            {
                kupljeniNamestajID = value;
                OnPropertyChanged("KupljeniNamestajID");
            }
        }
        
        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        
        public string BrRacuna
        {
            get { return brRacuna; }
            set
            {
                brRacuna = value;
                OnPropertyChanged("BrRacuna");
            }
        }
        
        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }
        
        public List<int> DodatneUslugeID
        {
            get { return dodatneUslugeID; }
            set
            {
                dodatneUslugeID = value;
                OnPropertyChanged("DodatneUslugeID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
