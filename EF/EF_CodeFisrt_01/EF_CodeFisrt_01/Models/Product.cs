using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_CodeFisrt_01.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public DateTime Expiration { get; set; }
    }
}