using System.Collections.Generic;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class AuthenticationResponseDTO
    {
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
        public User User { get; set; }
    }
}
