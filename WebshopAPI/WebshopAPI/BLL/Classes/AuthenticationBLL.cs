using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Classes
{
    public class AuthenticationBLL : IAuthenticationBLL
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationBLL(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDataChangeResponseDTO> ChangeEmail(ChangeEmailRequestDTO requestDTO, User user)
        {
            user.Email = requestDTO.NewEmail;
            // új email-t is meg kellene erősíteni (ha kellene megerősítés)?

            var UpdateResult = await _userManager.UpdateAsync(user);

            if (UpdateResult.Succeeded)
            {
                return new UserDataChangeResponseDTO(UpdateResult.Succeeded, new List<string>() { "Email has been successfully changed" });
            }

            var errorListDuringUpdateUser = new List<string>();

            foreach (var error in UpdateResult.Errors)
            {
                errorListDuringUpdateUser.Add(error.Description);
            }

            return new UserDataChangeResponseDTO(UpdateResult.Succeeded, errorListDuringUpdateUser);
        }

        public async Task<UserDataChangeResponseDTO> ChangePassword(ChangePasswordRequestDTO requestDTO, User user)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, requestDTO.NewPassword);

            var UpdateResult = await _userManager.UpdateAsync(user);

            if (UpdateResult.Succeeded)
            {
                return new UserDataChangeResponseDTO(UpdateResult.Succeeded, new List<string>() { "Password has been successfully changed" });
            }

            var errorListDuringUpdateUser = new List<string>();

            foreach (var error in UpdateResult.Errors)
            {
                errorListDuringUpdateUser.Add(error.Description);
            }

            return new UserDataChangeResponseDTO(UpdateResult.Succeeded, errorListDuringUpdateUser);
        }

        public async Task<UserDataChangeResponseDTO> ChangeUserName(ChangeUserNameRequestDTO requestDTO, User user)
        {
            user.UserName = requestDTO.NewUserName;

            var UpdateResult = await _userManager.UpdateAsync(user);

            if (UpdateResult.Succeeded)
            {
                return new UserDataChangeResponseDTO(UpdateResult.Succeeded, new List<string>() { "User name has been successfully changed" });
            }

            var errorListDuringUpdateUser = new List<string>();

            foreach (var error in UpdateResult.Errors)
            {
                errorListDuringUpdateUser.Add(error.Description);
            }

            return new UserDataChangeResponseDTO(UpdateResult.Succeeded, errorListDuringUpdateUser);
        }

        public async Task<AuthenticationResponseDTO> GetCurrentUserByClaimsPrincipal(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);

            if (currentUser == null)
            {
                return new AuthenticationResponseDTO(false, new List<string>() { "Can't find the user" }, currentUser);
            }

            return new AuthenticationResponseDTO(true, new List<string>() { "The user was found" }, currentUser);
        }

        public async Task<AuthenticationResponseDTO> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return new AuthenticationResponseDTO(false, new List<string>() { $"There is no user with {email} email" }, user);
            }

            return new AuthenticationResponseDTO(true, new List<string>() { $"There is a user with {email} email" }, user);
        }

        public async Task<AuthenticationResponseDTO> GetUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return new AuthenticationResponseDTO(false, new List<string>() { $"There is no user with {userName} name" }, user);
            }

            return new AuthenticationResponseDTO(true, new List<string>() { $"There is a user with {userName} name" }, user);
        }

        public async Task<AuthenticationResponseDTO> Login(UserLoginRequestDTO userDTO, User user)
        {
            var isThePasswordValid = await _userManager.CheckPasswordAsync(user, userDTO.Password);

            if (!isThePasswordValid)
            {
                return new AuthenticationResponseDTO(false, new List<string>() { "Wrong password" }, user);
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var signInresult = await _signInManager.PasswordSignInAsync(user, userDTO.Password, isPersistent: userDTO.RememberMe, false);

            if (signInresult.Succeeded)
            {
                return new AuthenticationResponseDTO(signInresult.Succeeded, new List<string>() { "Successful login" }, user);
            }

            return new AuthenticationResponseDTO(signInresult.Succeeded, new List<string>() { "Something went wrong during login procedure" }, user);
        }

        public async Task LoginAtRegistration(User user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResponseDTO> Registration(RegistrationRequestDTO userDTO)
        {
            var newUser = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.UserName,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                ProfilePicture = userDTO.ProfilePicture,
                BirthDate = userDTO.BirthDate,
                RegistrationDate = DateTime.Now
            };

            var isCreated = await _userManager.CreateAsync(newUser, userDTO.Password);

            if (isCreated.Succeeded)
            {
                return new AuthenticationResponseDTO(isCreated.Succeeded, new List<string>() { $"{newUser.UserName} was successfully registered." }, newUser);
            }
            
            var errorListDuringCreateNewUser = new List<string>();

            foreach (var error in isCreated.Errors)
            {
                errorListDuringCreateNewUser.Add(error.Description);
            }

            return new AuthenticationResponseDTO(isCreated.Succeeded, errorListDuringCreateNewUser, newUser);
        }
    }
}
