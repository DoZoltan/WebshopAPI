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
    public class MotherboardController : BaseCRUDController<Motherboard>
    {
        protected readonly IMotherboardBLL _motherboardBLL;

        public MotherboardController(IMotherboardBLL motherboardBLL, IResponseMessenger ResponseMessenger): base(motherboardBLL, ResponseMessenger)
        {
            _motherboardBLL = motherboardBLL;
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
