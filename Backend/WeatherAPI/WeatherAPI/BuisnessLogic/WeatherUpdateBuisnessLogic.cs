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
      var orte = dbConnector.GetOrteToRefresh(connection);

      foreach (var item in orte)
      {
        var apiFetchData = apiConnector.LoadWeatherFromApiByOrtAsync(item).Result;
        dbConnector.SaveWeatherToDatabase(apiFetchData, connection);
      }
      return Task.CompletedTask;
    }
  }
}
