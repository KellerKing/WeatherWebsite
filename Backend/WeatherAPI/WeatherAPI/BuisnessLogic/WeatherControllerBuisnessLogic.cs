using Service.Database;
using Service.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.DataAccess;

namespace WeatherAPI.BuisnessLogic
{
  public class WeatherControllerBuisnessLogic
  {
    public static List<TempDTO> GetAllWeatherDataInDbForOrt(string ort, IDatabaseConnector db)
    {
      var actuals = db.GetAllActualAsync().Result.Where(x => x.Gemeinde == ort);
      var forecasts = db.GetAllForecastsAsync().Result.Where(x => x.Gemeinde == ort);

      return actuals.Concat(forecasts).ToList();
    }

    public static List<OrtModel> GetOrte(IDatabaseConnector db)
    {
      return db.GetAlleOrte();
    }
  }
}
