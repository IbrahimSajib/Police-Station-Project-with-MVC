using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace Police_Station.Models
{
    public class Criminal
    {
        public int CriminalId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Status { get; set; }
        [ForeignKey("CaseApplication")]
        public int? CaseApplicationId { get; set; }
        public virtual CaseApplication? CaseApplication  { get; set; }
    }
}
