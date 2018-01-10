using POP_SF07_16_GUI.BLL;
using POP_SF07_16_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF07_16.Model
{
    public class Prodaja : INotifyPropertyChanged, ICloneable
    {
        private int id;

        private DateTime datumProdaje;
        private string brRacuna;
        private string kupac;

        private ObservableCollection<KupljeniNamestaj> kupljeniNamestajLista;
        private ObservableCollection<KupljenaDodatnaUsluga> kupljenaDodatnaUslugaLista;

        private double ukupnaCena;

        public const double PDV = 0.02;

        public Prodaja()
        {
            BrRacuna = "";
            DatumProdaje = DateTime.Today;
            Id = 0;
            Kupac = "";

            KupljenaDodatnaUslugaLista = new ObservableCollection<KupljenaDodatnaUsluga>();
            KupljeniNamestajLista = new ObservableCollection<KupljeniNamestaj>();
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
        
        public ObservableCollection<KupljeniNamestaj> KupljeniNamestajLista
        {
            get
            {
                return kupljeniNamestajLista;

            }
            set
            {
                kupljeniNamestajLista = value;
                OnPropertyChanged("KupljeniNamestajLista");
            }
        }

        
        public ObservableCollection<KupljenaDodatnaUsluga> KupljenaDodatnaUslugaLista
        {
            get
            {
                return kupljenaDodatnaUslugaLista;
            }
            set
            {
                kupljenaDodatnaUslugaLista = value;
                OnPropertyChanged("KupljenaDodatnaUslugaLista");
            }
        }

        public double UkupnaCena
        {
            get
            {
                ukupnaCena = IzracunajCenu();
                return ukupnaCena;
            }
            private set
            {

            }
        }


        public double IzracunajCenu()
        {
            double cena = 0;
            double jedinicnaCena = 0;
            foreach (KupljeniNamestaj kn in this.KupljeniNamestajLista)
            {
                if (kn.Obrisan == true)
                    continue;

                jedinicnaCena = kn.Namestaj.Cena;
                if (kn.Namestaj.Akcija != null)
                    jedinicnaCena -= jedinicnaCena * Convert.ToDouble(kn.Namestaj.Akcija.Popust);
                cena += jedinicnaCena * kn.Kolicina;
            }

            foreach (KupljenaDodatnaUsluga kdu in this.KupljenaDodatnaUslugaLista)
            {
                if (kdu.Obrisan == true)
                    continue;

                cena += kdu.DodatnaUsluga.Cena * kdu.Kolicina;
            }

            // Dodajemo PDV !
            cena += cena * PDV;

            return cena;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            ObservableCollection<KupljenaDodatnaUsluga> retvalKupljenaDodatnaUslugaLista = new ObservableCollection<KupljenaDodatnaUsluga>();
            foreach(KupljenaDodatnaUsluga kdu in this.KupljenaDodatnaUslugaLista)
            {
                retvalKupljenaDodatnaUslugaLista.Add(kdu.Clone() as KupljenaDodatnaUsluga);
            }
            ObservableCollection<KupljeniNamestaj> retvalKupljeniNamestaj = new ObservableCollection<KupljeniNamestaj>();
            foreach (KupljeniNamestaj kn in this.KupljeniNamestajLista)
            {
                retvalKupljeniNamestaj.Add(kn.Clone() as KupljeniNamestaj);
            }

            return new Prodaja()
            {
                BrRacuna = this.BrRacuna,
                DatumProdaje = this.DatumProdaje,
                Id = this.Id,
                Kupac = this.Kupac,

                KupljenaDodatnaUslugaLista = retvalKupljenaDodatnaUslugaLista,
                KupljeniNamestajLista = retvalKupljeniNamestaj
            };
        }
    }
}
