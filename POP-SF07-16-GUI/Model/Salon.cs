using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Salon : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;

        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string webAdresa;
        private string pib;
        private string maticniBroj;
        private string brRacuna;

        public Salon()
        {
            Adresa = "";
            BrRacuna = "";
            Email = "";
            Id = 0;
            MaticniBroj = "";
            Naziv = "";
            Obrisan = false;
            Pib = "";
            Telefon = "";
            WebAdresa = "";
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
        
        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        
        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        
        public string WebAdresa
        {
            get { return webAdresa; }
            set
            {
                webAdresa = value;
                OnPropertyChanged("WebAdresa");
            }
        }
        
        public string Pib
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }
        
        public string MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
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
            return new Salon()
            {
                adresa = this.Adresa,
                brRacuna = this.BrRacuna,
                email = this.Email,
                id = this.Id,
                maticniBroj = this.MaticniBroj,
                naziv = this.Naziv,
                obrisan = this.Obrisan,
                pib = this.Pib,
                telefon = this.Telefon,
                webAdresa = this.WebAdresa
            };
        }

    }
}
