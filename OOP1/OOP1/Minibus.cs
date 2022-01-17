using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Minibus:Vasita
    {
        public string KoltukSayisi { get; set; }
        public string SasiTipi { get; set; }
        public string RuhsatKaydi { get; set; }

        // new anahtar kelimesi ile üst sınıfta aynı isim ile tanımlanmış olan metodu kasten devre dışı çağırdığımızı belirtmiş oldk.
        override public void BilgiYaz()
        {
            base.BilgiYaz(); // üst sınıfta tanımlı Bilgiyaz metodunu tanımladık.
            Console.WriteLine("Koltuk Sayısı : "+this.KoltukSayisi);
            Console.WriteLine("Şasi Tipi : "+this.SasiTipi);
            Console.WriteLine("Ruhsat Kaydı : "+this.RuhsatKaydi);
        }
    }
}
