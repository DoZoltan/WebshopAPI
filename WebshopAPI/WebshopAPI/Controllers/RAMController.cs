using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        protected readonly IRamBLL _RamBLL;

        public RamController(IRamBLL RamBLL)
        {
            _RamBLL = RamBLL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _RamBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _RamBLL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Ram ram)
        {
            var result = await _RamBLL.AddNew(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Add new ram was failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Ram ram)
        {
            var result = await _RamBLL.Update(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Updating the ram was failed");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _RamBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Deleting the ram was failed");
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetMemoriesBySocket(RamSocketEnum socket)
        {
            var result = await _RamBLL.GetMemoriesBySocket(socket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
