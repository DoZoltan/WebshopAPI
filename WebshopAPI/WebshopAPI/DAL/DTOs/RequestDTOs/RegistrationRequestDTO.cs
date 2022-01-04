using System;
using System.ComponentModel.DataAnnotations;

namespace WebshopAPI.DAL.DTOs.RequestDTOs
{
    public class RegistrationRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\.)(?=.*@).{8,}$", ErrorMessage = "Min 8 characters and have to contain @ and . characters")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=\-!*()@%&]).{6,}$",
            ErrorMessage = "Min 6 characters. " +
            "At least one number. " +
            "At least one upper case. " +
            "At least one lower case. " +
            "At least one special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
