using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Entities;
using SynetecAssessmentApi.DataAccess.Repositories.Base;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<Employee> GetWithDepartment(int employeeId)
        {
            var entity = await _context.Employees
                .AsNoTracking()
                .Where(w => w.Id == employeeId)
                .Include(i => i.Department)
                .FirstOrDefaultAsync();
            return entity;
        }
        public IEnumerable<Employee> GetList()
        {
            var employees = _context.Employees
                .AsNoTracking()
                .OrderBy(o => o.Fullname);
            return employees;
        }
        public IEnumerable<Employee> GetListWithDepartments()
        {
            var employeesWithDepartments = _context.Employees
                .AsNoTracking()
                .Include(i => i.Department)
                .OrderByDescending(o => o.Fullname);
            return employeesWithDepartments;
        }
        public IEnumerable<Employee> GetListByDepartment(int departmentId)
        {
            var employeesByDepartment = _context.Employees
                .AsNoTracking()
                .Include(i => i.Department)
                .Where(w => w.DepartmentId == departmentId)
                .OrderByDescending(o => o.Fullname);
            return employeesByDepartment;
        }
    }
}
