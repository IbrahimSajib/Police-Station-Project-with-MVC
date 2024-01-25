using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata;
#nullable disable

namespace Police_Station.Models
{
    public class CaseApplication
    {
        public int CaseApplicationId { get; set; }
        //Victim Info
        [Required,DisplayName("Victim Name")]
        public string VictimName { get; set;}
        [Required,DisplayName("Victim Age")]
        public int? VictimAge { get; set;}
        [Required, DisplayName("Victim Address")]
        public string VictimAddress { get; set;}
        [Required, DisplayName("Victim Profession")]
        public string VictimProfession { get; set;}
        [Required, DisplayName("Victim Gender")]
        public string? VictimGender { get; set; }
        [Required, DisplayName("Victim Marital Status")]
        public string? VictimMaritalStatus { get; set;}
        [DisplayName("Victim NID")]
        public long? VictimNID { get; set;}
        [Required, DisplayName("Victim PhoneNo")]
        public string VictimPhoneNo { get; set;}
        [DisplayName("Crime Spot")]
        public string CrimeSpot { get; set;}
        //Suspect Info
        [DisplayName("Suspect Name")]
        public string SuspectName { get; set; }
        [DisplayName("Suspect Age")]
        public int? SuspectAge { get; set; }
        [DisplayName("Suspect Address")]
        public string SuspectAddress { get; set; }
        [DisplayName("Suspect Gender")]
        public string? SuspectGender { get; set; }
        [DisplayName("Suspect Profession")]
        public string SuspectProfession { get; set; }
        [DisplayName("Suspect PhoneNo")]
        public string SuspectPhoneNo { get; set; }

        //Witness Info
        [DisplayName("Witness Name")]
        public string WitnessName { get; set; }
        [DisplayName("Witness Age")]
        public int? WitnessAge { get; set; }
        [DisplayName("Witness Address")]
        public string WitnessAddress { get; set; }
        [DisplayName("Witness Gender")]
        public string? WitnessGender { get; set; }
        [DisplayName("Witness Profession")]
        public string WitnessProfession { get; set; }
        [DisplayName("Witness PhoneNo")]
        public string WitnessPhoneNo { get; set; }

        
        //public virtual Criminal? Criminal { get; set; }
    }
}