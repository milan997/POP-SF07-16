using POP_SF07_16.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.DAL
{
    public static class DodatnaUslugaDAL
    {
        public static void Add(DodatnaUsluga dodatnaUsluga)
        {
            List<DodatnaUsluga> lista = Projekat.Instance.DodatnaUslugaLista;
            lista.Add(dodatnaUsluga);
            Projekat.Instance.DodatnaUslugaLista = lista;
        }

        public static List<DodatnaUsluga> GetList()
        {
            return Projekat.Instance.DodatnaUslugaLista;
        }

        public static void UpdateList(List<DodatnaUsluga> newList)
        {
            Projekat.Instance.DodatnaUslugaLista = newList;
        }

        public static DodatnaUsluga GetById(int id)
        {
            DodatnaUsluga dodatnaUsluga = null;
            foreach (DodatnaUsluga du in Projekat.Instance.DodatnaUslugaLista)
            {
                if (du.Id == id)
                {
                    dodatnaUsluga = du;
                    break;
                }
            }
            return dodatnaUsluga;
        }
    }
}
