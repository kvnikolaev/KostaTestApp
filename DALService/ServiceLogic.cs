using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Data.Entity;
using DALService.DTO;
using DALService.EDM;

namespace DALService
{
    public class ServiceLogic
    {
        IMapper mapper;
        public ServiceLogic()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            mapper = config.CreateMapper();
        }

        public IEnumerable<Department_dto> GetDepartmentStructureWithEmployees()
        {
            using (var db = new TestDBEntities())
            {
                var t = db.Department.Include(el => el.Employee).Where(d => !(d.ParentDepartmentID.HasValue)).ToList();
                var result = mapper.Map<IEnumerable<Department_dto>>(t);
                return result;
            }
        }

        public int AddEmployee(Employee_dto employee)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Employee>(employee);
                db.Set<Employee>().Add(entity);
                var result = db.SaveChanges();
                return result;
            }
        }

        public int AddDepartment(Department_dto department)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Department>(department);
                entity.ID = Guid.NewGuid();
                db.Set<Department>().Add(entity);
                var result = db.SaveChanges();
                return result;
            }
        }

        public int RemoveEmployee(Employee_dto employee)
        {
            throw new NotImplementedException("Нельзя ничего удалять из бд");
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Employee>(employee);
                db.Set<Employee>().Remove(entity);
                db.SaveChanges();
                return entity.ID;
            }
        }
    }
}
