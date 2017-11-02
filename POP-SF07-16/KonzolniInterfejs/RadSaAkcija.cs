using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaAkcija
    {
        // POTREBNO DODATI STVARI ZA DATETIME
        private static List<Akcija> AkcijaLista = Podaci.ListaAkcija;

        public static void AkcijaMeni()
        {
          
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Akcijama ===");
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
            Console.WriteLine("=== Prikaz Akcija ===");

            for (int i = 0; i < AkcijaLista.Count; i++)
            {
                
                Console.WriteLine($"{i + 1} Popust: {AkcijaLista[i].Popust}, Obrisan {AkcijaLista[i].Obrisan}");
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Nove Akcije ===");

            Console.WriteLine("Unesite popust: ");
            decimal popust = decimal.Parse(Console.ReadLine());  

            var novaAkcija = new Akcija()
            {
                Id = AkcijaLista.Count + 1,
                Obrisan = false,
                Popust = popust
            };

            AkcijaLista.Add(novaAkcija);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Akcije ===");

            Console.WriteLine("Unesite ID akcije koju zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Akcija akcijaZaIzmenu = PoId(trazeniId);

                if (akcijaZaIzmenu != null)
                {
                    Console.WriteLine("Unesite novi popust: ");
                    akcijaZaIzmenu.Popust = decimal.Parse(Console.ReadLine());
                }
            }
        }

        private static void Obrisi()
        {
            Console.WriteLine("=== Brisanje Akcije  ===");

            Console.WriteLine("Unesite ID akcije koju zelite da obrisete, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Akcija akcija = PoId(trazeniId);
                if(akcija != null)
                {
                    akcija.Obrisan = true;
                }
            }
        }

        public static Akcija PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id akcije koji trazimo.
            // U slucaju da je akcija pronadjena, vraca objekat Akcija, a ako ne vraca null i ispisuje poruku
            Akcija nadjeno = null;
            foreach (Akcija akcija in Podaci.ListaAkcija)
            {
                if (akcija.Id == id)
                {
                    nadjeno = akcija;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJENA AKCIJA SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }
    }
}
