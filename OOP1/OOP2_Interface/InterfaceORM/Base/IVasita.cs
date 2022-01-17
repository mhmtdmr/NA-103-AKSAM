using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Interface.InterfaceORM.Base
{
    interface IVasita
    {
        int ID { get; set; }
        string Marka { get; set; }
        string Model { get; set; }
    }
}
