using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.ServiceLibrary.Repos;

namespace WeatherAPI.ServiceLibrary.Domains
{
  public class WeatherUpdateDatabaseBuisnessLogic
  {

    private const string saveWeather = "insert_temp";

    public static async Task GetWeatherAndSaveAsync(string query, MySqlConnection connection)
    {
      var queryResult = await OpenWeatherRepo.TestAsync(query);
      DatabaseRepo.SaveToDatabase(connection, queryResult, saveWeather);
    }
  }
}
