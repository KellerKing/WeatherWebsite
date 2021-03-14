using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Repos;

namespace WeatherAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WeatherController : ControllerBase
  {

    private MySqlConnection _connection;
    private string _apiKey;

    public WeatherController(Connection connection)
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
      var x = await OpenWeatherRepo.TestAsync($"https://api.openweathermap.org/data/2.5/weather?q=Berlin&appid={_apiKey}f3de9af35f786230cdfa898028003eee");
      //try
      //{
      //  _connection.Open();
      //  using var command = new MySqlCommand("Insert INTO test Set PETER = 1, Rüdiger ='Ich bin toll';", _connection);
      //  using var reader = await command.ExecuteReaderAsync();

      //  while (await reader.ReadAsync())
      //  {
      //    var value = reader.GetValue(0);
      //    // do something with 'value'
      //  }
      //}
      //catch (Exception)
      //{

      //  throw;
      //}
      //finally
      //{
      //  _connection.Close();
      //}

      return Ok(pageSize + " " + pageNumber);
    }
    [HttpPost("CurrentWeather")]
    public async Task<IActionResult> GetCurrentWeatherAsync([FromQuery] string search)
    {
      var queryResult = await OpenWeatherRepo.TestAsync($"https://api.openweathermap.org/data/2.5/weather?q={search}&appid={_apiKey}");
      //DatabaseRepo.SaveToDatabase(_connection ,queryResult);
      return Ok(queryResult);
    }


  }

}
