using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DataAccess.DTO;
using SynetecAssessmentApi.DataAccess.Entities;
using SynetecAssessmentApi.DataAccess.Repositories.Base;
using SynetecAssessmentApi.DataAccess.Repositories.Interfaces;
using System;
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
        public async Task<int> GetTotalSalary()
        {
            var totalSalary = await _context.Employees
                .SumAsync(s => s.Salary);
            return totalSalary;
        }

        public async Task<List<EmployeeFinanceSummary>> GetEmployeeFinanceSummary(int bonusPoolAmount)
        {
            int totalSalary = await GetTotalSalary();

            var summaryList = await _context.Employees
                .AsNoTracking()
                .Include(i => i.Department)
                .Select(s => new EmployeeFinanceSummary
                {
                    EmployeeId = s.Id,
                    EmployeeFullName = s.Fullname,
                    EmployeeJobTitle = s.JobTitle,
                    Salary = s.Salary,
                    SalaryPercentage = Math.Round(((decimal)s.Salary/(decimal)totalSalary)*100,2 ) + " %",
                    BonusAmount = Math.Round(bonusPoolAmount * ((decimal)s.Salary/(decimal)totalSalary),2),
                    EmployeeDepartmentTitle = s.Department.Title
                }).ToListAsync();
            return summaryList;
        }
    }
}
