using System;
using OOP2_Interface.InterfaceORM.Models;
using OOP2_Interface.InterfaceORM.DataAccess;
using System.Collections.Generic;

namespace OOP2_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Otomobil oto = new Otomobil();
            oto.KasaTipi = KasaTipi.TekKapı;
            oto.Marka = "Mercedes";
            oto.Model = "CLS500";
            oto.Renk = Renk.yeşil;
            int insertedID = OtomobilDataAccess.methods.Create(oto);
            Console.WriteLine( "insertedID:"+insertedID );

            Otomobil o = Otomobil.OtomobilDB[insertedID];
            Console.WriteLine($"{o.ID} - {o.Marka} - {o.Model} - {o.Renk} - {o.KasaTipi} ");

        }
    }
}
