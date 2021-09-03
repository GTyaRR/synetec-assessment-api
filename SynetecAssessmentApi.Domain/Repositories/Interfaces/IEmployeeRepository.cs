using SynetecAssessmentApi.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> FindById(int id);
        Task<Employee> GetWithDepartment(int employeeId);
        IEnumerable<Employee> GetList();
        IEnumerable<Employee> GetListWithDepartments();
        IEnumerable<Employee> GetListByDepartment(int departmentId);
    }
}
