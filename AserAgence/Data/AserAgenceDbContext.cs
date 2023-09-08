using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AserAgence.Models;

namespace AserAgence.Data
{
    public class AserAgenceDbContext : DbContext
    {
        public AserAgenceDbContext (DbContextOptions<AserAgenceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Region { get; set; } = default!;

        public DbSet<AserAgence.Models.Commune>? Commune { get; set; }

        public DbSet<AserAgence.Models.Department>? Department { get; set; }

        public DbSet<AserAgence.Models.Village>? Village { get; set; }

        public DbSet<AserAgence.Models.Survey>? Survey { get; set; }
    }
}
