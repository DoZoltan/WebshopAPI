namespace WebshopAPI.DAL.DTOs.ResponseDTOs
{
    public class ModifyUserRolesResponseDTO
    {
        public ModifyUserRolesResponseDTO(bool succeeded, string responseMessage)
        {
            Succeeded = succeeded;
            ResponseMessage = responseMessage;
        }

        public bool Succeeded { get; set; }
        public string ResponseMessage { get; set; }
    }
}
