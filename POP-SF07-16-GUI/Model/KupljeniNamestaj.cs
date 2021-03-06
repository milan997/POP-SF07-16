﻿using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF07_16.Model
{
    public class KupljeniNamestaj : INotifyPropertyChanged, ICloneable
    {
        private Prodaja prodaja;
        private Namestaj namestaj;
        private int kolicina;
        private bool obrisan;

        public KupljeniNamestaj()
        {
            Prodaja = null;
            Namestaj = null;
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
        
        public Namestaj Namestaj
        {
            get { return namestaj; }
            set
            {
                namestaj = value;
                OnPropertyChanged("Namestaj");
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
            return new KupljeniNamestaj()
            {
                Prodaja = this.Prodaja,
                Kolicina = this.Kolicina,
                Namestaj = this.Namestaj,
                Obrisan = this.Obrisan
            };
        }

    }
}
