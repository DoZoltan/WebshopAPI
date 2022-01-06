using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs.RequestDTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IUserRoleBLL
    {
        Task<ModifyRolesResponseDTO> CreateRole(CreateOrDeleteRoleRequestDTO roleRequest);
        IEnumerable<string> GetRoles();
        Task<ModifyRolesResponseDTO> EditRole(EditRoleRequestDTO roleRequest);
        Task<ModifyRolesResponseDTO> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest);
        Task<GetUsersByRoleResponseDTO> GetUsersByRole(string roleName);
        Task<GetRolesByUserNameResponseDTO> GetRolesByUser(string userName);
        Task<ModifyRolesResponseDTO> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest, ClaimsPrincipal user);
        Task<ModifyRolesResponseDTO> RemoveRole(CreateOrDeleteRoleRequestDTO roleRequest);
    }
}
