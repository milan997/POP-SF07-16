using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class GlavniMeni
    {
        public static void glavniMeni()
        {
            Podaci.UcitajPodatke(); // Ucitavamo podatke u staticke liste

            Console.WriteLine("=== Dobrodosli u Aplikaciju!!! ===");
            int izbor = 0;
            do
            {
                //Ispitaj nesto
                do
                {
                    Console.WriteLine("=== Glavni Meni ===");
                    Console.WriteLine("1. Rad sa Namestajem");
                    Console.WriteLine("2. Rad sa Tipom Namestaja");
                    Console.WriteLine("3. Rad sa Salonom");
                    Console.WriteLine("4. Rad sa Korisnicima");
                    Console.WriteLine("5. Rad sa Prodajama");
                    Console.WriteLine("6. Rad sa Akcijama");
                    Console.WriteLine("7. Rad sa Dodatnim Uslugama");
                    Console.WriteLine("0. Izlaz iz aplikacije");

                    izbor = int.Parse(Console.ReadLine());

                } while (izbor < 0 || izbor > 7);

                switch (izbor)
                {
                    case 1:
                        RadSaNamestaj.NamestajMeni();
                        break;
                    case 2:
                        RadSaTipNamestaja.TipNamestajaMeni();
                        break;
                    case 3:
                        RadSaSalonom.SalonMeni();
                        break;
                    case 4:
                        RadSaKorisnik.KorisnikMeni();
                        break;
                    case 5:
                        RadSaProdaja.ProdajaMeni();
                        break;
                    case 6:
                        RadSaAkcija.AkcijaMeni();
                        break;
                    case 7:
                        RadSaDodatnaUsluga.DodatnaUslugaMeni();
                        break;
                    default:
                        break;
                }


            } while (izbor != 0);

            Console.WriteLine("=== DOVIDJENJA!!! ===");
            Console.ReadLine();
        }
    }
}
