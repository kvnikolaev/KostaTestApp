﻿using System;
using System.Linq;
using DALService;
using DALService.DTO;
using DALService.EDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceManager.ClientSideClasses;

namespace UnitTestProject1
{
    [TestClass]
    public class DataBaseWork
    {
        Employee_dto testEmployee = new Employee_dto()
        {
            DepartmentID = new Guid("FB9D1A43-5796-4190-ABD4-39FFD8C87476"),
            SurName = "testSurName",
            FirstName = "testFirstName",
            DateOfBirth = DateTime.Now,
            Position = "coolGuy",
            DocSeries = "12345"
        };

        [TestMethod]
        public void DBNotEmptyTest()
        {
            using (var db = new TestDBEntities())
            {
                Assert.IsTrue(db.Department.Any() && db.Employee.Any());
            }
        }

        //[TestMethod]
        //public void AddEmployee()
        //{
        //    var t = new ServiceLogic();
        //    t.AddEmployee(testEmployee);
        //}
    }

    [TestClass]
    public class EntityValidation
    {
        [TestMethod]
        public void EmployeeBaseValidate_AllBad()
        {
            // Arrange
            var employee = new EmployeeCS()
            {
                
                DocSeries = "1001lkjdfsa",
                DocNumber = "123456dfrg",
                
                SurName = "Кирилл1234Кирилл1234Кирилл1234Кирилл1234Кирилл1234!",
                Patronymic = "ВалерьевичВалерьевичВалерьевичВалерьевичВалерьевич!",
                Position = "НащальникаНащальникаНащальникаНащальникаНащальника!",
                DepartmentID = Guid.Empty
            };
            // Act
            bool result = false;
            try
            {
                result = employee.Validate();
            }
            catch(AggregateException e)
            {
                // Assert
                Assert.AreEqual(e.InnerExceptions.Count, 8);
                return;
            }
            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void EmployeeBaseValidate_AllGood()
        {
            // Arrange
            var employee = new EmployeeCS()
            {
                DateOfBirth = DateTime.Now,
                DocSeries = "1001",
                DocNumber = "123456",
                FirstName = "Николавев",
                SurName = "Кирилл",
                Patronymic = "Валерьевич",
                Position = "Нащальника",
                DepartmentID = Guid.NewGuid()
            };
            // Act
            bool result = employee.Validate();
            // Assert
            Assert.IsTrue(result);
        }
    }
}
