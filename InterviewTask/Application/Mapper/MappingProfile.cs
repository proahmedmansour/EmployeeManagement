using AutoMapper;
using Entities.Model;
using InterviewTask.EmployeeManagement.Dtos;
using System;

namespace InterviewTask.EmployeeManagement.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDetailDto>();

            CreateMap<Department, DepartmentListDto>();

            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(d => d.CreatedTime, opt => opt.MapFrom(_ => DateTime.Now)); //TODO: transfer to be repository level

            CreateMap<UpdateDepartmentDto, Department>();


            CreateMap<Employee, EmployeeDetailDto>();

            CreateMap<Employee, EmployeeListDto>();

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(d => d.CreatedTime, opt => opt.MapFrom(_ => DateTime.Now)); //TODO: transfer to be repository level

            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
