using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;
using DotNetCoreDemo.Repository.Contract;

namespace DotNetCoreDemo.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Employee Add(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            var employee = dbContext.Employees.Find(Id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return dbContext.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return dbContext.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = dbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return employeeChanges;

        }
    }
}
