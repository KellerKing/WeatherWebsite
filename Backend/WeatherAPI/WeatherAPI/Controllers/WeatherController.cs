using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeatherController : ControllerBase
  {

    private MySqlConnection _connection;
    private string _apiKey;

    public WeatherController(ConnectionData connection)
    {
      _connection = connection.SqlConnection;
      _apiKey = connection.ApiKey;
    }

    //Binding
    //[From Query] Gets values from query sting
    //[FromRoute] values from Route data
    //[FromForm] values from form posted in form fields
    //[FromHeader] values from HTTP Header
    //[FromBody] values from requestbody

    //[NonAction]
    [HttpGet("einTest")] //api/WeatherController/GetFromQueryAsync?pageSize=10&pageNumber=2
    public async Task<IActionResult> GetFromQueryAsync([FromQuery] int pageSize, [FromQuery]int pageNumber)
    {

      return Ok(pageSize + " " + pageNumber);
    }
    [HttpPost("CurrentWeather")]
    public async Task<IActionResult> GetCurrentWeatherAsync([FromQuery] string search)
    {
      return Ok(search);
    }


  }

}
