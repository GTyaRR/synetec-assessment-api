
namespace SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels
{
    public class EmployeeFinanceSummaryViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeJobTitle { get; set; }
        public int Salary { get; set; }
        public string SalaryPercentage { get; set; }
        public decimal BonusAmount { get; set; }
        public string EmployeeDepartmentTitle { get; set; }
    }
}
