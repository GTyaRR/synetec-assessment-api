using SynetecAssessmentApi.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetWithEmployees(int departmentId);
        IEnumerable<Department> GetList();
        IEnumerable<Department> GetListWithEmployees();
    }
}
