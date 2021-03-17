using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
  public class ConnectionData
  {

    public ConnectionData(MySqlConnection connection, string apiKey)
    {
      SqlConnection = connection;
      ApiKey = apiKey;
    }

    public MySqlConnection SqlConnection { get; init; }

    public string ApiKey { get; init; }
  }
}
