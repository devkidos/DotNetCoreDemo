﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreDemo.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
    }
}
