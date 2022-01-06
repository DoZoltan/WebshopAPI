using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class EditRoleRequestDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]{3,15}$", ErrorMessage = "3-15 characters without any special character")]
        public string RoleNameToEdit { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{3,15}$", ErrorMessage = "3-15 characters without any special character")]
        public string NewRoleName { get; set; }
    }
}
