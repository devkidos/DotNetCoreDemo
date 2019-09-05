using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreDemo.Repository.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "Demo1",
                   Email = "demo1@demo.com"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Demo2",
                   Email = "demo2@demo.com"
               }
            );
        }
    }
}
