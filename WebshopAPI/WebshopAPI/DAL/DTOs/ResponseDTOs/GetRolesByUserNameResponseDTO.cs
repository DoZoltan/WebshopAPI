using System.Collections.Generic;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class GetRolesByUserNameResponseDTO
    {
        public GetRolesByUserNameResponseDTO(bool succeeded, IEnumerable<string> foundRoles, string responseMessage)
        {
            Succeeded = succeeded;
            FoundRoles = foundRoles;
            ResponseMessage = responseMessage;
        }

        public bool Succeeded { get; set; }
        public IEnumerable<string> FoundRoles { get; set; }
        public string ResponseMessage { get; set; }
    }
}
}
