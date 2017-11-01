using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.KonzolniInterfejs
{
    class Extra
    /// Klasa za dodate staticke klase koje nam koriste stosta
    {
        public static void CRUDMeni()
        {
            /// Ispis standardnog CRUD (create, read, update, delete) menija
            Console.WriteLine("1. Prikazi Listing");
            Console.WriteLine("2. Dodaj Novi");
            Console.WriteLine("3. Izmeni Postojeci");
            Console.WriteLine("4. Obrisi Postojeci");
        }
    }
}
