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

        // nem kell a post / put / get / delete műveleteknek külön-külön route, mint ahogyan most van
        // elég ha a HTTP metódus más, így ettől függően fog eldőlni, hogy a ../UserRole URI alatt mi fog történni
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateOrDeleteRoleRequestDTO roleRequest)
        {
            var creatingResponse = await _UserRoleBLL.CreateRole(roleRequest);

            if (creatingResponse.Succeeded)
            {
                //return Created(); létrehozáskor 201-es állapotkódot adjunk vissza
                //CreatedAtAction(nameof(Get), new { id = result.ID }, result);
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

        // itt update történik, vagyis post helyett put kellene
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
            var addingResult = await _UserRoleBLL.AddRoleToUser(roleRequest, HttpContext.User);

            if (addingResult.Succeeded)
            {
                return Ok(addingResult.ResponseMessages);
            }

            return BadRequest(addingResult.ResponseMessages);
        }

        [HttpDelete("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser(ModifyUserRolesRequestDTO roleRequest)
        {
            var removeResult = await _UserRoleBLL.RemoveRoleFromUser(roleRequest, HttpContext.User);

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

        [HttpGet("UsersByRole/{roleName}")]
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
