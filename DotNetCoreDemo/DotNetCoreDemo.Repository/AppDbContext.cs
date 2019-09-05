using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;
using DotNetCoreDemo.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreDemo.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
