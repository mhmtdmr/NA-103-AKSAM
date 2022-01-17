using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Abstract
{
    // abstract sınıflar aracılığı ile bir sınıftan miras alacak sınıfların istediğimiz isimde metodu tanımlamasını sağlarız.Polimorfizm'i destekler.
    abstract class Sekil
    {
        public string SekilAd { get; set; }
                
        // alt sınıflardan kullanılabilecek bir metot
        public void SekilAdYaz()
        {
            Console.WriteLine(this.SekilAd);
        }

        // aşağıdaki abstract metotlar bu sınıftan miras alan alt sınıflarda tanımlanmak zorunda.
        abstract public void CevreHesapla();
        abstract public void AlanHesapla();

    }
}
