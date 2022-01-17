using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Abstract
{
    class Kare:Sekil
    {
        public float kenar { get; set; }

        public override void AlanHesapla()
        {
            float alan = this.kenar * this.kenar;
            Console.WriteLine("Karenin Alanı:"+alan);
        }

        public override void CevreHesapla()
        {
            float cevre = 4 * kenar;
            Console.WriteLine("Karenin Çevresi:"+cevre);
        }
    }
}
