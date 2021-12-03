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
    public class RamController : ControllerBase
    {
        protected readonly IRamBLL _RamBLL;
        protected readonly IResponseMessenger _ResponseMessenger;

        public RamController(IRamBLL RamBLL, IResponseMessenger ResponseMessenger)
        {
            _RamBLL = RamBLL;
            _ResponseMessenger = ResponseMessenger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _RamBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Ram).Name, id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RamBLL.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Ram ram)
        {
            var result = await _RamBLL.AddNew(ram);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Ram ram, int id)
        {
            if (ram.ID != id)
            {
                return BadRequest(_ResponseMessenger.SendWrongProductIdMessage(typeof(Ram).Name, ram.ID, id));
            }

            if (await _RamBLL.GetByID(ram.ID) == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Ram).Name, id));
            }

            var result = await _RamBLL.Update(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _RamBLL.GetByID(id);

            if (ramToDelete == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(Ram).Name, id));
            }

            return Ok(await _RamBLL.Delete(ramToDelete));
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetMemoriesBySocket(RamSocketEnum socket)
        {
            if (Enum.IsDefined(typeof(RamSocketEnum), socket))
            {
                return NotFound(_ResponseMessenger.SendWrongSocketTypeMessage(((int)socket)));
            }

            return Ok(await _RamBLL.GetMemoriesBySocket(socket));
        }
    }
}
