using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bostan_Miruna_Proiect.Data;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public CreateModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MakeID"] = new SelectList(_context.Set<Make>(), "ID", "MakeName");

            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();

            PopulateSelectedCategoriesList(_context, product);
            
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var newProduct = new Product();

            if(selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach(var category in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(category)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }

            if(await TryUpdateModelAsync<Product>(
                    newProduct, "Product",
                    p => p.Name, p => p.Description,
                    p => p.PublishingDate, p => p.Image, p => p.Price,
                    p=>p.MakeID
                ))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateSelectedCategoriesList(_context, newProduct);
            return Page();
        }
    }
}
