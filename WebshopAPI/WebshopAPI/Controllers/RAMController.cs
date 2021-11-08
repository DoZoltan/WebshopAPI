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
    public class RAMController : ControllerBase
    {
        protected readonly IRAMBLL _RAMBLL;

        public RAMController(IRAMBLL RAMBLL)
        {
            _RAMBLL = RAMBLL;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _RAMBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _RAMBLL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RAM ram)
        {
            var result = await _RAMBLL.AddNew(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Add new ram was failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RAM ram)
        {
            var result = await _RAMBLL.Update(ram);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Updating the ram was failed");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _RAMBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Deleting the ram was failed");
        }

        [HttpGet]
        public async Task<IActionResult> GetMemoriesByMotherboard(RAMSocketTypeEnum memorySocket)
        {
            var result = await _RAMBLL.GetCompatibleMemoriesByMotherboardMemorySocket(memorySocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
