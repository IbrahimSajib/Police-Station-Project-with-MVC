using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.ComponentModel;

namespace Police_Station.Models
{
    public class ReportAnalysis
    {
        public int ReportAnalysisId { get; set; }
        public string? AnalysisResults { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}")]
        [Display(Name = "Reporting Date")]
        public DateTime? ReportingDate { get; set; }
        public string? Conclusions { get; set; }
        [ForeignKey("CaseApplication")]
        public int? CaseApplicationId { get; set; }
        [ForeignKey("PoliceOfficer"), DisplayName("Police Officer")]
        public int? PoliceOfficerId { get; set; }
        public virtual CaseApplication? CaseApplication { get; set; }
        public virtual PoliceOfficer? PoliceOfficer { get; set; }
    }
}
