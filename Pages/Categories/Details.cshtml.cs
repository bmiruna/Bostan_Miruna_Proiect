﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext _context;

        public DetailsModel(Bostan_Miruna_Proiect.Data.Bostan_Miruna_ProiectContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
