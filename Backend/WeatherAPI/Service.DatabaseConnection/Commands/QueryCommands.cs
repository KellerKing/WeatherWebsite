using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
  public enum CommandEnum : uint
  {

    GetAllOrteInDb = 0,
    InsertSingleWeatherInDb = 1,
    ClearOldEntrys = 2

  }

  public static class QueryCommands
  {
    public static string[] commands = new string[]
    {
      "select_gemeinde_for_update",
      "insert_temp",
      "clear_old_from_temp"
    };


  }
}
