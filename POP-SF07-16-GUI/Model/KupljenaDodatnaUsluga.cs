using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.Model
{
    public class KupljenaDodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        private Prodaja prodaja;
        private DodatnaUsluga dodatnaUsluga;
        private int kolicina;
        private bool obrisan;


        public KupljenaDodatnaUsluga()
        {
            Prodaja = null;
            DodatnaUsluga = null;
            Kolicina = 0;
            Obrisan = false;
        }


        public Prodaja Prodaja
        {
            get { return prodaja; }
            set
            {
                prodaja = value;
                OnPropertyChanged("Prodaja");
            }
        }

        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
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
            return new KupljenaDodatnaUsluga()
            {
                Prodaja = this.Prodaja,
                Kolicina = this.Kolicina,
                DodatnaUsluga = this.DodatnaUsluga,
                Obrisan = this.Obrisan
            };
        }

    }
}
