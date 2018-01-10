using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public enum TipKorisnika
    {
        Administrator = 1,
        Prodavac = 0
    }

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;

        private string ime;
        private string prezime;
        private string korIme;
        private string lozinka;

        private TipKorisnika tipKorisnika;
        
        public Korisnik()
        {
            Id = 0;
            Ime = "";
            Prezime = "";
            KorIme = "";
            Lozinka = "";
            Obrisan = false;
            TipKorisnika = TipKorisnika.Prodavac;
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
        
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        
        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        
        public string KorIme
        {
            get { return korIme; }
            set
            {
                korIme = value;
                OnPropertyChanged("KorIme");
            }
        }
        
        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        
        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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
            return new Korisnik()
            {
                Id = this.Id,
                Ime = this.Ime,
                Prezime = this.Prezime,
                KorIme = this.KorIme,
                Lozinka = this.Lozinka,
                Obrisan = this.Obrisan,
                TipKorisnika = this.TipKorisnika
            };
        }

    }
}
