using System.ComponentModel.DataAnnotations;

namespace SynetecAssessmentApi.BusinessLogic.ViewModels.RequestModels
{
    public class BonusPoolRequestModel
    {
        [Required]
        public int SelectedEmployeeId { get; set; }
        [Required]
        public int BonusPoolAmount { get; set; }
    }
}
