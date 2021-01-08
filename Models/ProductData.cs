using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bostan_Miruna_Proiect.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
