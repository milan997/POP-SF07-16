using POP_SF07_16.Model;
using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16_GUI.BLL
{
    public class KupljeniNamestajBLL
    {
        public static List<KupljeniNamestaj> ListIntToListNamestaj(List<int> kupljeniNamestajInt)
        {
            //Funkcija za prosledjenu listu integera vraca listu KupljenihNamestaja
            List<KupljeniNamestaj> kupljeniNamestajObjekti = new List<KupljeniNamestaj>();

            if(kupljeniNamestajInt != null)
            {
                foreach (int id in kupljeniNamestajInt)
                    kupljeniNamestajObjekti.Add(GetById(id));
            }

            //Izbacujemo nullove iz liste
            kupljeniNamestajObjekti.RemoveAll(item => item == null);
            return kupljeniNamestajObjekti;
        }

        public static List<int> ListNamestajToListInt(List<KupljeniNamestaj> kupljeniNamestajLista)
        {
            //Funkcija za prosledjenu listu kupljenog namestaja vraca listu njihovih idova
            List<int> kupljeniNamestajInt = new List<int>();

            if(kupljeniNamestajLista != null)
            {
                foreach (KupljeniNamestaj kn in kupljeniNamestajLista)
                    kupljeniNamestajInt.Add(kn.Id);
            }

            return kupljeniNamestajInt;
        }

        public static KupljeniNamestaj GetById(int id)
        {
            KupljeniNamestaj kupljeniNamestaj = null;
            foreach(KupljeniNamestaj kn in KupljeniNamestajDAL.GetList())
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
