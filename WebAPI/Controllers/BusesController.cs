using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private IBusService _busService;

        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _busService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Success);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _busService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Bus bus)
        {
            var result = _busService.Add(bus);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Bus bus)
        {
            var result = _busService.Delete(bus);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Bus bus)
        {
            var result = _busService.Update(bus);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
