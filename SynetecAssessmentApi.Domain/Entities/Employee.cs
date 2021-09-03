
namespace SynetecAssessmentApi.DataAccess.Entities
{
    public class Employee : Base.Base
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
