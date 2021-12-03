using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebshopAPI.BLL.Interfaces;
using WebshopAPI.DAL.Models;
using WebshopAPI.Services.ResponseMessenger;

namespace WebshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T> : ControllerBase where T: BaseProduct
    {
        protected readonly IResponseMessenger _ResponseMessenger;
        protected readonly IBaseBLL<T> _BaseBLL;

        public BaseCRUDController(IBaseBLL<T> BaseBLL, IResponseMessenger ResponseMessenger)
        {
            _BaseBLL = BaseBLL;
            _ResponseMessenger = ResponseMessenger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _BaseBLL.GetByID(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(T).Name, id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _BaseBLL.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T product)
        {
            var result = await _BaseBLL.AddNew(product);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] T product, int id)
        {
            if (product.ID != id)
            {
                return BadRequest(_ResponseMessenger.SendWrongProductIdMessage(typeof(T).Name, product.ID, id));
            }

            if (await _BaseBLL.GetByID(product.ID) == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(T).Name, id));
            }

            var result = await _BaseBLL.Update(product);

            if (result != null)
            {
                return Ok(result);
            }

            return UnprocessableEntity(_ResponseMessenger.SendWrongProductDataMessage());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ramToDelete = await _BaseBLL.GetByID(id);

            if (ramToDelete == null)
            {
                return NotFound(_ResponseMessenger.SendProductIdNotFoundMessage(typeof(T).Name, id));
            }

            return Ok(await _BaseBLL.Delete(ramToDelete));
        }
    }
}
