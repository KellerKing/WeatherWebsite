using Service.ApiConnector.DTOS;
using Service.Database;
using Service.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherAPI.Converter
{
  public class Converter
  {
    public static List<TempDTO> ConvertForecasts(WeatherDataFromApiModel weahterModel, string gemeinde, string type)
    {

      var output = new List<TempDTO>();
      var timestamp = DateTime.Now;

      for (int i = 0; i < weahterModel.Hourly.Count; i++)
      {
        output.Add(
          new TempDTO
          {
            TempCurrent = (float)weahterModel.Hourly[i].Temp,
            TempMax = null,
            TempMin = null,
            Gemeinde = gemeinde,
            Description = weahterModel.Hourly[i].Weather.First().Description,
            Time = timestamp.AddHours(i),
            Type = type
          });
      }

      return output;
    }

    public static TempDTO ConvertActualWeather(ActualWeatherDTO actualWeather, string type)
    {
      return new TempDTO
      {
        TempCurrent = (float)actualWeather.Main.Temp,
        TempMax = (float)actualWeather.Main.TempMax,
        TempMin = (float)actualWeather.Main.TempMin,
        Gemeinde = actualWeather.Name,
        Description = actualWeather.Weather.First().Description,
        Time = DateTime.Now,
        Type = type
      };
    }

    public static ParameterDTO ConvertGemeindeDTOToParameterDTO(GemeindeDTO gemeinde)
    {
      return new ParameterDTO
      {
        Lat = gemeinde.Lat,
        Lon = gemeinde.Lon,
        Ort = gemeinde.Gemeinde
      };
    }
  }
}
