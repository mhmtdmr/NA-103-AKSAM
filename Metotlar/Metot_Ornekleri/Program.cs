using System;
using System.Collections.Generic;
using System.Linq;

namespace Metot_Ornekleri
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Liste olarak aldığı sayılardan tek olanları liste olarak döndüren metodu yazınız.
            //// TekDondur() List<int>
            //List<int> numbers = new List<int>(){2,3,4,5,6,7,8,9};
            //List<int> tekler = TekDondur(numbers);
            //ListeYaz(tekler);

            // kendisine gönderilen int tipinde 2 sayıdan büyük olanı döndüren metodu yazınız.
            // BuyukDondur() 2 parametre

            // kendisine gönderilen 3 sayıdan büyük olanı döndüren metodu yazınız.
            // BuyukDondur() 3 parametre
            // Püf: 2.de if kullanmayın. aynı metodu 2 parametreli kullanarak çözmeye çalışın.

            //Console.WriteLine($"En büyük : " + BuyukDondur(10,20,30));


            /*
            // Kendisine gönderilen fiyata KDV ekleyip geri döndüren metodu yazınz.
            //ürün kategorisine göre KDV eklenecek
            // gıda: %8, eğitim:%5,diğerleri:%18
            // Parametreler: fiyat,kategori
            */

            Console.WriteLine(KDVli(100,"gıda"));
            Console.WriteLine(KDVli(100, "eğitim"));
            Console.WriteLine(KDVli(100, "teknoloji"));


        }


        static List<int> TekDondur(List<int> sayilar)
        {
            List<int> tekler = new List<int>();
            for (int i = 0; i < sayilar.Count(); i++)
            {
                if (sayilar[i] % 2 == 1)
                    tekler.Add(sayilar[i]);
            }
            return tekler;
        }



        static void ListeYaz(List<int> liste)
        {
            for (int i = 0; i < liste.Count(); i++)
            {
                Console.Write(liste[i] + "  ");

            }
        }

        static int BuyukDondur(int s1,int s2)
        {
            if (s1 > s2)
                return s1;
            else
                return s2;
        }

        static int BuyukDondur(int s1,int s2, int s3)
        {
            int buyuk = BuyukDondur(s1, s2);
            int enBuyuk = BuyukDondur(buyuk, s3);
            return enBuyuk;
        }

        static float KDVli(float fiyat,string kategori)
        {
            if (kategori == "gıda")
                return fiyat * 1.08f;
            else if (kategori == "eğitim")
                return fiyat * 1.05f;
            else
                return fiyat * 1.18f;
        }

    }
}
