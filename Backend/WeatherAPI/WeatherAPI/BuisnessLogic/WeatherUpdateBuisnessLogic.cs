using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.DataAccess;
using WeatherAPI.ServiceLibrary.Repos;

namespace WeatherAPI.ServiceLibrary.Domains
{
  public class WeatherUpdateBuisnessLogic
  {


    public static Task GetWeatherAndSave(MySqlConnection connection, IDatabaseConnector dbConnector, IApiConnector apiConnector)
    {
      var orte = dbConnector.GetOrteToRefreshAsync(connection).Result;

      foreach (var item in orte)
      {
        var apiFetchData = apiConnector.LoadWeatherFromApiByOrtAsync(item).Result;
        dbConnector.SaveWeatherToDatabaseAsync(apiFetchData, connection);
      }
      return Task.CompletedTask;
    }

    public static Task DeleteObsoleteWeather(MySqlConnection connection, IDatabaseConnector dbConnector)
    {
      var minDate = DateTime.Today.AddDays(-30);
      dbConnector.ClearOldTempEntries(connection, minDate);
      return Task.CompletedTask;
    }
  }
}
