using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        public IUserRoleBLL _UserRoleBLL { get; set; }

        public UserRoleController(IUserRoleBLL UserRoleBLL)
        {
            _UserRoleBLL = UserRoleBLL;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleRequestDTO roleRequest)
        {
            var isCreatingWasSuccessful = await _UserRoleBLL.CreateRole(roleRequest);

            if (isCreatingWasSuccessful)
            {
                return Ok($"The {roleRequest.RoleName} role has been successfully created");
            }

            return BadRequest($"Creating {roleRequest.RoleName} role is not possible");
        }

        [HttpGet("Roles")]
        public IActionResult GetRoles()
        {
            return Ok(_UserRoleBLL.GetRoles());
        }

        [HttpPost("EditRole")]
        public async Task<IActionResult> EditRole(EditRoleRequestDTO roleRequest)
        {
            var isEditingWasSuccessful = await _UserRoleBLL.EditRole(roleRequest);

            if (isEditingWasSuccessful)
            {
                return Ok($"The {roleRequest.RoleNameToEdit} role was successfuly modified to {roleRequest.NewRoleName}");
            }

            return BadRequest($"Modifying the {roleRequest.RoleNameToEdit} role is not possible");
        }

        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var addingResult = await _UserRoleBLL.AddRoleToUser(roleRequest);

            if (addingResult.Succeeded)
            {
                return Ok(addingResult.ResponseMessage);
            }

            return BadRequest(addingResult.ResponseMessage);
        }

        [HttpPost("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var removeResult = await _UserRoleBLL.RemoveRoleFromUser(roleRequest);

            if (removeResult.Succeeded)
            {
                return Ok(removeResult.ResponseMessage);
            }

            return BadRequest(removeResult.ResponseMessage);
        }

        [HttpGet("RolesByUser/{userName}")]
        public async Task<IActionResult> GetRolesByUser(string userName)
        {
            var searchResult = await _UserRoleBLL.GetRolesByUser(userName);

            if (searchResult.Succeeded)
            {
                return Ok(searchResult.FoundRoles);
            }

            return NotFound(searchResult.ResponseMessage);
        }

        [HttpGet("UsersByRole/{uroleName}")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            var searchResult = await _UserRoleBLL.GetUsersByRole(roleName);

            if (searchResult.Succeeded)
            {
                return Ok(searchResult.FoundUsers);
            }

            return NotFound(searchResult.ResponseMessage);
        }
    }
}
