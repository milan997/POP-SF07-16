using System;

namespace POP_SF07_16
{
    class Program
    {
        //public static List<Namestaj> NamestajLista = new List<Namestaj>();
        //public static List<TipNamestaja> TipNamestajaLista = new List<TipNamestaja>();

        public static void Main(string[] args)
        {
            KonzolniInterfejs.GlavniMeni.glavniMeni();
        }
        /*
        private static void IspisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                //Ispitaj nesto
                do
                {
                    Console.WriteLine("1. Rad sa namestajem");
                    Console.WriteLine("2. Rad sa Tipom Namestaja");
                    //... Dovrsiti kod kuce!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Console.WriteLine("0. Izlaz iz aplikacije");

                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 2);

                switch (izbor)
                {
                    case 1:
                        NamestajMeni();
                        break;
                    default:
                        break;
                }


            } while (izbor != 0);

        }
        *//*
        private static void NamestajMeni()
        {
            int izbor = 0;

            do
            { 
                Console.WriteLine("=== Rad Sa Namestajem ===");
                IspisiCRUDMeni(); // CRUD - Create, Read, Update, Delete
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
        }
        */
        /*
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
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

                NamestajLista.Remove(trazeniNamestaj);
            }
        }
        */
        /*
        private static void IzmenaNamestaja()
        {
            Console.WriteLine("=== Izmena Namestaja ===");

            Console.WriteLine("Unesite ID namestaja koji zelite da menjate, ili 0 za izlaz: ");
            int izbor = int.Parse(Console.ReadLine());

            if(izbor != 0)
            {
                Namestaj trazeniNamestaj = null;
                foreach (Namestaj namestaj in NamestajLista)
                {
                    if(namestaj.Id == izbor)
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
        */
        /*
        private static void DodajNamestaj()
        {
            Console.WriteLine("=== Dodavanje Novog Namestaja ===");

            Console.WriteLine("Unesite naziv: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            double cena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite naziv tipa namestaja: "); // NAPOMENA: U praksi se sve veze preko ID-a
            string nazivTipaNamestaja = Console.ReadLine();

            TipNamestaja trazeniTipNamestaja = null;

            foreach (var tipNamestaja in TipNamestajaLista)
            {
                if(tipNamestaja.Naziv == nazivTipaNamestaja)
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
        */
        /*
        private static void PrikaziNamestaj()
        {
            Console.WriteLine("=== Prikaz Namestaja ===");
            
            for (int i = 0; i < NamestajLista.Count; i++)
            { 
                Console.WriteLine($"{i + 1} Naziv: {NamestajLista[i].Naziv}, Cena: {NamestajLista[i].Cena} "); //// NIJE GOTOVO!!!
            }
        }
        */
        
    }
}
