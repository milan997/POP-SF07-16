using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class AkcijaDAL
    {
        public static void Add(Akcija akcija)
        {
            akcija.Id = GetList().Count;
            akcija.Obrisan = false;
            ObservableCollection<Akcija> lista = GetList();
            lista.Add(akcija);
            UpdateList(lista);
        }

        public static void Update(Akcija akcija)
        {
            ObservableCollection<Akcija> list = GetList();
            list[akcija.Id] = akcija;
            UpdateList(list);
        }

        public static ObservableCollection<Akcija> GetList()
        {
            return Projekat.Instance.AkcijaLista;
        }

        public static void UpdateList(ObservableCollection<Akcija> newList)
        {
            Projekat.Instance.AkcijaLista = newList;
        }

        public static Akcija GetById(int id)
        {
            Akcija akcija = null;
            foreach (Akcija a in GetList())
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
