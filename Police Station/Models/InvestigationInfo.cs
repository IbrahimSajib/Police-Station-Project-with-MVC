using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.ComponentModel;
namespace Police_Station.Models
{
    public class InvestigationInfo
    {
        public int InvestigationInfoId { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Required]
        public string Status { get; set; } = default!;
        public string Location { get; set; } = default!;
        public string Details { get; set; } = default!;
        [ForeignKey("CaseApplication")]
        public int? CaseApplicationId { get; set; }
        [ForeignKey("PoliceOfficer"),DisplayName("Police Officer")]
        public int? PoliceOfficerId { get; set; }
        public virtual CaseApplication? CaseApplication { get; set; }
        public virtual PoliceOfficer? PoliceOfficer { get; set; } 
    }
}
