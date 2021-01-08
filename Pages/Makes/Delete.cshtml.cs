using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bostan_Miruna_Proiect.Data;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public DeleteModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Make.FirstOrDefaultAsync(m => m.ID == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Make.FindAsync(id);

            if (Make != null)
            {
                _context.Make.Remove(Make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
