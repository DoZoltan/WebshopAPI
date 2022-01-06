using System.Collections.Generic;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class AuthenticationResponseDTO
    {
        public AuthenticationResponseDTO(bool succeeded, List<string> messages, User user)
        {
            Succeeded = succeeded;
            Messages = messages;
            User = user;
        }

        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
        public User User { get; set; }
    }
}
