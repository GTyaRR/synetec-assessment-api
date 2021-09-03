using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.EmployeesModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    /// <summary>
    /// API for employees summary.
    /// </summary>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Internal Server Error.</response>
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get employee by id.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("Get/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeViewModel), 200)]
        public async Task<IActionResult> Get(int employeeId)
        {
            var employeeModel = await _employeeService.GetById(employeeId);
            return Ok(employeeModel);
        }

        /// <summary>
        /// Get employee by id with department.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("GetWithDepartment/{employeeId}")]
        [ProducesResponseType(typeof(EmployeeWithDepartmentViewModel), 200)]
        public async Task<IActionResult> GetWithDepartment(int employeeId)
        {
            var employeeModel = await _employeeService.GetByIdWithDepartment(employeeId);
            return Ok(employeeModel);
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(List<EmployeeViewModel>), 200)]
        public IActionResult GetList()
        {
            var employees = _employeeService.GetList();
            return Ok(employees);
        }

        /// <summary>
        /// Get all employees by department.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("GetListByDepartments")]
        [ProducesResponseType(typeof(List<EmployeeViewModel>), 200)]
        public IActionResult GetListByDepartments(int departmentId)
        {
            var employees = _employeeService.GetListByDepartment(departmentId);
            return Ok(employees);
        }

        /// <summary>
        /// Get all employees with departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListWithDepartments")]
        [ProducesResponseType(typeof(List<EmployeeWithDepartmentViewModel>), 200)]
        public IActionResult GetListWithDepartments()
        {
            var employees = _employeeService.GetListWithDepartments();
            return Ok(employees);
        }
    }
}
