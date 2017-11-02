using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class KupljeniNamestaj
    {
        public Namestaj Namestaj { get; set; }
        public int Kolicina { get; set; }
        
        public double Cena()
        {
            double cena = Namestaj.Cena * Kolicina;
            return cena;
        }
    }
}
