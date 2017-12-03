using POP_SF07_16_GUI.BLL;
using System;
using System.Collections.Generic;
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

        private List<int> kupljeniNamestajID;
        private DateTime datumProdaje;
        private string brRacuna;
        private string kupac;
        private List<int> dodatnaUslugaID;

        private List<KupljeniNamestaj> kupljeniNamestajLista;
        private List<DodatnaUsluga> dodatnaUslugaLista;

        public const double PDV = 0.02;

        public Prodaja()
        {
            BrRacuna = "";
            DatumProdaje = DateTime.Today;
            DodatnaUslugaID = new List<int>();
            Id = 0;
            Kupac = "";
            KupljeniNamestajID = new List<int>();
            DodatnaUslugaLista = new List<DodatnaUsluga>();
            KupljeniNamestajLista = new List<KupljeniNamestaj>();
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
        
        public List<int> DodatnaUslugaID
        {
            get { return dodatnaUslugaID; }
            set
            {
                dodatnaUslugaID = value;
                OnPropertyChanged("DodatneUslugeID");
            }
        }

        [XmlIgnore]
        public List<KupljeniNamestaj> KupljeniNamestajLista
        {
            get
            {
                if (kupljeniNamestajLista == null)
                    return KupljeniNamestajBLL.ListIntToListNamestaj(kupljeniNamestajID);
                else
                    return kupljeniNamestajLista;

            }
            set
            {
                kupljeniNamestajLista = value;
                KupljeniNamestajID = KupljeniNamestajBLL.ListNamestajToListInt(kupljeniNamestajLista);
            }
        }

        [XmlIgnore]
        public List<DodatnaUsluga> DodatnaUslugaLista
        {
            get
            {
                if (dodatnaUslugaLista == null)
                    return DodatnaUslugaBLL.ListIntToListDodatnaUsluga(kupljeniNamestajID);
                else
                    return dodatnaUslugaLista;
            }
            set
            {
                dodatnaUslugaLista = value;
                dodatnaUslugaID = DodatnaUslugaBLL.ListDodatnaUslugaToListInt(dodatnaUslugaLista);
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
            return new Prodaja()
            {
                brRacuna = this.BrRacuna,
                datumProdaje = this.DatumProdaje,
                dodatnaUslugaID = this.dodatnaUslugaID,
                id = this.Id,
                kupac = this.Kupac,
                kupljeniNamestajID = this.KupljeniNamestajID,
                dodatnaUslugaLista = this.DodatnaUslugaLista,
                kupljeniNamestajLista = this.KupljeniNamestajLista
            };
        }
    }
}
