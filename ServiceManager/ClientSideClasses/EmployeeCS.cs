﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.ClientSideClasses
{
    public class EmployeeCS
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string DocSeries { get; set; }
        public string DocNumber { get; set; }
        public string Position { get; set; }
        public System.Guid DepartmentID { get; set; }

        public DepartmentCS Department { get; set; }
    }
}