using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;

namespace SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels
{
    public class EmployeeWithDepartmentViewModel
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentViewModel Department { get; set; }
        public EmployeeWithDepartmentViewModel()
        {
            Department = new DepartmentViewModel();
        }
    }
}
