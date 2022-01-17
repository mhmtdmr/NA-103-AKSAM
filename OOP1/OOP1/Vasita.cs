using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{ // SuperClass
    class Vasita
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Seri { get; set; }
        public string Model { get; set; }

        virtual public void BilgiYaz()
        {
            Console.WriteLine("ID : "+this.ID);
            Console.WriteLine("Marka : "+this.Marka);
            Console.WriteLine("Seri : "+this.Seri);
            Console.WriteLine("Model : "+this.Model);
        }

    }
}
