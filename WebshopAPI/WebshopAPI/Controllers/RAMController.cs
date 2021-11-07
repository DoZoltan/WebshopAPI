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
    public class RAMController : ControllerBase
    {
        protected readonly IRAMBLL _RAMBLL;

        public RAMController(IRAMBLL RAMBLL)
        {
            _RAMBLL = RAMBLL;
        }
    }
}
