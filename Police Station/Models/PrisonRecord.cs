using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Police_Station.Models
{
    public class PrisonRecord
    {
        public int PrisonRecordId { get; set; }
        [ForeignKey("Criminal")]
        [DisplayName("Criiminal Name")]
        public int? CriminalId { get; set; }
        [ForeignKey("Prison")]
        [DisplayName("Prison")]
        public int? PrisonId { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entry Date")]
        public DateTime? EntryDate { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public string? ReasonForImprisonment { get; set; }

        [Required]
        public string? Status { get; set; }
       
        public virtual Criminal? Criminal { get; set; }
        public virtual Prison? Prison { get; set; }
    }
}
