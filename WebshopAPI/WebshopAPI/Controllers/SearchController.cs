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
    public class SearchController : ControllerBase
    {
        protected readonly ISearchBLL _SearchBLL;

        public SearchController(ISearchBLL SearchBLL)
        {
            _SearchBLL = SearchBLL;
        }

        [HttpGet("brand/{brandPart}")]
        public async Task<IActionResult> SearchByBrand(string brandPart)
        {
            var result = await _SearchBLL.SearchByBrand(brandPart);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }

        [HttpGet("name/{namePart}")]
        public async Task<IActionResult> SearchByProductName(string namePart)
        {
            var result = await _SearchBLL.SearchByProductName(namePart);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No result");
        }
    }
}
