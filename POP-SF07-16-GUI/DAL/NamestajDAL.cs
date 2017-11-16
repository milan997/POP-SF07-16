using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class NamestajDAL
    {
        public static void Add(Namestaj namestaj)
        {
            Projekat.Instance.NamestajLista.Add(namestaj);
        }

        public static List<Namestaj> Get()
        {
            return Projekat.Instance.NamestajLista;
        }

        public static void UpdateList(List<Namestaj> newList)
        {
            Projekat.Instance.NamestajLista = newList;
        }

        public static Namestaj GetById(int id)
        {
            Namestaj namestaj = null;
            foreach (Namestaj n in Projekat.Instance.NamestajLista)
            {
                if (n.Id == id)
                {
                    namestaj = n;
                    break;
                }
            }
            return namestaj;
        }
    }
}
