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

        public Korisnik logovaniKorisnik { get; set; }

        private List<TipNamestaja> tipNamestajaLista;
        private List<Namestaj> namestajLista;
        private List<Korisnik> korisnikLista;
        //private Projekat() { }

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
        
        /*
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
        */


    }
}
