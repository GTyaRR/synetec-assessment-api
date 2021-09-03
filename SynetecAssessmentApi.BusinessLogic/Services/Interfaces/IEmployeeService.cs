using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetById(int employeeId);
        Task<EmployeeWithDepartmentViewModel> GetByIdWithDepartment(int employeeId);
        List<EmployeeViewModel> GetList();
        List<EmployeeViewModel> GetListByDepartment(int departmentId);
        List<EmployeeWithDepartmentViewModel> GetListWithDepartments();
    }
}
