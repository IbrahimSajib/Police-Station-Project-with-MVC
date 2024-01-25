#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Police_Station.Models.RoleManagement
{
    public class RoleVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
