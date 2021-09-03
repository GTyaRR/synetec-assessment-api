using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentViewModel> GetById(int departmentId)
        {
           var department = await _departmentRepository.FindById(departmentId);
            var departmentModel = new DepartmentViewModel() 
            { 
                Id = department.Id, 
                Description = department.Description, 
                Title = department.Title 
            };
            return departmentModel;
        }
    }
}
