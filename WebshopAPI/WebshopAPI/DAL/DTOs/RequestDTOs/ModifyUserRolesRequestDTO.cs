using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ModifyUserRolesRequestDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]{3,15}$", ErrorMessage = "3-15 characters without any special character")]
        public string RoleName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{3,55}$", ErrorMessage = "3-55 characters without any special character")]
        public string UserName { get; set; }
    }
}
