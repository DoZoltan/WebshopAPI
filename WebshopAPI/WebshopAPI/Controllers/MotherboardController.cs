using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Enums;
using WebshopAPI.Services.ResponseMessenger;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        protected readonly IMotherboardBLL _motherboardBLL;
        protected readonly IResponseMessenger _ResponseMessenger;

        public MotherboardController(IMotherboardBLL motherboardBLL, IResponseMessenger ResponseMessenger)
        {
            _motherboardBLL = motherboardBLL;
            _ResponseMessenger = ResponseMessenger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _motherboardBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Motherboard).Name, id));
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

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Motherboard motherboard, int id)
        {
            if (motherboard.ID != id)
            {
                return BadRequest(_ResponseMessenger.SendWrongProductIdMessage(typeof(Motherboard).Name, motherboard.ID, id));
            }

            if (await _motherboardBLL.GetByID(motherboard.ID) == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Motherboard).Name, id));
            }

            var result = await _motherboardBLL.Update(motherboard);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _motherboardBLL.GetByID(id);

            if (ramToDelete == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Motherboard).Name, id));
            }

            return Ok(await _motherboardBLL.Delete(ramToDelete));
        }

        [HttpGet("cpuSocket/{cpuSocket}")]
        public async Task<IActionResult> GetMotherboardsByCPU(CpuSocketEnum cpuSocket)
        {
            if (Enum.IsDefined(typeof(CpuSocketEnum), cpuSocket))
            {
                return NotFound(_ResponseMessenger.SendWrongSocketTypeMessage(((int)cpuSocket)));
            }

            return Ok(await _motherboardBLL.GetMotherboardsByCPU(cpuSocket));
        }

        [HttpGet("memorySocket/{memorySocket}")]
        public async Task<IActionResult> GetMotherboardsByMemory(RamSocketEnum memorySocket)
        {
            if (Enum.IsDefined(typeof(RamSocketEnum), memorySocket))
            {
                return NotFound(_ResponseMessenger.SendWrongSocketTypeMessage(((int)memorySocket)));
            }

            return Ok(await _motherboardBLL.GetMotherboardsByMemory(memorySocket));
        }
    }
}
