using MySqlConnector;
using Service.ApiConnector.Interface;
using Service.Database.DTOs;
using System;
using System.Threading.Tasks;
using WeatherAPI.DataAccess;
using System.Linq;
using Service.Database;
using System.Collections.Generic;

namespace WeatherAPI.ServiceLibrary.Domains
{
  public class WeatherUpdateBuisnessLogic
  {

    //TODO: Das ding soll nur mit Models arbeiten, Daten aus der DB sollen zukünftig konvertiert werden.
    public static Task GetWeatherForecastsAndSave(IDatabaseConnector dbConnector, IApiConnector apiConnector)
    {
      var orte = dbConnector.GetOrteToRefreshAsync().Result;

      orte.ForEach(ort =>
      {
        var convertetParameterDTO = Converter.Converter.ConvertGemeindeDTOToParameterDTO(ort);

        var apiFetchData = apiConnector.LoadWeatherForecastsAsync(convertetParameterDTO).Result;

        Converter.Converter.ConvertForecasts(apiFetchData, ort.Gemeinde, WeatherType.forecast).ForEach(data =>
        {
          dbConnector.SaveWeatherToDatabaseAsync(data);
          Console.WriteLine($"save Forecast {ort.Gemeinde}  -  {data.Time}"); 
        });
      });

      return Task.CompletedTask;
    }

    public static Task GetCurrentWeatherAndSave(IDatabaseConnector dbConnector, IApiConnector apiConnector)
    {
      var orte = dbConnector.GetOrteToRefreshAsync().Result;

      orte.ForEach(ort =>
      {
        var convertetParameterDTO = Converter.Converter.ConvertGemeindeDTOToParameterDTO(ort);

        var apiFetchData = apiConnector.LoadWeatherActualAsync(convertetParameterDTO).Result; 

        var convertetObject = Converter.Converter.ConvertActualWeather(apiFetchData, WeatherType.actual);
        dbConnector.SaveWeatherToDatabaseAsync(convertetObject);
        Console.WriteLine($"save Actual {ort.Gemeinde}  -  {convertetObject.Time}");

      });
      DeleteForecastsIfActualExists(dbConnector);
      return Task.CompletedTask;
    }

    public static Task DeleteObsoleteWeather(IDatabaseConnector dbConnector)
    {
      var minDate = DateTime.Today.AddDays(-10);
      dbConnector.ClearOldTempEntries(minDate);
      return Task.CompletedTask;
    }

    public static List<TempDTO> DeleteForecastsIfActualExists(IDatabaseConnector dbConnector)
    {
      var forecasts = dbConnector.GetAllForecastsAsync().Result;
      var actuals = dbConnector.GetAllActualAsync().Result;

      var entriesToDelete = from forecast in forecasts
                            from actual in actuals
                            where forecast.Time <= actual.Time
                            select new TempDTO { Id = forecast.Id };

      entriesToDelete.ToList().ForEach(entry => Console.WriteLine($"save Actual {entry.Gemeinde}  -  {entry.Time}"));
      dbConnector.DeleteTempById(entriesToDelete.ToList());

      return entriesToDelete.ToList();
    }
  }
}
