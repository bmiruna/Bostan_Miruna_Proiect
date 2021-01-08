using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bostan_Miruna_Proiect.Models;

namespace Bostan_Miruna_Proiect.Data
{
    public class Bostan_Miruna_ProiectContext : DbContext
    {
        public Bostan_Miruna_ProiectContext (DbContextOptions<Bostan_Miruna_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Bostan_Miruna_Proiect.Models.Product> Product { get; set; }

        public DbSet<Bostan_Miruna_Proiect.Models.Make> Make { get; set; }

        public DbSet<Bostan_Miruna_Proiect.Models.Category> Category { get; set; }
    }
}
