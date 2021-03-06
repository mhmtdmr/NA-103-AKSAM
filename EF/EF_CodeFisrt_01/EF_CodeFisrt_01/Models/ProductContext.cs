using System;
using System.Data.Entity;
using System.Linq;

namespace EF_CodeFisrt_01.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<EF_CodeFisrt_01.Models.Category> Categories { get; set; }
    }
}