using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class RadSaSalonom
    {
        private static Salon salon = Podaci.salon;

        public static void SalonMeni()
        {

            int izbor = 0;
            do
            {
                Console.WriteLine("=== Rad Sa Salonom ===");
                Console.WriteLine("1. Izmeni salon");
                Console.WriteLine("0. Povratak");
                izbor = int.Parse(Console.ReadLine());
                if (izbor == 1) { Izmeni(); }                
            }  
            while (izbor != 0);

        }

        private static void Izmeni()
        {
            Console.WriteLine("=== Izmena Salona ===");

            Console.WriteLine("Unesite novi naziv salona: ");
            salon.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite novu adresu salona: ");
            salon.Adresa = Console.ReadLine();

            Console.WriteLine("Unesite novi telefon salona: ");
            salon.Telefon = Console.ReadLine();

            Console.WriteLine("Unesite novi email salona: ");
            salon.Email = Console.ReadLine();

            Console.WriteLine("Unesite novu web adresu salona: ");
            salon.WebAdresa = Console.ReadLine();

            Console.WriteLine("Unesite novi PIB salona: ");
            salon.PIB = Console.ReadLine();

            Console.WriteLine("Unesite novi maticni broj salona: ");
            salon.MaticniBroj = Console.ReadLine();

            Console.WriteLine("Unesite novi ziro racun salona: ");
            salon.BrojZiroRacuna = Console.ReadLine();
            
        }
    }
}

