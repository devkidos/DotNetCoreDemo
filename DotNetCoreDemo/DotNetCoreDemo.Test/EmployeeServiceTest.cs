using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetCoreDemo.Entities;
using DotNetCoreDemo.Repository.Contract;
using DotNetCoreDemo.Service.Contract;
using DotNetCoreDemo.Service.Services;
using Moq;
using NUnit.Framework;

namespace DotNetCoreDemo.Test
{
    public class EmployeeServiceTest
    {
        IEmployeeService employeeService;
        public Mock<IEmployeeRepository> mockEmployeeRepository;
        
        [OneTimeSetUp]
        public void Init()
        {
            mockEmployeeRepository = new Mock<IEmployeeRepository>();
            employeeService = new EmployeeService( this.mockEmployeeRepository.Object);
        }
  
        [Test, TestCaseSource("employeeSource")]
        public void GetEmployeeList_Return_True(Employee[] employees)
        {
            //Init            
            mockEmployeeRepository.Setup(p => p.GetAllEmployee()).Returns(employees.AsQueryable().ToList());
            
            //Act
            List<Employee> result  = employeeService.GetAllEmployee().ToList();

            ////Assert
            Assert.Greater(result.Count, 0);
        }

        [Test, TestCaseSource("employeeSourceNull")]
        public void GetEmployeeList_NoData_Return_True(Employee[] employees)
        {
            //Init            
            mockEmployeeRepository.Setup(p => p.GetAllEmployee()).Returns(employees.AsQueryable().ToList());

            //Act
            List<Employee> result = employeeService.GetAllEmployee().ToList();

            ////Assert
            Assert.AreEqual(result.Count, 0);
        }

        static object[] employeeSource =
        {
            new object[]
            {
                new Employee[]
                {
                    new Employee()
                    {
                        Id = 1, Name = "demo1", Email = "demo1@demo.com"
                    },
                    new Employee()
                    {
                        Id = 2, Name = "demo2", Email = "demo2@demo.com"
                    }
                } 
            }
        };
        static object[] employeeSourceNull =
        {
            new object[]
            {
                new Employee[]
                {
                    
                }
            }
        };
    }
}
