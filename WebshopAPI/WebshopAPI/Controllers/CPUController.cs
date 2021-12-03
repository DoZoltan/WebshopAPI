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
    public class CpuController : ControllerBase
    {
        protected readonly ICpuBLL _CpuBLL;
        protected readonly IResponseMessenger _ResponseMessenger;

        public CpuController(ICpuBLL CpuBLL, IResponseMessenger ResponseMessenger)
        {
            _CpuBLL = CpuBLL;
            _ResponseMessenger = ResponseMessenger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _CpuBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Cpu).Name, id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _CpuBLL.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Cpu cpu)
        {
            var result = await _CpuBLL.AddNew(cpu);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Cpu cpu, int id)
        {
            if (cpu.ID != id)
            {
                return BadRequest(_ResponseMessenger.SendWrongProductIdMessage(typeof(Cpu).Name, cpu.ID, id));
            }

            if (await _CpuBLL.GetByID(cpu.ID) == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Cpu).Name, id));
            }

            var result = await _CpuBLL.Update(cpu);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _CpuBLL.GetByID(id);

            if (ramToDelete == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Cpu).Name, id));
            }

            return Ok(await _CpuBLL.Delete(ramToDelete));
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetCpusBySocket(CpuSocketEnum socket)
        {
            if (Enum.IsDefined(typeof(CpuSocketEnum), socket))
            {
                return NotFound(_ResponseMessenger.SendWrongSocketTypeMessage(((int)socket)));
            }

            return Ok(await _CpuBLL.GetCpusBySocket(socket));
        }
    }
}
