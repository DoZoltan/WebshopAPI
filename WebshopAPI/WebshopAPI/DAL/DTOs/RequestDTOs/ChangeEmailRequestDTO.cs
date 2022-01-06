using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ChangeEmailRequestDTO
    {
        [Required]
        [RegularExpression(@"^(?=.*\.)(?=.*@).{8,}$", ErrorMessage = "Min 8 characters and have to contain @ and . characters")]
        public string NewEmail { get; set; }
    }
}
