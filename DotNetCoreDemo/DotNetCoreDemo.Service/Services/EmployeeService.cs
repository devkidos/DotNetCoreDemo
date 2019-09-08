using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;
using DotNetCoreDemo.Repository.Contract;
using DotNetCoreDemo.Service.Contract;

namespace DotNetCoreDemo.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeRepository.GetAllEmployee(); 
        }

        public Employee GetEmployee(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
