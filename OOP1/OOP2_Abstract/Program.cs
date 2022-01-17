using System;

namespace OOP2_Abstract
{
    class Program
    {
        static void Main(string[] args)
        {
            Daire d = new Daire();
            d.SekilAd = "Daire";
            d.YariCap = 25;

            Kare k = new Kare();
            k.SekilAd = "Kare";
            k.kenar = 15;

            CevreHesapla(d);
            CevreHesapla(k);

            AlanHesapla(d);
            AlanHesapla(k);

            AdYaz(d);
            AdYaz(k);
        }
        static void CevreHesapla(Sekil nesne)
        {
            nesne.CevreHesapla();
        }
        static void AlanHesapla(Sekil nesne)
        {
            nesne.AlanHesapla();
        }
        static void AdYaz(Sekil nesne)
        {
            nesne.SekilAdYaz();
        }
    }
}
