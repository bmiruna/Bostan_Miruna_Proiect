using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bostan_Miruna_Proiect.Models
{
    public class Make
    {
        public int ID { get; set; }
        
        [Display(Name = "Brand")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Start with uppercase letter"), Required]
        public string MakeName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
