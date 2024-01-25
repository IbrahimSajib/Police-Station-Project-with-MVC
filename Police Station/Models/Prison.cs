using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Police_Station.Models
{
    public class Prison
    {
        public int PrisonId { get; set; }
        [Required,DisplayName("Prison Name")]
        public string? PrisonName { get; set; }
        [Required]
        public string? Location { get; set; }
        public int? Capacity { get; set; }
        [Required]
        public string? ContactInfo { get; set; }

        public virtual ICollection<PrisonRecord> PrisonRecords { get; set; } = new List<PrisonRecord>();
    }
}
