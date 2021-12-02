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
    public class RamController : ControllerBase
    {
        protected readonly IRamBLL _RamBLL;

        public RamController(IRamBLL RamBLL)
        {
            _RamBLL = RamBLL;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _RamBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            // a response üzeneteket ki lehet szervezni egy osztályba, így nem kell mindenoh átirogatni módosítás esetén
            return NotFound($"There is no product with ID: {id}");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RamBLL.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Ram ram)
        {
            var result = await _RamBLL.AddNew(ram);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
            }

            return BadRequest("Faulty product data");
        }

        //itt érdemes az id-t is várni
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Ram ram)
        {
            //csekkolni, h az id és a termék.id eggyezik-e
            //csekkolni, h létezik-e ilyen id-val termék a DB-be (ha nem, akkor nincs mit update-elni)

            var result = await _RamBLL.Update(ram);

            if (result != null)
            {
                return Ok(result);
            }

            // BadRequest-et akkor kéne, ha az érkező adat érvénytelen, ezt a BLL-ben ellenőrizzni kell (most csak a null van)
            return BadRequest("Updating the ram was failed");

            //Conflict -- mikor?
            //return Conflict();

            // a 400 (BadRequest) helyett lehetne ezt is
            //return UnprocessableEntity(); //422

            // szerver oldali hiba esetén, pl. exception-öknél 500-as hibákat kellene
            //return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // DTO használata? két esetben is lehet null az eredmény, a BLL-ben, ha nincs ilyen id-val termék, vagy a DAL-ban, egy db exception miatt
            // a DTO tartalmazná, h hol lett null + a terméket, ha sikerült a törlés, és a http kód ezektől függne

            //erre nem kell a DTO, simán itt legyen a try-ctach
            var result = await _RamBLL.DeleteByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound($"There is no product with ID: {id}");
        }

        [HttpGet("socket/{socket}")]
        public async Task<IActionResult> GetMemoriesBySocket(RamSocketEnum socket)
        {
            var result = await _RamBLL.GetMemoriesBySocket(socket);

            if (result != null)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
