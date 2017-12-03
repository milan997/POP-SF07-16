using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class TipNamestajaDAL
    { 
        public static void Add(TipNamestaja tipNamestaja)
        {
            tipNamestaja.Id = GetList().Count;
            tipNamestaja.Obrisan = false;
            ObservableCollection<TipNamestaja> list = GetList();
            list.Add(tipNamestaja);
            UpdateList(list);
        }

        public static void Update(TipNamestaja tipNamestaja)
        {
            ObservableCollection<TipNamestaja> list = GetList();
            list[tipNamestaja.Id] = tipNamestaja;
            UpdateList(list);
        }

        public static ObservableCollection<TipNamestaja> GetList()
        {
            return Projekat.Instance.TipNamestajaLista;
        }

        public static void UpdateList(ObservableCollection<TipNamestaja> newList)
        {
            Projekat.Instance.TipNamestajaLista= newList;
        }

        public static TipNamestaja GetById(int id)
        {
            TipNamestaja tipNamestaja = null;
            foreach (TipNamestaja tn in GetList()){
                if(tn.Id == id)
                {
                    tipNamestaja = tn;
                    break;
                }
            }
            return tipNamestaja;
        }
    }
}