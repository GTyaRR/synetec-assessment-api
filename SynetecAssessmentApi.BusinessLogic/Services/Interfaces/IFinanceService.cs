using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.BusinessLogic.Services.Interfaces
{
    public interface IFinanceService
    {
        Task<BonusPoolViewModel> GetEmployeeBonusPool(BonusPoolRequestModel requestModel);
        Task<List<EmployeeFinanceSummaryViewModel>> GetEmployeeFinanceSummary(int bonusPoolAmount);
    }
}
