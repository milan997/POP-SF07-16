using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class ProdajaDAL
    {
        public static void Add(Prodaja prodaja)
        {
            ObservableCollection<Prodaja> lista = GetList();
            lista.Add(prodaja);
            UpdateList(lista);
        }

        public static ObservableCollection<Prodaja> GetList()
        {
            return Projekat.Instance.ProdajaLista;
        }

        public static void UpdateList(ObservableCollection<Prodaja> newList)
        {
            Projekat.Instance.ProdajaLista = newList;
        }

        public static Prodaja GetById(int id)
        {
            Prodaja prodaja = null;
            foreach (Prodaja p in GetList())
            {
                if (p.Id == id)
                {
                    prodaja = p;
                    break;
                }
            }
            return prodaja;
        }
    }
}
