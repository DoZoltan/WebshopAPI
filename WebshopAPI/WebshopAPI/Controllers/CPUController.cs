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
    public class CPUController : ControllerBase
    {
        protected readonly ICPUBLL _CPUBLL;

        public CPUController(ICPUBLL CPUBLL)
        {
            _CPUBLL = CPUBLL;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _CPUBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _CPUBLL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CPU cpu)
        {
            var result = await _CPUBLL.AddNew(cpu);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Add new CPU was failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CPU cpu)
        {
            var result = await _CPUBLL.Update(cpu);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Updating the CPU was failed");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _CPUBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Deleting the CPU was failed");
        }

        [HttpGet]
        public async Task<IActionResult> GetCPUsByMotherboard(CPUSocketEnum CPUSocket)
        {
            var result = await _CPUBLL.GetCompatibleCPUsByMotherboardCPUSocket(CPUSocket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
