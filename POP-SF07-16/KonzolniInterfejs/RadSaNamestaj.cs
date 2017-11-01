using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    class RadSaNamestaj
    {

        private static List<Namestaj> NamestajLista = Podaci.ListaNamestaj;
        private static List<TipNamestaja> TipNamestajaLista = Podaci.ListaTipNamestaja;

        public static void namestajMeni()
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
                        PrikaziNamestaj();
                        break;
                    case 2:
                        DodajNamestaj();
                        break;
                    case 3:
                        IzmenaNamestaja();
                        break;
                    case 4:
                        ObrisiNamestaj();
                        break;
                    default:
                        break;
                }
            } while (izbor != 0);
                
        }

        private static void PrikaziNamestaj()
        {
            Console.WriteLine("=== Prikaz Namestaja ===");

            for (int i = 0; i < NamestajLista.Count; i++)
            {
                Console.WriteLine($"{i + 1} Naziv: {NamestajLista[i].Naziv}, Sifra {NamestajLista[i].Sifra}, Cena: {NamestajLista[i].Cena}, " +
                    $"Kolicina U Magacinu{NamestajLista[i].KolicinaUMagacinu}"); //// NIJE GOTOVO!!!
            }

            Console.WriteLine("\n");
        }

        private static void DodajNamestaj()
        {
            Console.WriteLine("=== Dodavanje Novog Namestaja ===");

            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite naziv tipa namestaja (ID): "); // NAPOMENA: U praksi se sve veze preko ID-a
            int idTipaNamestaja = int.Parse(Console.ReadLine());

            TipNamestaja trazeniTipNamestaja = null;

            foreach (var tipNamestaja in TipNamestajaLista)
            {
                if (tipNamestaja.Id == idTipaNamestaja)
                {
                    trazeniTipNamestaja = tipNamestaja;
                }

            }


            var noviNamestaj = new Namestaj()
            {
                Id = NamestajLista.Count + 1,
                Naziv = naziv,
                Cena = cena,
                TipNamestaja = trazeniTipNamestaja
            };

            NamestajLista.Add(noviNamestaj);
        }

        private static void IzmenaNamestaja()
        {
            Console.WriteLine("=== Izmena Namestaja ===");

            Console.WriteLine("Unesite ID namestaja koji zelite da menjate, ili 0 za izlaz: ");
            int izbor = int.Parse(Console.ReadLine());

            if (izbor != 0)
            {
                Namestaj trazeniNamestaj = null;
                foreach (Namestaj namestaj in NamestajLista)
                {
                    if (namestaj.Id == izbor)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

                Console.WriteLine("Unesite novi naziv namestaja: ");
                trazeniNamestaj.Naziv = Console.ReadLine();

                Console.WriteLine("Unesite novu cenu namestaja: ");
                trazeniNamestaj.Cena = double.Parse(Console.ReadLine());
            }



        }

        private static void ObrisiNamestaj()
        {
            Console.WriteLine("=== Brisanje Namestaja ===");

            Console.WriteLine("Unesite ID namestaja koji zelite da obrisete, ili 0 za izlaz: ");
            int izbor = int.Parse(Console.ReadLine());

            if (izbor != 0)
            {
                Namestaj trazeniNamestaj = null;
                foreach (Namestaj namestaj in NamestajLista)
                {
                    if (namestaj.Id == izbor)
                        trazeniNamestaj = namestaj;

                    NamestajLista.Remove(trazeniNamestaj);
                    break;
                }
            }
        }
    }
}

