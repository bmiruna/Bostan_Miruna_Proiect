using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bostan_Miruna_Proiect.Data;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public IndexModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
