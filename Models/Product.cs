using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bostan_Miruna_Proiect.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, StringLength(100), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Start with uppercase letter")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required, StringLength(500), RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'.,\s-]*$", ErrorMessage = "Start your descriprion with uppercase letter")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        [Range(1, 15000)]
        public decimal Price { get; set; }

        [Display(Name = "Published at")]
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        [Display(Name = "Product image")]
        public string Image { get; set; }
        public int MakeID { get; set; }
        public Make Make { get; set; }

        [Display(Name = "Categories")]
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
