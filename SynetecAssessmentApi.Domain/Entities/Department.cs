using System.Collections.Generic;

namespace SynetecAssessmentApi.DataAccess.Entities
{
    public class Department : Base.Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
