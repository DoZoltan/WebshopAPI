using System.Collections.Generic;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class UserDataChangeResponseDTO
    {
        public UserDataChangeResponseDTO(bool succeeded, List<string> messages)
        {
            Succeeded = succeeded;
            Messages = messages;
        }

        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; }
    }
}
