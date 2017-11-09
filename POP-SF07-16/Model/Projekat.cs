using POP_SF07_16.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        private List<TipNamestaja> tipNamestajaLista;

        public List<TipNamestaja> TipNamestajaLista
        {
            get
            {
                tipNamestajaLista = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
                return tipNamestajaLista;
            }
            set 
            {
                tipNamestajaLista = value;
                GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestajaLista);
            }
        }


        
    }
}
