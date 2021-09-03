using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.Entities;
using SynetecAssessmentApi.DataAccess.Repositories.Base;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.DataAccess.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public async Task<Department> GetWithEmployees(int departmentId)
        {
            var entity = await _context.Departments
                .AsNoTracking()
                .Where(w => w.Id == departmentId)
                .Include(i => i.Employees)
                .FirstOrDefaultAsync();
            return entity;
        }

        public IEnumerable<Department> GetList()
        {
            var departments = _context.Departments
                .AsNoTracking()
                .OrderBy(o => o.Title);
            return departments;
        }
        public IEnumerable<Department> GetListWithEmployees()
        {
            var departmentsWithEmployees = _context.Departments
                .AsNoTracking()
                .Include(i => i.Employees)
                .OrderByDescending(o => o.Title);
            return departmentsWithEmployees;
        }
    }
}
