using Microsoft.EntityFrameworkCore;
using System;
using TestApp.Data.Configurations;
using TestApp.Domain;

namespace TestApp.Data
{
    public class TestAppContext : DbContext
    {
        public TestAppContext(DbContextOptions<TestAppContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserDomainConfiguration());
        }
    }
}
