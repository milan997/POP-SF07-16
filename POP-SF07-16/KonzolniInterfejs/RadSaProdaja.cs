using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaProdaja
    {
        // DODATI LOGIKU ZA DATETIME!!!
        
        private static List<Prodaja> ProdajaLista = Podaci.ListaProdaja;

        public static void ProdajaMeni()
        {
           
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Prodajama ===");
                    Extra.CRUDMeni(); // CRUD - Create, Read, Update, Delete
                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        Prikazi();
                        break;
                    case 2:
                        Dodaj();
                        break;
                    case 3:
                        Izmeni();
                        break;
                    case 4:
                        Obrisi();
                        break;
                    default:
                        break;
                }
            } while (izbor != 0);

        }
        
        private static void Prikazi()
        {
            Console.WriteLine("=== Prikaz Prodaja ===");

            for (int i = 0; i < ProdajaLista.Count; i++)
            {
                
                Console.WriteLine($"{i + 1} Lista Namestaja: {ProdajaLista[i].KupljeniNamestaj}, Datum: {ProdajaLista[i].DatumProdaje}, " +
                    $"Broj Racuna: {ProdajaLista[i].BrojRacuna}, Kupac: {ProdajaLista[i].Kupac}, Dodatne Usluge: {ProdajaLista[i].DodatneUsluge}" +
                    $", Ukupna Cena: {ProdajaLista[i].UkupnaCena}");
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Nove Prodaje ===");

            List<KupljeniNamestaj> kupljeniNamestaj = KupovinaNamestaja();
            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            // VREME VREME VREME
            // VREME VREME VREME

            Console.WriteLine("Unesite broj racuna: ");
            string brojRacuna = Console.ReadLine();

            Console.WriteLine("Unesite ime kupca: ");
            string kupac = Console.ReadLine();

            List<DodatnaUsluga> dodatneUsluge = DodavanjeDodatnihUsluga();

            var novaProdaja = new Prodaja()
            {
                Id = ProdajaLista.Count + 1,

                KupljeniNamestaj = kupljeniNamestaj,
                // VREME VREME
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                DodatneUsluge = dodatneUsluge,
            };

            ProdajaLista.Add(novaProdaja);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Prodaje ===");

            Console.WriteLine("Unesite ID prodaje koju zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Prodaja prodajaZaIzmenu = PoId(trazeniId);
                
                if (prodajaZaIzmenu != null)
                {
                    Console.WriteLine("Unesite nove kupljene namestaje prodaje: ");
                    prodajaZaIzmenu.KupljeniNamestaj = KupovinaNamestaja();

                    // VREME VREME
                    // DATUM DATUM

                    Console.WriteLine("Unesite novi broj racuna: ");
                    prodajaZaIzmenu.BrojRacuna = Console.ReadLine();

                    Console.WriteLine("Unesite kupca: ");
                    prodajaZaIzmenu.Kupac = Console.ReadLine();

                    Console.WriteLine("Unesite dodatne usluge: ");
                    prodajaZaIzmenu.DodatneUsluge = DodavanjeDodatnihUsluga();
                }

            }



        }

        private static void Obrisi()
        {
            Console.WriteLine("\nBRISANJE PRODAJA JE ONEMOGUCENO!!!\n");
        }

        private static List<KupljeniNamestaj> KupovinaNamestaja()
        {
            List<KupljeniNamestaj> kupljeniNamestaj = new List<KupljeniNamestaj>();
            while (true)
            {
                Console.WriteLine("Unesite ID namestaja koji kupujete: ");
                int idNamestaja = int.Parse(Console.ReadLine());
                Namestaj namestaj = RadSaNamestaj.PoId(idNamestaja);

                if(idNamestaja == 0 || namestaj == null) { break; }

                Console.WriteLine("Unesite kolicinu: ");
                int kolicina = int.Parse(Console.ReadLine());

                if (kolicina != 0)
                {
                    KupljeniNamestaj kupljeni = new KupljeniNamestaj()
                    {
                        Namestaj = namestaj,
                        Kolicina = kolicina
                    };

                    kupljeniNamestaj.Add(kupljeni);
                }

            }
            return kupljeniNamestaj;

        }

        private static List<DodatnaUsluga> DodavanjeDodatnihUsluga()
        {
            List<DodatnaUsluga> dodatneUsluge = new List<DodatnaUsluga>();
            while (true)
            {
                Console.WriteLine("Unesite ID dodatnih usluga koje prodaja ima: ");
                int id = int.Parse(Console.ReadLine());
                DodatnaUsluga dodatnaUsluga = RadSaDodatnaUsluga.PoId(id);

                if (id == 0 || dodatnaUsluga == null) { break; }
                dodatneUsluge.Add(dodatnaUsluga);

            }
            return dodatneUsluge;
        }

        public static Prodaja PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id prodaje koju trazimo.
            // U slucaju da je prodaja pronadjena, vraca objekat Prodaja, a ako ne vraca null i ispisuje poruku
            Prodaja nadjeno = null;
            foreach (Prodaja prodaja in Podaci.ListaProdaja)
            {
                if (prodaja.Id == id)
                {
                    nadjeno = prodaja;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJENA PRODAJA SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }


    }
}
