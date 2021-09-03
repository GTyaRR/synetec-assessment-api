using AutoMapper;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _autoMapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _autoMapper = mapper;
        }
        public async Task<EmployeeViewModel> GetById(int employeeId)
        {
            var employee = await _employeeRepository.FindById(employeeId);
            var employeeModel = _autoMapper.Map<EmployeeViewModel>(employee);
            return employeeModel;
        }
        public async Task<EmployeeWithDepartmentViewModel> GetByIdWithDepartment(int employeeId)
        {
            var employee = await _employeeRepository.GetWithDepartment(employeeId);
            var employeeModel = _autoMapper.Map<EmployeeWithDepartmentViewModel>(employee);
            return employeeModel;
        }
        public List<EmployeeViewModel> GetList()
        {
            var employees = _employeeRepository.GetList();
            var employeesList = new List<EmployeeViewModel>();
            _autoMapper.Map(employees, employeesList);
            return employeesList;
        }
        public List<EmployeeViewModel> GetListByDepartment(int departmentId)
        {
            var employees = _employeeRepository.GetListByDepartment(departmentId);
            var employeesList = new List<EmployeeViewModel>();
            _autoMapper.Map(employees, employeesList);
            return employeesList;
        }
        public List<EmployeeWithDepartmentViewModel> GetListWithDepartments()
        {
            var employees = _employeeRepository.GetListWithDepartments();
            var employeesList = new List<EmployeeWithDepartmentViewModel>();
            _autoMapper.Map(employees, employeesList);
            return employeesList;
        }
    }
}
