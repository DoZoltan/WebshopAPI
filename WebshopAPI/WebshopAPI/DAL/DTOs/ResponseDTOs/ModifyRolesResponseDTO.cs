namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class ModifyRolesResponseDTO
    {
        public ModifyRolesResponseDTO(bool succeeded, string responseMessage)
        {
            Succeeded = succeeded;
            ResponseMessage = responseMessage;
        }

        public bool Succeeded { get; set; }
        public string ResponseMessage { get; set; }
    }
}
