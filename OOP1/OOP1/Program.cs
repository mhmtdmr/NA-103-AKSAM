using System;

namespace OOP1
{
    class Program
    {
        static void BilgiYaz(Vasita nesne)
        {
            nesne.BilgiYaz();
        }
        static void Main(string[] args)
        {
            ///////////////////////////////
            ///    OOP ve Kapsülleme    ///
            ///////////////////////////////

            ////int sayi = 0; // set
            ////Console.WriteLine(sayi); // get

            //Araba oto1 = new Araba();
            //oto1.Marka = "Mazda";
            //oto1.Model = "626";
            //oto1.ModelYili = 1997;
            //Console.WriteLine("oto1 yaş:"+oto1.Yas);

            ////Console.WriteLine(oto1.ID);

            ////Araba oto2 = new Araba("Mercedes","CLS500",2010);

            ///////////////////////////////
            ///         Kalıtım         ///
            ///////////////////////////////

            Otomobil oto = new Otomobil();
            oto.Marka = "Honda";
            oto.Seri = "Accord";
            oto.Model = "2.0 VTEC";

            

            Minibus minib = new Minibus();
            minib.Marka = "Wolkswagen";
            minib.Seri = "Transporter";
            minib.Model = "City Van";
            minib.KoltukSayisi = "5+1";
            minib.SasiTipi = "Uzun";
            minib.RuhsatKaydi = "Ticari";


            BilgiYaz(oto);
            BilgiYaz(minib);



        }
    }
}
