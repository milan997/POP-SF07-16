using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class AkcijaDAL
    {
        public static void Add(Akcija akcija)
        {
            List<Akcija> lista = Projekat.Instance.AkcijaLista;
            lista.Add(akcija);
            Projekat.Instance.AkcijaLista = lista;
        }

        public static List<Akcija> GetList()
        {
            return Projekat.Instance.AkcijaLista;
        }

        public static void UpdateList(List<Akcija> newList)
        {
            Projekat.Instance.AkcijaLista = newList;
        }

        public static Akcija GetById(int id)
        {
            Akcija akcija = null;
            foreach (Akcija a in Projekat.Instance.AkcijaLista)
            {
                if (a.Id == id)
                {
                    akcija = a;
                    break;
                }
            }
            return akcija;
        }
    }
}
