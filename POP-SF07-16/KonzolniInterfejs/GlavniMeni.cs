using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    class GlavniMeni
    {
        public static void glavniMeni()
        {
            new Podaci(); // Inicijalizujemo klasu Podaci() u kojoj se nalaze liste svih objekata, 
                          // kao i inicijalizacija pocetnih objekata pri startovanju aplikacije.

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

                } while (izbor < 0 || izbor > 2);

                switch (izbor)
                {
                    case 1:
                        RadSaNamestaj.namestajMeni();
                        break;
                    default:
                        break;
                }


            } while (izbor != 0);
        }
    }
}
