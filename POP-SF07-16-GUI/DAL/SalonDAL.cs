using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class SalonDAL
    {
        public static void Add(Salon salon)
        {
            salon.Id = GetList().Count;
            salon.Obrisan = false;
            ObservableCollection<Salon> lista = GetList();
            lista.Add(salon);
            UpdateList(lista);
        }

        public static void Update(Salon salon)
        {
            ObservableCollection<Salon> list = GetList();
            list[salon.Id] = salon;
            UpdateList(list);
        }

        public static ObservableCollection<Salon> GetList()
        {
            return Projekat.Instance.SalonLista;
        }

        public static void UpdateList(ObservableCollection<Salon> newList)
        {
            Projekat.Instance.SalonLista = newList;
        }
    }
}
