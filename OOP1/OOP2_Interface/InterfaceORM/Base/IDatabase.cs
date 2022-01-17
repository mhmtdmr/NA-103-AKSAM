using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Interface.InterfaceORM.Base
{
    interface IDatabase
    {
        int Create(Object obj);
        bool Delete(int id);
        bool Update(Object obj);
        object GetByID(int id);
        List<Object> List();
    }
}
