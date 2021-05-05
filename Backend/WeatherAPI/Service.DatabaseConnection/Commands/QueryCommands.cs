using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
  public enum CommandEnum : uint
  {

    GetAllOrteInDb = 0,
    UpdateSigngleTempForecast = 1,
    ClearOldEntrys = 2,
    GetForecasts = 3,
    GetActuals = 4,
    DeleteTempById = 5,
    select_orte = 6

  }

  public static class QueryCommands
  {
    public static string[] commands = new string[]
    {
      "select_gemeinde_for_update",
      "update_temp_forecasts",
      "clear_old_from_temp",
      "select_forecasts",
      "select_actual",
      "delete_temp_by_id",
      "select_orte"
    };


  }
}
