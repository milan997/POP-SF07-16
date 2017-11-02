using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaTipNamestaja
    {
        private static List<TipNamestaja> TipNamestajaLista = Podaci.ListaTipNamestaja;

        public static void TipNamestajaMeni()
        {

            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Tipom Namestaja ===");
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
            Console.WriteLine("=== Prikaz Tipova Namestaja ===");

            for (int i = 0; i < TipNamestajaLista.Count; i++)
            {

                Console.WriteLine($"{i + 1} Popust: {TipNamestajaLista[i].Naziv}, Obrisan {TipNamestajaLista[i].Obrisan}");
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Novog Tipa Namestaja ===");

            Console.WriteLine("Unesite naziv novog tipa namestaja: ");
            string naziv = Console.ReadLine();

            var noviTipNamestaja = new TipNamestaja()
            {
                Id = TipNamestajaLista.Count + 1,
                Obrisan = false,
                Naziv = naziv
            };

            TipNamestajaLista.Add(noviTipNamestaja);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Tipa Namestaja ===");

            Console.WriteLine("Unesite ID tipa namestaja koji zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                TipNamestaja tipNamestajaZaIzmenu = PoId(trazeniId);

                if (tipNamestajaZaIzmenu != null)
                {
                    Console.WriteLine("Unesite novi naziv: ");
                    tipNamestajaZaIzmenu.Naziv = Console.ReadLine();
                }
            }
        }

        private static void Obrisi()
        {
            Console.WriteLine("=== Brisanje Tipa Namestaja  ===");

            Console.WriteLine("Unesite ID tipa namestaja koji zelite da obrisete, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                TipNamestaja tipNamestaja = PoId(trazeniId);
                if (tipNamestaja != null)
                {
                    tipNamestaja.Obrisan = true;
                }
            }
        }

        public static TipNamestaja PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id tipa namestaja koji trazimo.
            // U slucaju da je tip namestaja pronadjen, vraca objekat TipNamestaja, a ako ne vraca null i ispisuje poruku
            TipNamestaja nadjeno = null;
            foreach (TipNamestaja tipNamestaja in Podaci.ListaTipNamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    nadjeno = tipNamestaja;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJEN TIP NAMESTAJA SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }
    }
}

