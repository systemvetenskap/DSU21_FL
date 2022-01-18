using DSU21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSU21.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pirate> Pirates { get; set; }
        public DbSet<Ship> Ships { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  {  }
    }
}
