using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ChangeUserNameRequestDTO
    {
        [Required]
        public string NewUserName { get; set; }
    }
}
