using System.Collections.Generic;

namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class ModifyRolesResponseDTO
    {
        public ModifyRolesResponseDTO(bool succeeded, string responseMessage)
        {
            Succeeded = succeeded;
            ResponseMessage = responseMessage;
        }

        public ModifyRolesResponseDTO(bool succeeded, IEnumerable<string> responseMessages)
        {
            Succeeded = succeeded;
            ResponseMessages = responseMessages;
        }

        public bool Succeeded { get; set; }
        public string ResponseMessage { get; set; }
        public IEnumerable<string> ResponseMessages { get; set; }
    }
}
