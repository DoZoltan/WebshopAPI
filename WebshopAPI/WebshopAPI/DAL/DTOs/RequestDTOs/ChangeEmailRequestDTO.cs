using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ChangeEmailRequestDTO
    {
        [Required]
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}
