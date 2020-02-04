using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DALService.DTO;
using DALService.EDM;

namespace DALService
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Department, Department_dto>();
            CreateMap<Department_dto, Department>();
            CreateMap<Employee, Employee_dto>();
            CreateMap<Employee_dto, Employee>();
        }
    }
}
