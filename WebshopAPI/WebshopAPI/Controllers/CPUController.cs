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
    public class CpuController : ControllerBase
    {
        protected readonly ICpuBLL _CpuBLL;

        public CpuController(ICpuBLL CpuBLL)
        {
            _CpuBLL = CpuBLL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _CpuBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _CpuBLL.GetAll();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Cpu cpu)
        {
            var result = await _CpuBLL.AddNew(cpu);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Add new CPU was failed");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cpu cpu)
        {
            var result = await _CpuBLL.Update(cpu);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Updating the CPU was failed");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _CpuBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Deleting the CPU was failed");
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetCpusBySocket(CpuSocketEnum socket)
        {
            var result = await _CpuBLL.GetCpusBySocket(socket);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
