using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;

namespace DotNetCoreDemo.Repository.Contract
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
    }
}
