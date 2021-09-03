using AutoMapper;
using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.DataAccess.DTO;
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
            CreateMap<Employee, EmployeeWithDepartmentViewModel>();

            CreateMap<EmployeeFinanceSummary, EmployeeFinanceSummaryViewModel>();
        }
    }
}
