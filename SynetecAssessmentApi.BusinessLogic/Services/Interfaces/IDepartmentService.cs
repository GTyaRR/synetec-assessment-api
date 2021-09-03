using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentViewModel> GetById(int departmentId);
        Task<DepartmentWithEmployeesViewModel> GetByIdWithEmployees(int departmentId);
        List<DepartmentViewModel> GetList();
        List<DepartmentWithEmployeesViewModel> GetListWithEmployees();
    }
}
