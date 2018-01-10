using POP_SF07_16.Utils;
using POP_SF07_16_GUI.DAL;
using POP_SF07_16_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        private Korisnik logovaniKorisnik;

        // NOVI NACIN!!!
        private ObservableCollection<Akcija> akcijaLista;
        private ObservableCollection<DodatnaUsluga> dodatnaUslugaLista;
        private ObservableCollection<Korisnik> korisnikLista;
        private ObservableCollection<KupljeniNamestaj> kupljeniNamestajLista;
        private ObservableCollection<KupljenaDodatnaUsluga> kupljenaDodatnaUslugaLista;
        private ObservableCollection<Prodaja> prodajaLista;
        private ObservableCollection<Namestaj> namestajLista;
        private ObservableCollection<TipNamestaja> tipNamestajaLista;
        private ObservableCollection<Salon> salonLista;
        private Salon salon;


        private Projekat()
        {
            //akcijaLista = GenericSerializer.Deserialize<Akcija>("akcija.xml");
            //dodatnaUslugaLista = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            //korisnikLista = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
            //prodajaLista = GenericSerializer.Deserialize<Prodaja>("prodaja.xml");
            //tipNamestajaLista = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
            //namestajLista = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            //salonLista = GenericSerializer.Deserialize<Salon>("salon.xml");
            prodajaLista = ProdajaDAO.GetList();

            akcijaLista = AkcijaDAO.GetList();
            korisnikLista = KorisnikDAO.GetList();
            tipNamestajaLista = TipNamestajaDAO.GetList();
            salonLista = SalonDAO.GetList();
            namestajLista = NamestajDAO.GetList();
            //kupljeniNamestajLista = CollectionKupljeniNamestajDAO.;
            dodatnaUslugaLista = DodatnaUslugaDAO.GetList();
        }

        public Korisnik LogovaniKorisnik
        {
            get { return logovaniKorisnik; }
            set
            {
                if (logovaniKorisnik != null)
                    logovaniKorisnik = value;
                else;
                    //Ovde smisliti sta se desava ako neko pokusa da se loguje preko vec ulogovanog, neam pojm
            }
        }
        
        public ObservableCollection<Akcija> AkcijaLista
        {
            get
            {
                akcijaLista = AkcijaDAO.GetList();
                return akcijaLista;
            }
            set
            {
                //akcijaLista = value;
                //GenericSerializer.Serialize<Akcija>("akcija.xml", akcijaLista);
            }
        }

        public ObservableCollection<DodatnaUsluga> DodatnaUslugaLista
        {
            get
            {
                dodatnaUslugaLista = DodatnaUslugaDAO.GetList();
                return dodatnaUslugaLista;
            }
            set
            {
                //dodatnaUslugaLista = value;
                //GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUslugaLista);
            }
        }

        public ObservableCollection<Korisnik> KorisnikLista
        {
            get
            {
                korisnikLista = KorisnikDAO.GetList();
                return korisnikLista;
            }
            set
            {
                //korisnikLista = value;
                //GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnikLista);
            }
        }

        public ObservableCollection<KupljeniNamestaj> KupljeniNamestajLista
        {
            get
            {
                kupljeniNamestajLista = GenericSerializer.Deserialize<KupljeniNamestaj>("kupljeniNamestaj.xml");
                return kupljeniNamestajLista;
            }
            set
            {
                kupljeniNamestajLista = value;
                GenericSerializer.Serialize<KupljeniNamestaj>("kupljeniNamestaj.xml", kupljeniNamestajLista);
            }
        }
        
        public ObservableCollection<Namestaj> NamestajLista
        {
            get
            {
                namestajLista = NamestajDAO.GetList();
                return namestajLista;
            }
            set
            {
                //namestajLista = value;
                //GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestajLista);
            }
        }
        
        public ObservableCollection<Prodaja> ProdajaLista
        {
            get
            {
                prodajaLista = ProdajaDAO.GetList();
                return prodajaLista;
            }
            set
            {
                //prodajaLista = value;
                //GenericSerializer.Serialize<Prodaja>("prodaja.xml", prodajaLista);
            }
        }

        public ObservableCollection<Salon> SalonLista
        {
            get
            {
                salonLista = SalonDAO.GetList();
                return salonLista;
            }
            set
            {
                //salonLista = value;
                //GenericSerializer.Serialize<Salon>("salon.xml", salonLista);
            }
        }
        /*
        public Salon Salon
        {
            get
            {
                salon = SalonLista[0];
                return salon;
            }
            set
            {
                salon = value;
                var lista = new ObservableCollection<Salon>();
                salonLista.Add(salon);
                SalonLista = lista;
            }
        }
        */
        public ObservableCollection<TipNamestaja> TipNamestajaLista
        {
            get
            {
                tipNamestajaLista = TipNamestajaDAO.GetList();
                return tipNamestajaLista;
            }
            set
            {
                //tipNamestajaLista = value;
                //GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestajaLista);
            }
        }
    }
}
