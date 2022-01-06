using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Classes
{
    public class UserRoleBLL : IUserRoleBLL
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserRoleBLL(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<ModifyRolesResponseDTO> CreateRole(CreateOrDeleteRoleRequestDTO roleRequest)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleRequest.RoleName,
            };

            var identityResult = await _roleManager.CreateAsync(identityRole);

            if (identityResult.Succeeded)
            {
                return new ModifyRolesResponseDTO(identityResult.Succeeded, new List<string>() { $"The {roleRequest.RoleName} role was successfully created" });
            }

            var errorsDuringCreateNewRole = new List<string>();

            foreach (var error in identityResult.Errors)
            {
                errorsDuringCreateNewRole.Add(error.Description);
            }

            return new ModifyRolesResponseDTO(identityResult.Succeeded, errorsDuringCreateNewRole);
        }

        public IEnumerable<string> GetRoles()
        {
            var roleNames = new List<string>();
            var roles = _roleManager.Roles;

            foreach (var role in roles)
            {
                roleNames.Add(role.Name);
            }

            return roleNames;
        }

        public async Task<ModifyRolesResponseDTO> EditRole(EditRoleRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleNameToEdit);

            if (foundRole == null)
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The {roleRequest.RoleNameToEdit} role is not exists" });
            }

            foundRole.Name = roleRequest.NewRoleName;

            var updateResult = await _roleManager.UpdateAsync(foundRole);

            if (updateResult.Succeeded)
            {
                return new ModifyRolesResponseDTO(updateResult.Succeeded, new List<string>() { $"The {roleRequest.RoleNameToEdit} role was successfuly modified to {roleRequest.NewRoleName}" });
            }

            var errorsDuringUpdateRole = new List<string>();

            foreach (var error in updateResult.Errors)
            {
                errorsDuringUpdateRole.Add(error.Description);
            }

            return new ModifyRolesResponseDTO(updateResult.Succeeded, errorsDuringUpdateRole);
        }

        public async Task<ModifyRolesResponseDTO> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleName);
            var foundUser = await _userManager.FindByNameAsync(roleRequest.UserName);

            if (foundRole == null || foundUser == null)
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The user ({roleRequest.UserName}) or the role ({roleRequest.RoleName}) not exists" });
            }

            if (await _userManager.IsInRoleAsync(foundUser, foundRole.Name))
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The user ({roleRequest.UserName}) already have this role" });
            }

            var addRoleResult = await _userManager.AddToRoleAsync(foundUser, foundRole.Name);

            if (addRoleResult.Succeeded)
            {
                return new ModifyRolesResponseDTO(addRoleResult.Succeeded, new List<string>() { $"The {roleRequest.RoleName} role was applied to {roleRequest.UserName} user" });
            }
            
            return new ModifyRolesResponseDTO(addRoleResult.Succeeded, new List<string>() { "Something went wrong during the procedure" });
        }

        public async Task<ModifyRolesResponseDTO> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleName);
            var foundUser = await _userManager.FindByNameAsync(roleRequest.UserName);

            if (foundRole == null || foundUser == null)
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The user ({roleRequest.UserName}) or the role ({roleRequest.RoleName}) not exists" });
            }

            var isTheUserHaveThisRole = await _userManager.IsInRoleAsync(foundUser, foundRole.Name);

            if (!isTheUserHaveThisRole)
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The user ({roleRequest.UserName}) don't have this role" });
            }

            var addRoleResult = await _userManager.RemoveFromRoleAsync(foundUser, foundRole.Name);

            if (addRoleResult.Succeeded)
            {
                return new ModifyRolesResponseDTO(addRoleResult.Succeeded, new List<string>() { $"The {roleRequest.RoleName} role was removed from {roleRequest.UserName} user" });
            }

            return new ModifyRolesResponseDTO(addRoleResult.Succeeded, new List<string>() { "Something went wrong during the procedure" });
        }

        public async Task<GetUsersByRoleResponseDTO> GetUsersByRole(string roleName)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleName);

            if (foundRole == null)
            {
                return new GetUsersByRoleResponseDTO(false, new List<User>(), $"The {roleName} role is not exists");
            }

            var usersWithRole = new List<User>();

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, foundRole.Name))
                {
                    usersWithRole.Add(user);
                }
            }

            if (usersWithRole.Count == 0)
            {
                return new GetUsersByRoleResponseDTO(false, new List<User>(), $"There is no user with {roleName} role");
            }

            return new GetUsersByRoleResponseDTO(true, usersWithRole, $"There are users with {roleName} role");
        }

        public async Task<GetRolesByUserNameResponseDTO> GetRolesByUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return new GetRolesByUserNameResponseDTO(false, null, $"There is no user with {userName} name");
            }

            var rolesByUser = await _userManager.GetRolesAsync(user);

            if (!rolesByUser.Any())
            {
                return new GetRolesByUserNameResponseDTO(false, null, $"The {userName} user have no roles");
            }

            return new GetRolesByUserNameResponseDTO(true, rolesByUser, "Roles was found");
        }

        public async Task<ModifyRolesResponseDTO> RemoveRole(CreateOrDeleteRoleRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleName);

            if (foundRole == null)
            {
                return new ModifyRolesResponseDTO(false, new List<string>() { $"The role ({roleRequest.RoleName}) is not exists" });
            }

            var removeResult = await _roleManager.DeleteAsync(foundRole);

            if (removeResult.Succeeded)
            {
                return new ModifyRolesResponseDTO(removeResult.Succeeded, new List<string>() { $"The role ({roleRequest.RoleName}) was successfully deleted" });
            }

            return new ModifyRolesResponseDTO(removeResult.Succeeded, new List<string>() { $"Deleting the role ({roleRequest.RoleName}) is not possible" });
        }
    }
}
