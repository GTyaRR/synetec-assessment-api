using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.DepartmentModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    /// <summary>
    /// API for department summary.
    /// </summary>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Internal Server Error.</response>
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Get department by id.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("Get/{departmentId}")]
        [ProducesResponseType(typeof(DepartmentViewModel), 200)]
        public async Task<IActionResult> Get(int departmentId)
        {
            var departmentModel = await _departmentService.GetById(departmentId);
            return Ok(departmentModel);
        }

        /// <summary>
        /// Get department by id with employees.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet("GetWithEmployees/{departmentId}")]
        [ProducesResponseType(typeof(DepartmentWithEmployeesViewModel), 200)]
        public async Task<IActionResult> GetWithEmployees(int departmentId)
        {
            var departmentModel = await _departmentService.GetByIdWithEmployees(departmentId);
            return Ok(departmentModel);
        }

        /// <summary>
        /// Get all departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(typeof(List<DepartmentViewModel>), 200)]
        public IActionResult GetList()
        {
            var departments = _departmentService.GetList();
            return Ok(departments);
        }

        /// <summary>
        /// Get all departments with employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListWithEmployees")]
        [ProducesResponseType(typeof(List<DepartmentWithEmployeesViewModel>), 200)]
        public IActionResult GetListWithEmployees()
        {
            var departments = _departmentService.GetListWithEmployees();
            return Ok(departments);
        }
    }
}
