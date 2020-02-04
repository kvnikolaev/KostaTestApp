using System;
using System.Linq;
using DALService;
using DALService.DTO;
using DALService.EDM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Position = "coolGuy"
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
}
