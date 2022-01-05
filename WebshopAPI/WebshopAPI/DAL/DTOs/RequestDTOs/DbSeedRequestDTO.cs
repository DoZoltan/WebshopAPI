using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class DbSeedRequestDTO
    {
        [Required]
        public string SeedPassword { get; set; }
    }
}
