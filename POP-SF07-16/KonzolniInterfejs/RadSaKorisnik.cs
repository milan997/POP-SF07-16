using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaKorisnik
    {

        // DODATI LOGIKU ZA IZMENU I DODAVANJE TIPA KORISNIKA, ENUMERACIJA

        private static List<Korisnik> KorisnikLista = Podaci.ListaKorisnik;

        public static void KorisnikMeni()
        {
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Korisnicima ===");
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
            Console.WriteLine("=== Prikaz Korisnika ===");

            for (int i = 0; i < KorisnikLista.Count; i++)
            {
                Console.WriteLine($"{i + 1} Ime: {KorisnikLista[i].Ime}, Prezime: {KorisnikLista[i].Prezime}, " +
                    $" Korisnicko Ime: {KorisnikLista[i].KorIme}, Lozinka: {KorisnikLista[i].Lozinka}" +
                    $", Tip Korisnika: {KorisnikLista[i].TipKorisnika}, Obrisan: {KorisnikLista[i].Obrisan}");
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Novog Korisnika ===");

            Console.WriteLine("Unesite ime: ");
            string ime = Console.ReadLine();

            Console.WriteLine("Unesite prezime: ");
            string prezime = Console.ReadLine();

            Console.WriteLine("Unesite korisnicko ime: ");
            string korIme = Console.ReadLine();

            Console.WriteLine("Unesite lozinku: ");
            string lozinka = Console.ReadLine();

            var noviKorisnik = new Korisnik()
            {
                Id = KorisnikLista.Count + 1,
                Obrisan = false,

                Ime = ime,
                Prezime = prezime,
                KorIme = korIme,
                Lozinka = lozinka,
                TipKorisnika = TipKorisnika.Administrator
            };

            KorisnikLista.Add(noviKorisnik);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Korisnika ===");

            Console.WriteLine("Unesite ID korisnika koji zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Korisnik korisnikZaIzmenu = PoId(trazeniId);

                if (korisnikZaIzmenu != null)
                {
                    Console.WriteLine("Unesite novo ime: ");
                    korisnikZaIzmenu.Ime = Console.ReadLine();

                    Console.WriteLine("Unesite novo prezime: ");
                    korisnikZaIzmenu.Prezime = Console.ReadLine();

                    Console.WriteLine("Unesite novo korisnicko ime: ");
                    korisnikZaIzmenu.KorIme = Console.ReadLine();

                    Console.WriteLine("Unesite novu lozinku: ");
                    korisnikZaIzmenu.Lozinka = Console.ReadLine();
                }
                
            }



        }

        private static void Obrisi()
        {
            Console.WriteLine("=== Brisanje Korisnika ===");

            Console.WriteLine("Unesite ID korisnika koji zelite da obrisete, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Korisnik korisnikZaBrisati = PoId(trazeniId);
                if(korisnikZaBrisati != null)
                {
                    korisnikZaBrisati.Obrisan = true;
                }
            }
        }

        private static Korisnik PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id korisnika koji trazimo.
            // U slucaju da je korisnik pronadjen, vraca objekat Korisnik, a ako ne vraca null i ispisuje poruku
            Korisnik nadjeno = null;
            foreach (Korisnik korisnik in Podaci.ListaKorisnik)
            {
                if (korisnik.Id == id)
                {
                    nadjeno = korisnik;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJEN KORISNIK SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }
    }
}
