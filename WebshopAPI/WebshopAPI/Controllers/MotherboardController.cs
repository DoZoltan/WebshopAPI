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

        // érdemes lehet list / array-t várni, vagy azt is egy külön route.on, ha több mindent is frissíteni kellene
        // továbbá, ha egy entitásnak csak egy részét akarjuk frissíteni, akkor inkább a PATCH metódus legyen használva
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
            var result = await _motherboardBLL.GetMotherboardsByCPU(cpuSocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("memorySocket/{memorySocket}")]
        public async Task<IActionResult> GetMotherboardsByMemory(RamSocketEnum memorySocket)
        {
            var result = await _motherboardBLL.GetMotherboardsByMemory(memorySocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
