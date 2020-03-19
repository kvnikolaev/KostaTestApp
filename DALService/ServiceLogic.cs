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
                var t = db.Department.Include(el => el.Employee).Where(d => !(d.ParentDepartmentID.HasValue)).AsNoTracking().ToList();
                var result = mapper.Map<IEnumerable<Department_dto>>(t);
                return result;
            }
        }

        public IEnumerable<Employee_dto> GetEmployeesByDepartment(Guid departmentID)
        {
            using (var db = new TestDBEntities())
            {
                var t = db.Set<Employee>().Where(e => e.DepartmentID == departmentID).AsNoTracking()
                    .ProjectTo<Employee_dto>(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()))
                    .ToArray();
                return t;
            }
        }

        public int AddEmployee(Employee_dto employee)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Employee>(employee);
                db.Set<Employee>().Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
        }

        public Guid AddDepartment(Department_dto department)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Department>(department);
                entity.ID = Guid.NewGuid();
                db.Set<Department>().Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
        }

        public void EditEmployee(Employee_dto employee)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Employee>(employee);

                var originalEntity = db.Set<Employee>().Where(el => el.ID == entity.ID).SingleOrDefault();
                if (originalEntity == null) throw new InvalidOperationException("Record is not found in storage");

                db.Entry(originalEntity).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }

        public void EditDepartment(Department_dto department)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Department>(department);

                var originalEntity = db.Set<Department>().Where(el => el.ID == entity.ID).SingleOrDefault();
                if (originalEntity == null) throw new InvalidOperationException("Record is not found in storage");

                db.Entry(originalEntity).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(Employee_dto employee)
        {
            using (var db = new TestDBEntities())
            {
                var entity = mapper.Map<Employee>(employee);

                db.Set<Employee>().Attach(entity);
                var t = db.Set<Employee>().Remove(entity);
                db.SaveChanges();
            }
        }

        public void DeleteDepartment(Department_dto department)
        {
            using (var db = new TestDBEntities())
            {
                var entity = db.Set<Department>().Where(el => el.ID == department.ID).SingleOrDefault();

                var t = db.Set<Department>().Remove(entity);
                db.SaveChanges();
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
