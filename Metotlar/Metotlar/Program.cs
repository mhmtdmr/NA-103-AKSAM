using System;
using System.Collections.Generic;
using System.Linq;

namespace Metotlar
{
    class Program
    {
        // void: hiçbirşey döndürmez
        // static: anahtar kelimesini alan bir metot veya değişken programın başından sonuna kadar ram'den silinmez !!!
        static void Main(string[] args)
        {
            ////MerhabaYaz();  // 1. tanımlamayı çalıştırır.
            ////Console.WriteLine("--------------------");
            ////MerhabaYaz(5); // 2. tanımlanmayı çalıştırır.

            //MerhabaYaz(); // varsayılan 1 parametresi ile çalışır.
            //Console.WriteLine("--------------------");
            //MerhabaYaz(8); // adet parametresi için varsayılan yerine 8 gönderdik.
            ////MerhabaYaz(adet:8); // isim belirterek değer gönderdik.


            //int intKare = Kare(9);
            //float fltKare = Kare(9.5f);
            //double dblKare = Kare(199.4D);

            //Console.WriteLine(intKare);
            //Console.WriteLine(fltKare);
            //Console.WriteLine(dblKare);

            int[] numbers = new int[] { 2, 3, 4, 5, 6 };
            List<int> squares =  Kare(numbers); // Metotdan gelen liste verisini squares isimli listeye atadık.
            ListeYaz(squares);
            





            // static kullanmadan metotlara nesne üzerinden erişilebilir. Sonra anlatılacak.

            //Araba sahin = new Araba(); // nesne tanımladık.
            //sahin.MarkaYaz();
        }


        //static void MerhabaYaz()
        //{
        //    Console.WriteLine("Merhaba");
        //}
        //  Metodu aynı isim farklı parametre ile tekrar tanımlayabilir ve kullanabiliriz.
        // Buna method overloading: metotların aşırı yüklenmesi denir.
        static void MerhabaYaz(int adet=1) // varsayılan değer verdik. Bu sayede metodu değer göndermeden kullanabiliriz.
        {
            for (int i = 0; i < adet; i++)
            {
                Console.WriteLine("Merhaba");
            }
        }

        // parametre olarak herhangi bir veri tipi,dizi tipi,nesne,Liste
        static void DiziYaz(string[] dizi)
        {
            foreach (string eleman in dizi)
            {
                Console.WriteLine($"Eleman : {eleman}");
            }
        }

        // Değer döndüren metotlar
        static int Kare(int sayi)
        {
            return sayi * sayi;
        }
        static double Kare(double sayi)
        {
            return sayi * sayi;
        }

        static float Kare(float sayi)
        {
            return sayi * sayi;
        }

        static List<int> Kare(int[] sayilar)
        {
            List<int> kareler = new List<int>();
            for (int i = 0; i < sayilar.Length; i++)
            {
                int kare = sayilar[i] * sayilar[i];
                kareler.Add(kare);
            }
            return kareler;
        }

        static void ListeYaz(List<int> liste)
        {
            for (int i = 0; i < liste.Count(); i++)
            {
                Console.Write(liste[i] + "  ");

            }
        }


    }





    //class Araba
    //{
    //    string marka;
    //    public void MarkaYaz()
    //    {
    //        Console.WriteLine($"Marka : {this.marka}");
    //    }
    //}
}
