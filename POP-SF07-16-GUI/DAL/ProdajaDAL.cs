using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class ProdajaDAL
    {
        public static void Add(Prodaja prodaja)
        {
            List<Prodaja> lista = Projekat.Instance.ProdajaLista;
            lista.Add(prodaja);
            Projekat.Instance.ProdajaLista = lista;
        }

        public static List<Prodaja> GetList()
        {
            return Projekat.Instance.ProdajaLista;
        }

        public static Prodaja GetById(int id)
        {
            Prodaja prodaja = null;
            foreach (Prodaja p in Projekat.Instance.ProdajaLista)
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
