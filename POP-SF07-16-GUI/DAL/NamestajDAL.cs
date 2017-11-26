using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class NamestajDAL
    {
        public static void Add(Namestaj namestaj)
        {
            namestaj.Id = GetList().Count;
            namestaj.Obrisan = false;
            ObservableCollection<Namestaj> lista = GetList();
            lista.Add(namestaj);
            UpdateList(lista);
        }

        public static void Update(Namestaj namestaj)
        {
            ObservableCollection<Namestaj> list = GetList();
            list[namestaj.Id] = namestaj;
            UpdateList(list);
        }

        public static ObservableCollection<Namestaj> GetList()
        {
            return Projekat.Instance.NamestajLista;
        }

        public static void UpdateList(ObservableCollection<Namestaj> newList)
        {
            Projekat.Instance.NamestajLista = newList;
        }

        public static Namestaj GetById(int id)
        {
            Namestaj namestaj = null;
            foreach (Namestaj n in GetList())
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
