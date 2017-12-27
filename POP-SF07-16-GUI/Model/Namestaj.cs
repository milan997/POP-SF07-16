using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF07_16.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;

        private string naziv;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        /*
        private int tipNamestajaID;
        private int akcijaID;
        */
        private TipNamestaja tipNamestaja;
        private Akcija akcija;

        public Namestaj()
        {
            Akcija = null;
            //AkcijaID = 0;
            Cena = 0;
            Id = 0;
            KolicinaUMagacinu = 0;
            Naziv = "";
            Obrisan = false;
            Sifra = "";
            TipNamestaja = null;
            //TipNamestajaID = 0;
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

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }
        /*
        public int TipNamestajaID
        {
            get { return tipNamestajaID; }
            set
            {
                tipNamestajaID = value;
                OnPropertyChanged("TipNamestajaID");
            }
        }
        
        public int AkcijaID
        {
            get { return akcijaID; }
            set
            {
                akcijaID = value;
                OnPropertyChanged("AkcijaID");
            }
        }
        */
        
        public TipNamestaja TipNamestaja
        {
            get
            {
               return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public Akcija Akcija
        {
            get
            {
                return akcija;
            }
            set
            {
                akcija = value;
                OnPropertyChanged("Akcija");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Namestaj()
            {
                akcija = this.Akcija,
                //akcijaID = this.AkcijaID,
                cena = this.Cena,
                id = this.Id,
                kolicinaUMagacinu = this.KolicinaUMagacinu,
                naziv = this.Naziv,
                obrisan = this.Obrisan,
                sifra = this.Sifra,
                tipNamestaja = this.TipNamestaja,
                //tipNamestajaID = this.TipNamestajaID,
            };
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }

    }

}
