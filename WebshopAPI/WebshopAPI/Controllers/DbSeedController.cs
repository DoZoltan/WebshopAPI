using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.DTOs.RequestDTOs;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbSeedController : ControllerBase
    {
        private readonly IDbSeedBLL _dbSeedBLL;

        public DbSeedController(IDbSeedBLL dbSeedBLL)
        {
            _dbSeedBLL = dbSeedBLL;
        }

        [HttpPost]
        public async Task<IActionResult> Seed([FromBody] DbSeedRequestDTO seedRequest)
        {
            if (seedRequest.SeedPassword == "DataSeed")
            {
                var isTheSeedWasSuccessful = await _dbSeedBLL.Seed();

                if (isTheSeedWasSuccessful)
                {
                    return Ok("The DB was seeded");
                }

                return Conflict("The DB seed has failed or it was not empty");
            }

            return BadRequest("Something went wrong");
        }
    }
}
