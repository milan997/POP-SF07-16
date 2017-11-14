using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class TipNamestajaDAL
    { 
        public static void Add(TipNamestaja tipNamestaja)
        {
            Projekat.Instance.TipNamestajaLista.Add(tipNamestaja);
        }

        public static List<TipNamestaja> Get()
        {
            return Projekat.Instance.TipNamestajaLista;
        }

        public static TipNamestaja GetById(int id)
        {
            TipNamestaja tipNamestaja = null;
            foreach (TipNamestaja tn in Projekat.Instance.TipNamestajaLista){
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
