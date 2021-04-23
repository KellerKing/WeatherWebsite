using MySqlConnector;
using Service.Database;
using Service.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.DataAccess;

namespace WeatherAPITests
{
  public class DatabaseConnector_Mock : IDatabaseConnector
  {
    public void ClearOldTempEntries(DateTime beforeDate)
    {
      throw new NotImplementedException();
    }

    public int DeleteTempById(List<TempDTO> ids)
    {
      return ids.Count;
    }

    public async Task<List<TempDTO>> GetAllActualAsync()
    {
      return new List<TempDTO>() {
        new TempDTO
        {
          Type = "Actual",
          Id = 2,
          Time = new DateTime(2021, 04, 09, 7, 10, 00)
        }
      };
    }

    public async Task<List<TempDTO>> GetAllForecastsAsync()
    {
      return new List<TempDTO>() {
        new TempDTO
        {
          Type = "Forecast",
          Id = 2,
          Time = new DateTime(2021, 04, 09, 7, 5, 00)
        }
      };
    }

    public Task<List<GemeindeDTO>> GetOrteToRefreshAsync()
    {
      throw new NotImplementedException();
    }

    public void SaveWeatherToDatabaseAsync(TempDTO weatherData)
    {
      throw new NotImplementedException();
    }
  }
}
