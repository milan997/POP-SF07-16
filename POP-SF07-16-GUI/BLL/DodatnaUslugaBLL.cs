using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.BLL
{
    public class DodatnaUslugaBLL
    {
        public static List<DodatnaUsluga> ListIntToListDodatnaUsluga(List<int> dodatnaUslugaInt)
        {
            //Funkcija za prosledjenu listu integera vraca listu Dodatnih Usluga
            List<DodatnaUsluga> dodatnaUslugaObjekti = new List<DodatnaUsluga>();
            if(dodatnaUslugaInt != null)
            {
                foreach (int id in dodatnaUslugaInt)
                    dodatnaUslugaObjekti.Add(GetById(id));
            }
            
            //Izbacujemo nullove iz liste
            dodatnaUslugaObjekti.RemoveAll(item => item == null);
            return dodatnaUslugaObjekti;
        }

        public static List<int> ListDodatnaUslugaToListInt(List<DodatnaUsluga> dodatnaUslugaLista)
        {
            //Funkcija za prosledjenu listu kupljenog namestaja vraca listu njihovih id-ova
            List<int> dodatnaUslugaInt = new List<int>();
            if (dodatnaUslugaLista != null)
            {
                foreach (DodatnaUsluga du in dodatnaUslugaLista)
                    dodatnaUslugaInt.Add(du.Id);
            }
            return dodatnaUslugaInt;
        }

        public static DodatnaUsluga GetById(int id)
        {
            DodatnaUsluga dodatnaUsluga = null;
            foreach (DodatnaUsluga du in DodatnaUslugaDAL.GetList())
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
