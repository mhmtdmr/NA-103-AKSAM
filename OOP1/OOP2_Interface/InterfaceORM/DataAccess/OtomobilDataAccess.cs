using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2_Interface.InterfaceORM.Base;
using OOP2_Interface.InterfaceORM.Models;

namespace OOP2_Interface.InterfaceORM.DataAccess
{
    class OtomobilDataAccess : IDatabase
    {
        static private OtomobilDataAccess _methods { get; set; }
        public static OtomobilDataAccess methods 
        {
            get 
            {
                if (_methods == null)
                    _methods = new OtomobilDataAccess();
                return _methods;
            }
        }
        public int Create(Object oto)
        {
            Otomobil otomobil = (Otomobil)oto;
            try
            {
                Otomobil.OtomobilDB.Add(otomobil.ID, otomobil);
                return otomobil.ID;
            }
            catch
            {
                return -1;
            }
        }

        public bool Delete(int id)
        {
            try 
            { 
                Otomobil.OtomobilDB.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public object GetByID(int id)
        {
            try
            { 
                Otomobil obj = Otomobil.OtomobilDB[id];
                return obj;
            }
            catch
            {
                return -1;
            }
        }

        public List<object> List()
        {
            List<object> otomobiller = new List<object>();
            foreach(int key in Otomobil.OtomobilDB.Keys)
            {//TODO :Add yazdıktan sonra kontrol edilmedi.
                otomobiller.Add(Otomobil.OtomobilDB[key]);
            }
            return otomobiller;
        }
        public Dictionary<int, Otomobil> OtoListele()
        {
            return Otomobil.OtomobilDB;
        }

        public bool Update(Object oto)
        {
            return true;
            // öğrenciler yapacak.
        }
    }
}
