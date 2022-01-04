using System.Security.Claims;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs.RequestDTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IAuthenticationBLL
    {
        Task<AuthenticationResponseDTO> Registration(RegistrationRequestDTO userDTO);
        Task LoginAtRegistration(User user);
        Task<AuthenticationResponseDTO> GetUserByEmail(string email);
        Task<AuthenticationResponseDTO> GetUserByUserName(string userName);
        Task<AuthenticationResponseDTO> GetCurrentUserByClaimsPrincipal(ClaimsPrincipal user);
        Task<AuthenticationResponseDTO> Login(UserLoginRequestDTO userDTO, User user);
        Task<UserDataChangeResponseDTO> ChangePassword(ChangePasswordRequestDTO requestDTO, User user);
        Task<UserDataChangeResponseDTO> ChangeEmail(ChangeEmailRequestDTO requestDTO, User user);
        Task<UserDataChangeResponseDTO> ChangeUserName(ChangeUserNameRequestDTO requestDTO, User user);
        Task Logout();

    }
}
