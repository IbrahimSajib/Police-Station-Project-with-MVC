#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Police_Station.Models.UserManagement
{
    public class UserVM
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
