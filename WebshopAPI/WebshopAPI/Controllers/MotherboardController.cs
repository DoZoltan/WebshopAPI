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
    public class MotherboardController : ControllerBase
    {
        protected readonly IMotherboardBLL _motherboardBLL;

        public MotherboardController(IMotherboardBLL motherboardBLL)
        {
            _motherboardBLL = motherboardBLL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _motherboardBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _motherboardBLL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Motherboard motherboard)
        {
            var result = await _motherboardBLL.AddNew(motherboard);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Add new motherboard was failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Motherboard motherboard)
        {
            var result = await _motherboardBLL.Update(motherboard);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Updating the motherboard was failed");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _motherboardBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Deleting the motherboard was failed");
        }

        [HttpGet("cpuSocket/{cpuSocket}")]
        public async Task<IActionResult> GetMotherboardsByCPU(CpuSocketEnum cpuSocket)
        {
            var result = await _motherboardBLL.GetMotherboardsByCPU(cpuSocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet("memorySocket/{memorySocket}")]
        public async Task<IActionResult> GetMotherboardsByMemory(RamSocketTypeEnum memorySocket)
        {
            var result = await _motherboardBLL.GetMotherboardsByMemory(memorySocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
