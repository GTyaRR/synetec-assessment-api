using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.BusinessLogic.Services.Interfaces;
using SynetecAssessmentApi.BusinessLogic.ViewModels.FinanceModels;
using SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    /// <summary>
    /// API for finance summary.
    /// </summary>
    /// <response code="200">OK.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Internal Server Error.</response>
    [ApiController]
    [Route("[controller]")]
    public class FinanceController : Controller
    {
        private readonly IFinanceService _financeService;

        public FinanceController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        /// <summary>
        /// Get employee bonus pool.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost("GetEmployeeBonusPool")]
        [ProducesResponseType(typeof(BonusPoolViewModel), 200)]
        public async Task<IActionResult> GetEmployeeBonusPool([FromBody] BonusPoolRequestModel requestModel)
        {
            var response = await _financeService.GetEmployeeBonusPool(requestModel);
            return Ok(response);
        }
    }
}
