using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Interface
{
    interface IIlan
    {
        int IlanN { get; set; }
        DateTime IlanTarihi { get; set; }
        Kullanici Kullanici { get; set; }
    }
}
