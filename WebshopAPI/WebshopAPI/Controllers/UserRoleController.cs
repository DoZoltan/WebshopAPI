using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserRoleController : ControllerBase
    {
        public IUserRoleBLL _UserRoleBLL { get; set; }

        public UserRoleController(IUserRoleBLL UserRoleBLL)
        {
            _UserRoleBLL = UserRoleBLL;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateOrDeleteRoleRequestDTO roleRequest)
        {
            var creatingResponse = await _UserRoleBLL.CreateRole(roleRequest);

            if (creatingResponse.Succeeded)
            {
                return Ok(creatingResponse.ResponseMessages);
            }

            return BadRequest(creatingResponse.ResponseMessages);
        }

        [HttpDelete("RemoveRole")]
        public async Task<IActionResult> RemoveRole([FromBody] CreateOrDeleteRoleRequestDTO roleRequest)
        {
            var removeResponse = await _UserRoleBLL.RemoveRole(roleRequest);

            if (removeResponse.Succeeded)
            {
                return Ok(removeResponse.ResponseMessages);
            }

            return BadRequest(removeResponse.ResponseMessages);
        }

        [HttpGet("Roles")]
        public IActionResult GetRoles()
        {
            return Ok(_UserRoleBLL.GetRoles());
        }

        [HttpPost("EditRole")]
        public async Task<IActionResult> EditRole(EditRoleRequestDTO roleRequest)
        {
            var editResponse = await _UserRoleBLL.EditRole(roleRequest);

            if (editResponse.Succeeded)
            {
                return Ok(editResponse.ResponseMessages);
            }

            return BadRequest(editResponse.ResponseMessages);
        }

        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var addingResult = await _UserRoleBLL.AddRoleToUser(roleRequest);

            if (addingResult.Succeeded)
            {
                return Ok(addingResult.ResponseMessages);
            }

            return BadRequest(addingResult.ResponseMessages);
        }

        [HttpDelete("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var removeResult = await _UserRoleBLL.RemoveRoleFromUser(roleRequest);

            if (removeResult.Succeeded)
            {
                return Ok(removeResult.ResponseMessages);
            }

            return BadRequest(removeResult.ResponseMessages);
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
