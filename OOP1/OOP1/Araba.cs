using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    class Araba
    {
        private static int ID_Counter = 0;
        private int _ID { get; set; }

        public int ID
        {
            get { return this._ID; } // readonly.
        }
        public string Marka { get; set; }
        public string Model { get; set; }

        private int _ModelYili { get; set; }
        public int ModelYili {
            get
            {
                return this._ModelYili;
            }
            set
            {
                this._ModelYili = value;
                this.Yas = YasHesapla(value);
            } 
        }

        public int Yas { get; set; }

        private int YasHesapla(int modelYili)
        {
            int anlikYil = DateTime.Now.Year;
            return anlikYil - modelYili;
        }
        public Araba()
        {
            ID_Counter++;
            this._ID = ID_Counter;
            Console.WriteLine($"Yapıcı metot çalıştı. ID:{this._ID}");
        }
        public Araba(string marka, string model, int modelYili)
        {
            ID_Counter++;
            this._ID = ID_Counter;
            this.Marka = marka;
            this.Model = model;
            this.ModelYili = modelYili;
            Console.WriteLine($"Parametreli yapıcı metot çalıştı. ID:{this._ID}");
        }
    }
}
