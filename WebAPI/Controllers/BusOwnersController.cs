using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusOwnersController : ControllerBase
    {
        private IBusOwnerService _busOwnerService;

        public BusOwnersController(IBusOwnerService busOwnerService)
        {
            _busOwnerService = busOwnerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _busOwnerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _busOwnerService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(BusOwner busOwner)
        {
            var result = _busOwnerService.Add(busOwner);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BusOwner busOwner)
        {
            var result = _busOwnerService.Add(busOwner);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(BusOwner busOwner)
        {
            var result = _busOwnerService.Update(busOwner);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
