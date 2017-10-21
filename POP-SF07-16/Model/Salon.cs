using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Salon
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }

        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string WebAdresa { get; set; }
        public string PIB { get; set; }
        public string MaticniBroj { get; set; }
        public string BrojZiroRacuna { get; set; }

    }
}
