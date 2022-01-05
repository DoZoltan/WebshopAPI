using System.Collections.Generic;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class GetUsersByRoleResponseDTO
    {
        public GetUsersByRoleResponseDTO(bool succeeded, IEnumerable<User> foundUsers, string responseMessage)
        {
            Succeeded = succeeded;
            FoundUsers = foundUsers;
            ResponseMessage = responseMessage;
        }

        public bool Succeeded { get; set; }
        public IEnumerable<User> FoundUsers { get; set; }
        public string ResponseMessage { get; set; }
    }
}
