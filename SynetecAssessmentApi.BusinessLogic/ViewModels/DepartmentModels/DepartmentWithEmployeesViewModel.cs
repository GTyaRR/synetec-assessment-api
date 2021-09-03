using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using System.Collections.Generic;

namespace SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels
{
    public class DepartmentWithEmployeesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<EmployeeViewModel> DepartmentEmployees { get; set; }
        public DepartmentWithEmployeesViewModel()
        {
            DepartmentEmployees = new List<EmployeeViewModel>();
        }
    }
}
