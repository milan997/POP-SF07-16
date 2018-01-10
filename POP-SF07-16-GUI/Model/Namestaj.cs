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
      
        private TipNamestaja tipNamestaja;
        private Akcija akcija;

        public Namestaj()
        {
            Id = 0;
            Obrisan = false;

            Naziv = "";
            Sifra = "";
            Cena = 999999.99999;
            KolicinaUMagacinu = 0;

            TipNamestaja = null;
            Akcija = null;
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
                Id = this.Id,
                Obrisan = this.Obrisan,

                Naziv = this.Naziv,
                Sifra = this.Sifra,
                Cena = this.Cena,
                KolicinaUMagacinu = this.KolicinaUMagacinu,

                TipNamestaja = this.TipNamestaja,
                Akcija = this.Akcija
            };
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }

    }

}
