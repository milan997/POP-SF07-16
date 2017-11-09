using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class Podaci
    {
        public static List<Namestaj> ListaNamestaj = new List<Namestaj>();
        public static List<TipNamestaja> ListaTipNamestaja = new List<TipNamestaja>();
        public static Salon salon = new Salon();
        public static List<Korisnik> ListaKorisnik= new List<Korisnik>();
        public static List<Prodaja> ListaProdaja = new List<Prodaja>();
        public static List<DodatnaUsluga> ListaDodatnaUsluga = new List<DodatnaUsluga>();
        public static List<Akcija> ListaAkcija = new List<Akcija>();

        public static void UcitajPodatke()
        {
            /// Ovde stavljamo sve objekte koje zelimo da inicijalizujemo pre pocetka aplikacije
            /// 

            Salon s1 = new Salon()
            {
                Id = 1,
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-000171666-45",
                Email = "dekan@ftn.uns.ac.rs",
                MaticniBroj = "352343",
                Naziv = "Forma FTNale",
                PIB = "123123",
                Telefon = "021/454-58578",
                WebAdresa = "http://www.ftn.uns.ac.rs"
            };

            var tp1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Krevet",

            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Cena = 777,
                TipNamestaja = tp1,
                Naziv = "Ekstra Krevet",
                KolicinaUMagacinu = 100,
                Sifra = "KR123333"
            };

            ListaNamestaj.Add(n1);
            ListaTipNamestaja.Add(tp1);

            Console.WriteLine("Podaci ucitani!!!");
        }
        /*
        public static List<Object> VratiListu(string entitet)
        {
            string en = entitet.ToLower().Trim();
            if (en == "namestaj")
            {
                return (List<Object>) ListaNamestaj;
            }
        }
        */
    }
}
