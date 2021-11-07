using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        protected readonly IMotherboardBLL _motherboardBLL;

        public MotherboardController(IMotherboardBLL motherboardBLL)
        {
            _motherboardBLL = motherboardBLL;
        }
    }
}
