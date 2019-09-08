using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreDemo.Entities;

namespace DotNetCoreDemo.Service.Contract
{
    public interface IEmployeeService
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
    }
}
