using AutoMapper;
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
        private readonly IMapper _autoMapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _autoMapper = mapper;
        }

        public async Task<DepartmentViewModel> GetById(int departmentId)
        {
            var department = await _departmentRepository.FindById(departmentId);
            var departmentModel = _autoMapper.Map<DepartmentViewModel>(department);
            return departmentModel;
        }
        public async Task<DepartmentWithEmployeesViewModel> GetByIdWithEmployees(int departmentId)
        {
            var department = await _departmentRepository.GetWithEmployees(departmentId);
            var departmentModel = _autoMapper.Map<DepartmentWithEmployeesViewModel>(department);
            return departmentModel;
        }
        public List<DepartmentViewModel> GetList()
        {
            var departments = _departmentRepository.GetList();
            var departmentsList = new List<DepartmentViewModel>();

            _autoMapper.Map(departments, departmentsList);

            return departmentsList;
        }
        public List<DepartmentWithEmployeesViewModel> GetListWithEmployees()
        {
            var departments = _departmentRepository.GetListWithEmployees();
            var departmentsList = new List<DepartmentWithEmployeesViewModel>();

            _autoMapper.Map(departments, departmentsList);

            return departmentsList;
        }
    }
}
