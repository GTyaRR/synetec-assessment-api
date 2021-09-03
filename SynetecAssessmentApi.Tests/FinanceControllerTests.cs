using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels;
using SynetecAssessmentApi.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace SynetecAssessmentApi.Tests
{
    public class FinanceControllerTests
    {
        private readonly IFinanceService _financeService;
        public FinanceControllerTests(IFinanceService financeService)
        {
            _financeService = financeService;
        }
        [Fact]
        public async Task IndexViewDataMessage()
        {
            FinanceController controller = new FinanceController(_financeService);

            var requestModel = new BonusPoolRequestModel();
            requestModel.BonusPoolAmount = 80000;
            requestModel.SelectedEmployeeId = 1;

            var result = await controller.GetEmployeeBonusPool(requestModel) as ViewResult;

            var actualResult = new BonusPoolViewModel();
            actualResult.Amount = 7331;
            actualResult.Employee = new EmployeeViewModel()
            {
                Fullname = "John Smith",
                JobTitle = "Accountant (Senior)",
                Salary = 60000,
                DepartmentId = 1
            };

            var resultData = result?.ViewData.Model;

            Assert.Equal(actualResult, resultData);
        }
    }
}
