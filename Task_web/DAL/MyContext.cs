using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_web.DAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<TestModel> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().HasData(new TestModel
            {
                Id = Guid.NewGuid(),
                Name = "Bob",
                
            }, new TestModel
            {
                Id = Guid.NewGuid(),
                Name = "David",
                
            });
        }
    }

}