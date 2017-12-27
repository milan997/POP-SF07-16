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
    public class KupljeniNamestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;

        private int namestajID;
        private int kolicina;

        private Namestaj namestaj;

        public KupljeniNamestaj()
        {
            Id = 0;
            NamestajID = 0;
            Kolicina = 0;
            Namestaj = null;
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
        
        public int NamestajID
        {
            get { return namestajID; }
            set
            {
                namestajID = value;
                OnPropertyChanged("NamestajID");
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

        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                    return NamestajDAO.GetById(namestajID);
                else
                    return namestaj;
            }
            set
            {
                namestaj = value;
                NamestajID = namestaj != null ? namestaj.Id : 0;
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
                id = this.Id,
                kolicina = this.Kolicina,
                namestaj = this.Namestaj,
                namestajID = this.NamestajID
            };
        }

    }
}
