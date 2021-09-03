using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
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
        public async Task<DepartmentWithEmployeesViewModel> GetByIdWithEmployees(int departmentId)
        {
            var department = await _departmentRepository.GetWithEmployees(departmentId);
            var departmentModel = new DepartmentWithEmployeesViewModel()
            {
                Id = department.Id,
                Description = department.Description,
                Title = department.Title
            };
            return departmentModel;
        }
        public List<DepartmentViewModel> GetList()
        {
            var departments = _departmentRepository.GetList();
            var departmentsList = new List<DepartmentViewModel>();

            foreach (var department in departments)
            {
                var departmentModel = new DepartmentViewModel()
                {
                    Id = department.Id,
                    Description = department.Description,
                    Title = department.Title
                };
                departmentsList.Add(departmentModel);
            }

            return departmentsList;
        }
        public List<DepartmentWithEmployeesViewModel> GetListWithEmployees()
        {
            var departments = _departmentRepository.GetListWithEmployees();
            var departmentsList = new List<DepartmentWithEmployeesViewModel>();

            foreach (var department in departments)
            {
                var departmentModel = new DepartmentWithEmployeesViewModel()
                {
                    Id = department.Id,
                    Description = department.Description,
                    Title = department.Title
                };
                departmentsList.Add(departmentModel);
            }

            return departmentsList;
        }
    }
}
