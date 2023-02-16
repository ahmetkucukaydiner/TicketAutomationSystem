using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private IStationService _stationService;

        public StationsController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _stationService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _stationService.GetById(id);

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
