using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class KorisnikDAL
    {
        public static void Add(Korisnik korisnik)
        {
            korisnik.Id = GetList().Count;
            korisnik.Obrisan = false;
            ObservableCollection<Korisnik> lista = GetList();
            lista.Add(korisnik);
            UpdateList(lista);
        }

        public static void Update(Korisnik korisnik)
        {
            ObservableCollection<Korisnik> list = GetList();
            list[korisnik.Id] = korisnik;
            UpdateList(list);
        }

        public static ObservableCollection<Korisnik> GetList()
        {
            return Projekat.Instance.KorisnikLista;
        }

        public static void UpdateList(ObservableCollection<Korisnik> newList)
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
