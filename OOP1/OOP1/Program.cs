using System;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sayi = 0; // set
            //Console.WriteLine(sayi); // get

            Araba oto1 = new Araba();
            oto1.Marka = "Mazda";
            oto1.Model = "626";
            oto1.ModelYili = 1997;
            Console.WriteLine("oto1 yaş:"+oto1.Yas);

            //Console.WriteLine(oto1.ID);

            //Araba oto2 = new Araba("Mercedes","CLS500",2010);

        }
    }
}
