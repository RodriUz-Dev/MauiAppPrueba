﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string EntryDate { get; set; }
        public decimal Salary { get; set; }
        public string ImageUrl { get; set; }
    }
}
