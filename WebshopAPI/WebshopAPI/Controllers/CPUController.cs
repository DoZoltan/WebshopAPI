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
    public class CpuController : BaseCRUDController<Cpu>
    {
        protected readonly ICpuBLL _CpuBLL;

        public CpuController(ICpuBLL CpuBLL, IResponseMessenger ResponseMessenger): base(CpuBLL, ResponseMessenger)
        {
            _CpuBLL = CpuBLL;
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
