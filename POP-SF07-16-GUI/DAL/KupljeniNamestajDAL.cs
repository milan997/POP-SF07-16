using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class KupljeniNamestajDAL
    {
        public static void Add(KupljeniNamestaj kupljeniNamestaj)
        {
            kupljeniNamestaj.Id = GetList().Count;
            ObservableCollection<KupljeniNamestaj> lista = GetList();
            lista.Add(kupljeniNamestaj);
            UpdateList(lista);
        }

        public static void Update(KupljeniNamestaj kupljeniNamestaj)
        {
            ObservableCollection<KupljeniNamestaj> list = GetList();
            list[kupljeniNamestaj.Id] = kupljeniNamestaj;
            UpdateList(list);
        }

        public static ObservableCollection<KupljeniNamestaj> GetList()
        {
            return Projekat.Instance.KupljeniNamestajLista;
        }

        public static void UpdateList(ObservableCollection<KupljeniNamestaj> newList)
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
