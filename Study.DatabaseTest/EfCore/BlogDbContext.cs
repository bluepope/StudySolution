using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.EfCore
{
    public class BlogDbContext : DbContext
    {
        public DbSet<BlogModel>? Blogs { get; set; }
        public DbSet<PostModel>? Posts { get; set; }

        public DbSet<SampleModel>? Samples { get; set; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=nas.hyunmo.net;Database=Test;User Id=test;Password=test1234;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
