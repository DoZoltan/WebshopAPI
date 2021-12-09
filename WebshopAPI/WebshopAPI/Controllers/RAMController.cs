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
    public class RamController : BaseCRUDController<Ram>
    {
        protected readonly IRamBLL _RamBLL;

        public RamController(IRamBLL RamBLL, IResponseMessenger ResponseMessenger): base(RamBLL, ResponseMessenger)
        {
            _RamBLL = RamBLL;
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

        [HttpGet("grid")]
        public async Task<IActionResult> GetProductsForGridData()
        {
            return Ok(await _RamBLL.GetProductsForGridData());
        }
    }
}
