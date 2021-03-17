using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
  public enum CommandEnum : uint
  {

    GetAllOrteInDb = 0,
    InsertSingleWeatherInDb = 1

  }

  public static class QueryCommands
  {
    public static string[] commands = new string[]
    {
      "select_orte",
      "insert_temp"
    };


  }
}
