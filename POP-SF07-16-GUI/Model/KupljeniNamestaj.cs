﻿using POP_SF07_16_GUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF07_16.Model
{
    public class KupljeniNamestaj
    {
        public int Id { get; set; }
        public int NamestajID { get; set; }
        public int Kolicina { get; set; }
        
        public KupljeniNamestaj()
        {
            
        }
    }
}
