using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Interface.OLD
{
    class Otomobil : IVasita, IIlan
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int IlanN { get; set; }
        public DateTime IlanTarihi { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
