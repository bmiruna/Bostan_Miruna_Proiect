using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bostan_Miruna_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Numbers and special characters are not allowed. Start with uppercase"), Required]
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
