using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2_Interface.InterfaceORM.Base;

namespace OOP2_Interface.InterfaceORM.Models
{
    enum KasaTipi
    { 
        Sedan,
        Station,
        TekKapı
    }
    enum Renk
    { 
        siyah,
        beyaz,
        kırmızı,
        sarı,
        yeşil,
        bordo,
        mavi,
        lacivert
    }
    class Otomobil : OOP2_Interface.InterfaceORM.Base.IVasita
    {
        public static Dictionary<int, Otomobil> OtomobilDB = new Dictionary<int, Otomobil>();
        public static int ID_Counter = 0;
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public KasaTipi KasaTipi { get; set; }
        public Renk Renk { get; set; }

        public Otomobil()
        {
            ID_Counter++;
            this.ID = ID_Counter;
        }
    }
}
