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

            return NotFound($"There is no product with ID: {id}");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _motherboardBLL.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Motherboard motherboard)
        {
            var result = await _motherboardBLL.AddNew(motherboard);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
            }

            return UnprocessableEntity("Faulty product data");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Motherboard motherboard, int id)
        {
            if (motherboard.ID != id)
            {
                return BadRequest("Invalid product ID");
            }

            if (await _motherboardBLL.GetByID(motherboard.ID) is null)
            {
                return NotFound($"There is no product with ID: {id}");
            }

            var result = await _motherboardBLL.Update(motherboard);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity("Faulty product data");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _motherboardBLL.GetByID(id);

            if (ramToDelete is null)
            {
                return NotFound($"There is no product with ID: {id}");
            }

            return Ok(await _motherboardBLL.Delete(ramToDelete));
        }

        [HttpGet("cpuSocket/{cpuSocket}")]
        public async Task<IActionResult> GetMotherboardsByCPU(CpuSocketEnum cpuSocket)
        {
            if (Enum.IsDefined(typeof(CpuSocketEnum), cpuSocket))
            {
                return NotFound($"The ({cpuSocket}) socket type is not exist");
            }

            return Ok(await _motherboardBLL.GetMotherboardsByCPU(cpuSocket));
        }

        [HttpGet("memorySocket/{memorySocket}")]
        public async Task<IActionResult> GetMotherboardsByMemory(RamSocketEnum memorySocket)
        {
            if (Enum.IsDefined(typeof(RamSocketEnum), memorySocket))
            {
                return NotFound($"The ({memorySocket}) socket type is not exist");
            }

            return Ok(await _motherboardBLL.GetMotherboardsByMemory(memorySocket));
        }
    }
}
