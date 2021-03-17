using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.DataAccess
{
  public interface IDatabaseConnector
  {

    public void SaveWeatherToDatabase(WeatherDataFromApiDTO weatherData, MySqlConnection connecton);

    public List<SearchResultDTO> GetOrteToRefresh(MySqlConnection connecton);
  }
}
