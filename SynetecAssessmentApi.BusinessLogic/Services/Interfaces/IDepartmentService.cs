using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentViewModel> GetById(int departmentId);
    }
}
