using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Abstract
{
    class Daire : Sekil
    {
        public int YariCap { get; set; }
        private float Pi = 3.14f;
        public override void AlanHesapla()
        {
            float alan = this.YariCap * this.YariCap * Pi;
            Console.WriteLine("Çevre Alanı:"+alan);
        }

        public override void CevreHesapla()
        {
            float cevre = 2 * this.YariCap * Pi;
            Console.WriteLine("Daire Çevresi:"+cevre);
        }
    }
}
