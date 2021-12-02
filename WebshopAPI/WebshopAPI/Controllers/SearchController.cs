using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _SearchBLL.SearchByBrand(brandPart));
        }

        [HttpGet("name/{namePart}")]
        public async Task<IActionResult> SearchByProductName(string namePart)
        {
            return Ok(await _SearchBLL.SearchByProductName(namePart));
        }
    }
}
