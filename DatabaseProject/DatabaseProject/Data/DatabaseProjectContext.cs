using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;

namespace DatabaseProject.Data
{
    public class DatabaseProjectContext : DbContext
    {
        public DatabaseProjectContext (DbContextOptions<DatabaseProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DatabaseProject.Models.DataDeduplication> DataDeduplication { get; set; } = default!;
    }
}
