using System.Collections.Generic;
using System.Threading.Tasks;
using WebshopAPI.DAL.DTOs.RequestDTOs;
using WebshopAPI.DAL.DTOs.ResponseDTOs;
using WebshopAPI.DAL.Models;

namespace WebshopAPI.BLL.Interfaces
{
    public interface IUserRoleBLL
    {
        Task<bool> CreateRole(CreateRoleRequestDTO roleRequest);
        IEnumerable<string> GetRoles();
        Task<bool> EditRole(EditRoleRequestDTO roleRequest);
        Task<ModifyUserRolesResponseDTO> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest);
        Task<GetUsersByRoleResponseDTO> GetUsersByRole(string roleName);
        Task<GetRolesByUserNameResponseDTO> GetRolesByUser(string userName);
        Task<ModifyUserRolesResponseDTO> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest);
    }
}
