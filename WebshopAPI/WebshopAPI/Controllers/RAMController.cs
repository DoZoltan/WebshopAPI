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

            // a response üzeneteket ki lehet szervezni egy osztályba, így nem kell mindenoh átirogatni módosítás esetén
            return NotFound($"There is no product with ID: {id}");
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

            return UnprocessableEntity("Faulty product data");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Ram ram, int id)
        {
            if (ram.ID != id)
            {
                return BadRequest("Invalid product ID");
            }

            if (await _RamBLL.GetByID(ram.ID) is null)
            {
                return NotFound($"There is no product with ID: {id}");
            }

            var result = await _RamBLL.Update(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity("Faulty product data");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _RamBLL.GetByID(id);

            if (ramToDelete is null)
            {
                return NotFound($"There is no product with ID: {id}");
            }

            return Ok(await _RamBLL.Delete(ramToDelete));
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetMemoriesBySocket(RamSocketEnum socket)
        {
            if (Enum.IsDefined(typeof(RamSocketEnum), socket))
            {
                return NotFound($"The ({socket}) socket type is not exist");
            }

            return Ok(await _RamBLL.GetMemoriesBySocket(socket));    
        }
    }
}
