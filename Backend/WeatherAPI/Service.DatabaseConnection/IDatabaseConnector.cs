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

    public void SaveWeatherToDatabaseAsync(TempDTO weatherData);
    public Task<List<GemeindeDTO>> GetOrteToRefreshAsync();
    public void ClearOldTempEntries(DateTime beforeDate);
    public Task<List<TempDTO>> GetAllForecastsAsync();
    public Task<List<TempDTO>> GetAllActualAsync();
    public int DeleteTempById(List<TempDTO> ids);
  }
}
