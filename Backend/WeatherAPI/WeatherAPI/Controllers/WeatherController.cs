using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Threading.Tasks;
using WeatherAPI.BuisnessLogic;
using WeatherAPI.DataAccess;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeatherController : ControllerBase
  {

    private IDatabaseConnector _database;

    public WeatherController(ConnectionData connection)
    {
      _database = new DatabaseConnector(connection.SqlConnection);
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
    public async Task<IActionResult> GetWeatherFromDatabase([FromQuery] string search)
    {
      return Ok(search);
    }

    [HttpGet("PossibleOrte")] //api/WeatherController/GetFromQueryAsync?pageSize=10&pageNumber=2
    public async Task<IActionResult> GetPossibleOrte()
    {
      return Ok(WeatherControllerBuisnessLogic.GetOrte(_database));
    }


    [HttpGet("WeatherForOrt")] 
    public async Task<IActionResult> GetWeatherForOrt([FromQuery] string search)
    {
      return Ok(WeatherControllerBuisnessLogic.GetOrte(_database));
    }


  }

}
