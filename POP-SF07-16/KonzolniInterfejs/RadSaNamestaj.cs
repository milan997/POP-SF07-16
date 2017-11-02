using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaNamestaj
    {

        private static List<Namestaj> NamestajLista = Podaci.ListaNamestaj;
        private static List<TipNamestaja> TipNamestajaLista = Podaci.ListaTipNamestaja;
        private static List<Akcija> AkcijaLista = Podaci.ListaAkcija;

        public static void NamestajMeni()
        {
            //NamestajLista = Podaci.ListaNamestaj;
            //TipNamestajaLista = Podaci.ListaTipNamestaja;

            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("=== Rad Sa Namestajem ===");
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
            Console.WriteLine("=== Prikaz Namestaja ===");

            for (int i = 0; i < NamestajLista.Count; i++)
            {
                string upisAkcija = "Nema";
                if(NamestajLista[i].Akcija != null)
                {
                    upisAkcija = NamestajLista[i].Akcija.Popust.ToString();
                }

                string upisTipNamestaja = "Nedodeljen";
                if (NamestajLista[i].TipNamestaja != null)
                {
                    upisTipNamestaja = NamestajLista[i].TipNamestaja.Naziv;
                }

                Console.WriteLine($"{i + 1} Naziv: {NamestajLista[i].Naziv}, Sifra {NamestajLista[i].Sifra}, Cena: {NamestajLista[i].Cena}, " +
                    $"Kolicina U Magacinu: {NamestajLista[i].KolicinaUMagacinu}, Tip Namestaja: {upisTipNamestaja}, Akcija: {upisAkcija}" +
                    $", Obrisan: {NamestajLista[i].Obrisan}"); 
            }

            Console.WriteLine("\n");
        }

        private static void Dodaj()
        {
            Console.WriteLine("=== Dodavanje Novog Namestaja ===");

            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite sifru: ");
            string sifra = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite kolicinu u magacinu: ");
            int kolicinaUMagacinu = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite naziv tipa namestaja (ID): "); // NAPOMENA: U praksi se sve veze preko ID-a
            int idTipaNamestaja = int.Parse(Console.ReadLine());

            TipNamestaja trazeniTipNamestaja = null;

            foreach (var tipNamestaja in TipNamestajaLista)
            {
                if (tipNamestaja.Id == idTipaNamestaja)
                {
                    trazeniTipNamestaja = tipNamestaja;
                    break;
                }

            }

            Console.WriteLine("Unesite akciju koju namestaj ima (ID):");
            int idAkcije = int.Parse(Console.ReadLine());

            Akcija trazenaAkcija = null;

            foreach (var akcija in AkcijaLista)
            {
                if (akcija.Id == idAkcije)
                {
                    trazenaAkcija = akcija;
                    break;
                }
            }


            var noviNamestaj = new Namestaj()
            {
                Id = NamestajLista.Count + 1,
                Obrisan = false,

                Naziv = naziv,
                Sifra = sifra,
                Cena = cena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                TipNamestaja = trazeniTipNamestaja,
                Akcija = trazenaAkcija
            };

            NamestajLista.Add(noviNamestaj);
        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Namestaja ===");

            Console.WriteLine("Unesite ID namestaja koji zelite da menjate, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Namestaj namestajZaIzmenu = PoId(trazeniId);
                
                if(namestajZaIzmenu != null)
                {
                    Console.WriteLine("Unesite novi naziv namestaja: ");
                    namestajZaIzmenu.Naziv = Console.ReadLine();

                    Console.WriteLine("Unesite novu sifru namestaja: ");
                    namestajZaIzmenu.Sifra = Console.ReadLine();

                    Console.WriteLine("Unesite novu cenu namestaja: ");
                    namestajZaIzmenu.Cena = double.Parse(Console.ReadLine());

                    Console.WriteLine("Unesite novu kolicinu u magacinu: ");
                    namestajZaIzmenu.KolicinaUMagacinu = int.Parse(Console.ReadLine());

                    Console.WriteLine("Unesite novi tip namestaja (ID): "); // NAPOMENA: U praksi se sve veze preko ID-a
                    int idTipaNamestaja = int.Parse(Console.ReadLine());

                    TipNamestaja noviTipNamestaja = null;

                    foreach (var tipNamestaja in TipNamestajaLista)
                    {
                        if (tipNamestaja.Id == idTipaNamestaja)
                        {
                            noviTipNamestaja = tipNamestaja;
                            break;
                        }

                    }
                    namestajZaIzmenu.TipNamestaja = noviTipNamestaja;

                    Console.WriteLine("Unesite novu akciju koju namestaj ima (ID): ");
                    int idAkcije = int.Parse(Console.ReadLine());

                    Akcija novaAkcija = null;

                    foreach (var akcija in AkcijaLista)
                    {
                        if (akcija.Id == idAkcije)
                        {
                            novaAkcija = akcija;
                            break;
                        }
                    }
                    namestajZaIzmenu.Akcija = novaAkcija;
                }
            }
        }

        private static void Obrisi()
        {
            Console.WriteLine("=== Brisanje Namestaja ===");

            Console.WriteLine("Unesite ID namestaja koji zelite da obrisete, ili 0 za izlaz: ");
            int trazeniId = int.Parse(Console.ReadLine());

            if (trazeniId != 0)
            {
                Namestaj namestajZaBrisanje = PoId(trazeniId);
                if(namestajZaBrisanje != null)
                {
                    namestajZaBrisanje.Obrisan = true;
                }
            }
        }

        public static Namestaj PoId(int id)
        {
            // Funkcija kojoj prosledjujemo id namestaja koji trazimo.
            // U slucaju da je namestaj pronadjen, vraca objekat Namestaj, a ako ne vraca null i ispisuje poruku
            Namestaj nadjeno = null;
            foreach (Namestaj namestaj in Podaci.ListaNamestaj)
            {
                if (namestaj.Id == id)
                {
                    nadjeno = namestaj;
                    break;
                }
            }
            if (nadjeno == null)
            {
                Console.WriteLine("NIJE PRONADJEN NAMESTAJ SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeno;
        }
    }


}

