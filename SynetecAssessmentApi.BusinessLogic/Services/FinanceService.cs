using AutoMapper;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _autoMapper;

        public FinanceService(
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _autoMapper = mapper;
        }

        public async Task<BonusPoolViewModel> GetEmployeeBonusPool(BonusPoolRequestModel requestModel)
        {
            var employee = await _employeeRepository.FindById(requestModel.SelectedEmployeeId);

            if (employee is null)
            {
                throw new ApplicationException("Employee was not found");
            }
            int totalSalary = await _employeeRepository.GetTotalSalary();

            var responseModel = new BonusPoolViewModel();

            //calculate the bonus allocation for the employee
            decimal bonusPercentage = (decimal)employee.Salary / (decimal)totalSalary;

            responseModel.Amount = (int)(bonusPercentage * requestModel.BonusPoolAmount);
            responseModel.Employee = _autoMapper.Map<EmployeeViewModel>(employee);
            return responseModel;
        }
        
        public async Task<List<EmployeeFinanceSummaryViewModel>> GetEmployeeFinanceSummary(int bonusPoolAmount)
        {
            if (bonusPoolAmount <= 0)
            {
                throw new ApplicationException(" Bonus pool amount must be more than 0");
            }

            var employees = await _employeeRepository.GetEmployeeFinanceSummary(bonusPoolAmount);
            if (!employees.Any())
            {
                throw new ApplicationException(" Employees was not found");
            }
            var responseList = new List<EmployeeFinanceSummaryViewModel>();

            _autoMapper.Map(employees, responseList);
            return responseList;
        }
    }
}
