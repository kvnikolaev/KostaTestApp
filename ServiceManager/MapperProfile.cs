using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServiceManager.ClientSideClasses;
using ServiceManager.DALServiceReference;

namespace ServiceManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Department_dto, DepartmentCS>();
            CreateMap<DepartmentCS, Department_dto>();
            CreateMap<Employee_dto, EmployeeCS>()
                .ForMember(dest => dest.Age, option => option.MapFrom(src => src.GetAge()));
            CreateMap<EmployeeCS, Employee_dto>();
        }
    }
}
