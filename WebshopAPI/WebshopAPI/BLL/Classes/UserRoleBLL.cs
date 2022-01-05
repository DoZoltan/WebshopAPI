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

        public async Task<bool> CreateRole(CreateRoleRequestDTO roleRequest)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleRequest.RoleName,
            };

            var identityResult = await _roleManager.CreateAsync(identityRole);

            return identityResult.Succeeded;
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

        public async Task<bool> EditRole(EditRoleRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleNameToEdit);

            if (foundRole == null)
            {
                return false;
            }

            foundRole.Name = roleRequest.NewRoleName;

            var updateResult = await _roleManager.UpdateAsync(foundRole);

            return updateResult.Succeeded;
        }

        public async Task<ModifyUserRolesResponseDTO> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleName);
            var foundUser = await _userManager.FindByNameAsync(roleRequest.UserName);

            if (foundRole == null || foundUser == null)
            {
                return new ModifyUserRolesResponseDTO(false, $"The user ({roleRequest.UserName}) or the role ({roleRequest.RoleName}) not exists");
            }

            if (await _userManager.IsInRoleAsync(foundUser, foundRole.Name))
            {
                return new ModifyUserRolesResponseDTO(false, $"The user ({roleRequest.UserName}) already have this role");
            }

            var addRoleResult = await _userManager.AddToRoleAsync(foundUser, foundRole.Name);

            if (addRoleResult.Succeeded)
            {
                return new ModifyUserRolesResponseDTO(addRoleResult.Succeeded, $"The {roleRequest.RoleName} role was applied to {roleRequest.UserName} user");
            }
            
            return new ModifyUserRolesResponseDTO(addRoleResult.Succeeded, "Something went wrong during the procedure");
        }

        public async Task<ModifyUserRolesResponseDTO> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var foundRole = await _roleManager.FindByNameAsync(roleRequest.RoleName);
            var foundUser = await _userManager.FindByNameAsync(roleRequest.UserName);

            if (foundRole == null || foundUser == null)
            {
                return new ModifyUserRolesResponseDTO(false, $"The user ({roleRequest.UserName}) or the role ({roleRequest.RoleName}) not exists");
            }

            if (await _userManager.IsInRoleAsync(foundUser, foundRole.Name))
            {
                return new ModifyUserRolesResponseDTO(false, $"The user ({roleRequest.UserName}) don't have this role");
            }

            var addRoleResult = await _userManager.RemoveFromRoleAsync(foundUser, foundRole.Name);

            if (addRoleResult.Succeeded)
            {
                return new ModifyUserRolesResponseDTO(addRoleResult.Succeeded, $"The {roleRequest.RoleName} role was removed from {roleRequest.UserName} user");
            }

            return new ModifyUserRolesResponseDTO(addRoleResult.Succeeded, "Something went wrong during the procedure");
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
    }
}
