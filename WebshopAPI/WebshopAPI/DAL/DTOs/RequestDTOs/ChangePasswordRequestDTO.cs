using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class ChangePasswordRequestDTO
    {
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=\-!*()@%&]).{6,}$", 
            ErrorMessage = "Min 6 characters. " +
            "At least one number. " +
            "At least one upper case. " +
            "At least one lower case. " +
            "At least one special character.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
