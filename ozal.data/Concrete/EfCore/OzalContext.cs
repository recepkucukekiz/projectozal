using Microsoft.EntityFrameworkCore;
using ozal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ozal.data.Concrete.EfCore
{
    public class OzalContext : DbContext
    {
        public DbSet<Care> Cares { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Status> Statuss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=ozalDb");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\local;Database=ozalDB;Integrated Security=true;");
        }
    }
}
