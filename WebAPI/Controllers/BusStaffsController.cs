using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStaffsController : ControllerBase
    {
        private IBusStaffService _busStaffService;

        public BusStaffsController(IBusStaffService busStaffService)
        {
            _busStaffService = busStaffService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _busStaffService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _busStaffService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(BusStaff busStaff)
        {
            var result = _busStaffService.Add(busStaff);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(BusStaff busStaff)
        {
            var result = _busStaffService.Update(busStaff);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BusStaff busStaff)
        {
            var result = _busStaffService.Delete(busStaff);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
