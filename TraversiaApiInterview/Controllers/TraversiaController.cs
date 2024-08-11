using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TraversiaApiInterview.Processors;

namespace TraversiaApiInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraversiaController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public TraversiaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("sectors")]
        public IActionResult GetSectors()
        {
          return Ok(ViewProcessor.ViewAllSectors(_configuration));
        }


        [HttpPost("AddAirport")]

        public IActionResult AddAirport(string name ,string Code ,string IATA)
        {
            return Ok(AddProcessor.AddAirport(name, Code, IATA, _configuration));
        }


        [HttpDelete("DeleteAirport")]

        public IActionResult DeleteAirport(string name)
        {
            return Ok(DeleteProcessor.DeleteAirport(name,_configuration));
        }
      
    }
}
