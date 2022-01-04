using System.Collections.Generic;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class UserDataChangeResponseDTO
    {
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
    }
}
