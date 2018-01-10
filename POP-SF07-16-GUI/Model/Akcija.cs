using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;

        private String naziv;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private decimal popust;

        public Akcija()
        {
            Id = 0;
            naziv = "noName";
            Obrisan = false;
            DatumPocetka = DateTime.Today;
            DatumZavrsetka = DateTime.Today;
            Popust = 0;
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

        public String Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        
        public DateTime DatumPocetka
        {
            get { return datumPocetka.Date; }
            set
            {
                datumPocetka = value.Date;
                OnPropertyChanged("DatumPocetka");
            }
        }
        
        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka.Date; }
            set
            {
                datumZavrsetka = value.Date;
                OnPropertyChanged("DatumZavrsetka");
            }
        }
        
        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
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

        public override string ToString()
        {
            return $"{Naziv} Popust {Popust}%";
        }

        public object Clone()
        {
            return new Akcija()
            {
                Id = this.Id,
                Naziv = this.Naziv,
                DatumPocetka = this.DatumPocetka,
                DatumZavrsetka = this.DatumZavrsetka,
                Popust = this.Popust,
                Obrisan = this.Obrisan
            };
        }
    }
}
