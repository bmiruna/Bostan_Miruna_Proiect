using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bostan_Miruna_Proiect.Data;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public IndexModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID) 
        {
            ProductD = new ProductData();
            
            ProductD.Products = await _context.Product
                .Include(p => p.Make)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Category)
                .AsNoTracking()
                .OrderBy(p => p.PublishingDate)
                .ToListAsync();

            if(id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Products
                    .Where(p => p.ID == id.Value).Single();
                ProductD.Categories = product.ProductCategories.Select(s => s.Category);
            }

        }
    }
}
