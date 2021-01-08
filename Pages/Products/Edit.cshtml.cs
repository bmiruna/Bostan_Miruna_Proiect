using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bostan_Miruna_Proiect.Data;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public EditModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(p=>p.Make).Include(p=>p.ProductCategories).ThenInclude(p=>p.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }

            PopulateSelectedCategoriesList(_context, Product);

            ViewData["MakeID"] = new SelectList(_context.Set<Make>(), "ID", "MakeName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Product
                        .Include(p => p.Make)
                        .Include(p => p.ProductCategories)
                        .ThenInclude(p => p.Category)
                        .FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                productToUpdate,
                "Product",
                p => p.Name, p => p.Description,
                p => p.PublishingDate, p => p.Image, p => p.Price))
            {
                UpdatePrductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdatePrductCategories(_context, selectedCategories, productToUpdate);
            PopulateSelectedCategoriesList(_context, productToUpdate);
            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
