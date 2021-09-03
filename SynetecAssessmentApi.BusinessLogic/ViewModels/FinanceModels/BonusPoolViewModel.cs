using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;

namespace SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels
{
    public class BonusPoolViewModel
    {
        public int Amount { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
