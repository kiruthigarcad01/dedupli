using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using myduplifree.Models;

namespace myduplifree.Data
{
    // Define a class called AppDbContext which inherits from DbContext
    public class AppDbContext : DbContext
    {
        // Constructor for AppDbContext that accepts DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Constructor body is empty in this example
        }

        public DbSet<LoginViewModel> login { get; set; }

        public DbSet<RegisterViewModel> Register { get; set; }

        public DbSet<DataholderViewModel> Dataholder { get; set; }
         public DbSet <cloudfilesViewModel> cloudfiles { get; set; }
         public DbSet<KGCViewModel> KGC { get; set; }


  
        
        // public DbSet<UploadfileViewModel> Uploadfile { get; set; }
    }

    public class cloudfilesViewModel
    {
    }
}
