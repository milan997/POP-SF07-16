using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class KorisnikDAL
    {
        public static void Add(Korisnik korisnik)
        {
            List<Korisnik> lista = Projekat.Instance.KorisnikLista;
            lista.Add(korisnik);
            Projekat.Instance.KorisnikLista = lista;
        }

        public static List<Korisnik> GetList()
        {
            return Projekat.Instance.KorisnikLista;
        }

        public static void UpdateList(List<Korisnik> newList)
        {
            Projekat.Instance.KorisnikLista = newList;
        }

        public static Korisnik GetById(int id)
        {
            Korisnik korisnik = null;
            foreach (Korisnik k in Projekat.Instance.KorisnikLista)
            {
                if (k.Id == id)
                {
                    korisnik = k;
                    break;
                }
            }
            return korisnik;
        }
    }
}
