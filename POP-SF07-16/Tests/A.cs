using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Tests
{
    public class A
    {
        //////private string ime = "Milan";
        public string Ime
        {
            get
            {
                Console.WriteLine(this.Ime);
                return this.Ime;
            }
            set
            {
                this.Ime = value;
            }
        }
        // Sledeci red
        
    }
}
