using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }


    public class Korisnik //Abstract?????
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorIme { get; set; }
        public string Lozinka { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}
