using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ChangeUserNameRequestDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{3,55}$", ErrorMessage = "3-55 characters without any special character")]
        public string NewUserName { get; set; }
    }
}
