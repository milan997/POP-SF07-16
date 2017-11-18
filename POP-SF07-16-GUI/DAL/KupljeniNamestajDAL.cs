using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class KupljeniNamestajDAL
    {
        public static void Add(KupljeniNamestaj kupljeniNamestaj)
        {
            List<KupljeniNamestaj> lista = Projekat.Instance.KupljeniNamestajLista;
            lista.Add(kupljeniNamestaj);
            Projekat.Instance.KupljeniNamestajLista = lista;
        }

        public static List<KupljeniNamestaj> GetList()
        {
            return Projekat.Instance.KupljeniNamestajLista;
        }

        public static void UpdateList(List<KupljeniNamestaj> newList)
        {
            Projekat.Instance.KupljeniNamestajLista = newList;
        }

        public static KupljeniNamestaj GetById(int id)
        {
            KupljeniNamestaj kupljeniNamestaj = null;
            foreach (KupljeniNamestaj kn in Projekat.Instance.KupljeniNamestajLista)
            {
                if (kn.Id == id)
                {
                    kupljeniNamestaj = kn;
                    break;
                }
            }
            return kupljeniNamestaj;
        }
    }
}
