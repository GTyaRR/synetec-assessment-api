using AutoMapper;
using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.DataAccess.Entities;

namespace SynetecAssessmentApi.BusinessLogic.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<Department, DepartmentWithEmployeesViewModel>()
                .ForMember(d => d.DepartmentEmployees, o => o.MapFrom(s => s.Employees));

            CreateMap<Employee, EmployeeViewModel>();
        }
    }
}
