using MySqlConnector;
using Service.Database;
using Service.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherAPI.DataAccess
{
  public interface IDatabaseConnector
  {

    public Task SaveWeatherToDatabaseAsync(TempDTO weatherData, MySqlConnection connecton);

    public Task<List<GemeindeDTO>> GetOrteToRefreshAsync(MySqlConnection connecton);

    public void ClearOldTempEntries(MySqlConnection connecton, DateTime beforeDate);
  }
}
