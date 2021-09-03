using Moq;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using AutoMapper;
using SynetecAssessmentApi.BusinessLogic.Services;
using SynetecAssessmentApi.DataAccess.Entities;

namespace SynetecAssessmentApi.Tests
{
    public class FinanceControllerTests
    {
        [Fact]
        public async Task IndexViewDataMessage()
        {
            var requestModel = new BonusPoolRequestModel();
            requestModel.BonusPoolAmount = 80000;
            requestModel.SelectedEmployeeId = 1;

            var employee = new Employee() { Id = 1, Fullname = "John Smith", JobTitle = "Accountant (Senior)", Salary = 60000, DepartmentId = 1 };
            int totalSalary = 654750;

            var employeeRepository = new Mock<IEmployeeRepository>();
            var mapper = Mock.Of<IMapper>();

            employeeRepository.Setup(x => x.FindById(requestModel.SelectedEmployeeId)).Returns(Task.FromResult(employee));
            employeeRepository.Setup(x => x.GetTotalSalary()).Returns(Task.FromResult(totalSalary));

            var financeService = new FinanceService(employeeRepository.Object, mapper);
            var result = await financeService.GetEmployeeBonusPool(requestModel);

            var actualResult = new BonusPoolViewModel();
            actualResult.Amount = 7331;
            actualResult.Employee = new EmployeeViewModel()
            {
                Fullname = "John2 Smith",
                JobTitle = "Accountant (Senior)",
                Salary = 6000,
                DepartmentId = 2
            };

            Assert.Equal(result.Amount.ToString(), actualResult.Amount.ToString());
        }
    }
}
    