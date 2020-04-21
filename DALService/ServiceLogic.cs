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
using NLog;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using DALService.ServiceFaults;

namespace DALService
{
    public class ServiceLogic
    {
        IMapper mapper;
        Logger _loger;
        public ServiceLogic()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            mapper = config.CreateMapper();

            _loger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<Department_dto> GetDepartmentStructureWithEmployees(string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var t = db.Department.Include(el => el.Employee).Where(d => !(d.ParentDepartmentID.HasValue)).AsNoTracking().ToList();
                    var result = mapper.Map<IEnumerable<Department_dto>>(t);

                    _loger.Info("Запрошена структура предприятий. Строка подключения: " + db.Database.Connection.ConnectionString);
                    return result;
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема запроса структуры подразделений.");
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время запроса структуры подразделений произошла ошибка.");
                throw;
            }
        }

        public IEnumerable<Employee_dto> GetEmployeesByDepartment(Guid departmentID, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var t = db.Set<Employee>().Where(e => e.DepartmentID == departmentID).AsNoTracking()
                        .ProjectTo<Employee_dto>(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()))
                        .ToArray();

                    _loger.Info("Запрошен список сотрудников подразделения " + departmentID + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                    return t;
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема при получении списка сотрудников по GUID подразделения: " + departmentID);
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время получения сотрудников подразделения произошла ошибка.");
                throw;
            }
        }

        public int AddEmployee(Employee_dto employee, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = mapper.Map<Employee>(employee);
                    db.Set<Employee>().Add(entity);
                    db.SaveChanges();

                    _loger.Info("Добавлен сотрудник " + entity.ID + " в подразделение " + employee.DepartmentID + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                    return entity.ID;
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема добавления сотрудника " + employee.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время добавления сотрудника что-то пошло совсем не так.");
                throw;
            }
        }

        public Guid AddDepartment(Department_dto department, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = mapper.Map<Department>(department);
                    entity.ID = Guid.NewGuid();
                    db.Set<Department>().Add(entity);
                    db.SaveChanges();

                    _loger.Info("Добавлено подразделение " + entity.ID + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                    return entity.ID;
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема добавления подразделения " + department.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время добавления подразделения что-то пошло совсем не так.");
                throw;
            }
        }

        public void EditEmployee(Employee_dto employee, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = mapper.Map<Employee>(employee);

                    var originalEntity = db.Set<Employee>().Where(el => el.ID == entity.ID).SingleOrDefault();
                    if (originalEntity == null) throw new InvalidOperationException("Record is not found in storage");

                    db.Entry(originalEntity).CurrentValues.SetValues(entity);
                    db.SaveChanges();

                    _loger.Info("Отредактирован сотрудник " + employee.ID + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема редактирования сотрудника " + employee.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время редактирования сотрудника что-то пошло совсем не так.");
                throw;
            }
        }

        public void EditDepartment(Department_dto department, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = mapper.Map<Department>(department);

                    var originalEntity = db.Set<Department>().Where(el => el.ID == entity.ID).SingleOrDefault();
                    if (originalEntity == null) throw new InvalidOperationException("Record is not found in storage");

                    db.Entry(originalEntity).CurrentValues.SetValues(entity);
                    db.SaveChanges();

                    _loger.Info("Отредактировано подразделение " + department.ID + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема редактирования подразделения " + department.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время редактирования подразделения что-то пошло совсем не так.");
                throw;
            }
        }

        public void DeleteEmployee(Employee_dto employee, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = mapper.Map<Employee>(employee);

                    db.Set<Employee>().Attach(entity);
                    var t = db.Set<Employee>().Remove(entity);
                    db.SaveChanges();

                    _loger.Info("Удален сотрудник " + employee.ToJson() + ". Строка подключения: " + db.Database.Connection.ConnectionString); ;
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема удаления сотрудника " + employee.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время удаления сотрудника что-то пошло совсем не так.");
                throw;
            }
        }

        public void DeleteDepartment(Department_dto department, string connectionString)
        {
            try
            {
                using (var db = TestDBEntities.FactoryMethod(connectionString))
                {
                    var entity = db.Set<Department>().Where(el => el.ID == department.ID).SingleOrDefault();

                    var t = db.Set<Department>().Remove(entity);
                    db.SaveChanges();

                    _loger.Info("Удалено подразделение " + department.ToJson() + ". Строка подключения: " + db.Database.Connection.ConnectionString);
                }
            }
            catch (DataException ex)
            {
                _loger.Warn(ex, "Проблема удаления подразделения " + department.ToJson());
                var fault = GetExceptionMessage(ex);
                throw new FaultException<DefaultFault>(fault);
            }
            catch (Exception ex)
            {
                _loger.Error(ex, "Во время удаления подразделения что-то пошло совсем не так.");
                throw;
            }
        }

        private DefaultFault GetExceptionMessage(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(ex.Message);
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                builder.Append(Environment.NewLine);
                builder.Append("-->");
                builder.Append(innerException.Message);
                innerException = innerException.InnerException;
            }
            return new DefaultFault(builder.ToString());
        }

        [Obsolete]
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
