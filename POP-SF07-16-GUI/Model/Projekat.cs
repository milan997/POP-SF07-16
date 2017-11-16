using POP_SF07_16.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public Korisnik LogovaniKorisnik { get; set; }

        private List<Akcija> akcijaLista;
        private List<DodatnaUsluga> dodatnaUslugaLista;
        private List<Korisnik> korisnikLista;
        private List<KupljeniNamestaj> kupljeniNamestajLista;
        private List<Namestaj> namestajLista;
        private List<Prodaja> prodajaLista;
        private Salon salon;
        private List<TipNamestaja> tipNamestajaLista;
        //private Projekat() { } --- Ne znam treba li ovo, eto ga

        public List<Akcija> AkcijaLista
        {
            get
            {
                akcijaLista = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return akcijaLista;
            }
            set
            {
                akcijaLista = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcijaLista);
            }
        }

        public List<DodatnaUsluga> DodatnaUslugaLista
        {
            get
            {
                dodatnaUslugaLista = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
                return dodatnaUslugaLista;
            }
            set
            {
                dodatnaUslugaLista = value;
                GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", dodatnaUslugaLista);
            }
        }

        public List<Korisnik> KorisnikLista
        {
            get
            {
                korisnikLista = GenericSerializer.Deserialize<Korisnik>("korisnik.xml");
                return korisnikLista;
            }
            set
            {
                korisnikLista = value;
                GenericSerializer.Serialize<Korisnik>("korisnik.xml", korisnikLista);
            }
        }

        public List<KupljeniNamestaj> KupljeniNamestajLista
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

        public List<Namestaj> NamestajLista
        {
            get
            {
                namestajLista = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestajLista;
            }
            set
            {
                namestajLista = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestajLista);
            }
        }

        public List<Prodaja> ProdajaLista
        {
            get
            {
                ProdajaLista = GenericSerializer.Deserialize<Prodaja>("prodaja.xml");
                return ProdajaLista;
            }
            set
            {
                ProdajaLista = value;
                GenericSerializer.Serialize<Prodaja>("prodaja.xml", ProdajaLista);
            }
        }

        public Salon Salon
        {
            get
            {
                salon = GenericSerializer.Deserialize<Salon>("akcija.xml")[0];
                return salon;
            }
            set
            {
                salon = value;
                GenericSerializer.Serialize<Salon>("akcija.xml", new List<Salon> { salon });
            }
        }

        public List<TipNamestaja> TipNamestajaLista
        {
            get
            {
                tipNamestajaLista = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
                return tipNamestajaLista;
            }
            set 
            {
                tipNamestajaLista = value;
                GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestajaLista);
            }
        }
    }
}
