using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    static class Extra
    /// Klasa za dodate staticke klase koje nam koriste stosta
    {
        public static void CRUDMeni()
        {
            /// Ispis standardnog CRUD (create, read, update, delete) menija
            Console.WriteLine("1. Prikazi Listing");
            Console.WriteLine("2. Dodaj Novi");
            Console.WriteLine("3. Izmeni Postojeci");
            Console.WriteLine("4. Obrisi Postojeci");
            Console.WriteLine("0. Povratak");
        }
        /*
        public static Object Pronadji(string entitet, int id)
        {
            // Funkcija kojoj prosledjujemo id namestaja koji trazimo.
            // U slucaju da je namestaj pronadjen, vraca objekat Namestaj, a ako ne vraca null i ispisuje poruku

            List<Namestaj> NamestajLista = Podaci.ListaNamestaj;
            bool namestajPronadjen = false;
            Namestaj nadjeniNamestaj = null;
            foreach (Namestaj namestaj in NamestajLista)
            {
                if (namestaj.Id == id)
                {
                    nadjeniNamestaj = namestaj;
                    namestajPronadjen = true;
                    break;
                }
            }
            if (namestajPronadjen == false)
            {
                Console.WriteLine("NIJE PRONADJEN NAMESTAJ SA TRAZENIM ID-OM!!!\n");
            }

            return nadjeniNamestaj;
        }
        */
    }
}
