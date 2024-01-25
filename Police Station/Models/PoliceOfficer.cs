using System.ComponentModel.DataAnnotations;

namespace Police_Station.Models
{
    public class PoliceOfficer
    {
        public int PoliceOfficerId { get; set; }
        [Required]
        public int? BadgeNumber { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yyyy-MMM-dd}",ApplyFormatInEditMode =true)]
        public DateTime? DateOfBirth { get; set; }
        public string Rank { get; set; } = default!;
        public string BadgeType { get; set; } = default!;
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoinDate { get; set; } = default!;
        public double? Salary { get; set; }
        public string Shift { get; set; } = default!;
        public string Supervisor {  get; set; } = default!; 
        public string Department {  get; set; } = default!; 
        public virtual ICollection<InvestigationInfo> InvestigationInfos { get; set; }=new List<InvestigationInfo>();
    }
}
