using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kgc.Models;
using Microsoft.EntityFrameworkCore;

namespace kgc.Data
{
    public class AppDbContext : DbContext
    {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            // Constructor body is empty in this example


        }

         public DbSet<cloudfilesViewModel> cloudfiles { get; set; }
         public DbSet<KGCViewModel> KGC { get; set; }


    }
}