using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaDodatnaUsluga
    {
        private static List<DodatnaUsluga> DodatnaUslugaLista = Podaci.ListaDodatnaUsluga;
        
        public static void DodatnaUslugaMeni()
        {
            //NamestajLista = Podaci.ListaNamestaj;
            //TipNamestajaLista = Podaci.ListaTipNamestaja;

            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Dodatnom Uslugom ===");
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
            Console.WriteLine("=== Prikaz Dodatnih Usluga ===");

            for (int i = 0; i < DodatnaUslugaLista.Count; i++)
            {
                Console.WriteLine($"{i + 1} Naziv: {DodatnaUslugaLista[i].Naziv}, Cena: {DodatnaUslugaLista[i].Cena}, Obrisana: {DodatnaUslugaLista[i].Obrisana}");
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Nove Dodatne Usluge ===");

            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());

            var novaDodatnaUsluga = new DodatnaUsluga()
            {
                Id = DodatnaUslugaLista.Count + 1,
                Obrisana = false,

                Naziv = naziv,
                Cena = cena
            };

            DodatnaUslugaLista.Add(novaDodatnaUsluga);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Dodatne Usluge ===");

            Console.WriteLine("Unesite ID dodatne usluge koju zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                DodatnaUsluga dodatnaUslugaZaIzmenu = PoId(trazeniId);

                if (dodatnaUslugaZaIzmenu != null)
                {
                    Console.WriteLine("Unesite novi naziv dodatne usluge: ");
                    dodatnaUslugaZaIzmenu.Naziv = Console.ReadLine();

                    Console.WriteLine("Unesite novu cenu namestaja: ");
                    dodatnaUslugaZaIzmenu.Cena = double.Parse(Console.ReadLine());
                }
            }
        }

        private static void Obrisi()
        {
            Console.WriteLine("=== Brisanje Dodatnih Usluga ===");

            Console.WriteLine("Unesite ID dodatne usluge koju zelite da obrisete, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                DodatnaUsluga dodatnaUsluga = PoId(trazeniId);
                if(dodatnaUsluga != null)
                {
                    dodatnaUsluga.Obrisana = true;
                }
            }
        }

        public  static DodatnaUsluga PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id dodatne usluge koju trazimo.
            // U slucaju da je dodatna usluga pronadjena, vraca objekat DodatnaUsluga, a ako ne vraca null i ispisuje poruku
            DodatnaUsluga nadjeno = null;
            foreach (DodatnaUsluga dodatnaUsluga in Podaci.ListaDodatnaUsluga)
            {
                if (dodatnaUsluga.Id == id)
                {
                    nadjeno = dodatnaUsluga;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJENA DODATNA USLUGA SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }
    }
}
