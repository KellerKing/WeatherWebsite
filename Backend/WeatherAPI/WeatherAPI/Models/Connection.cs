using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
  public class Connection
  {

    public Connection(MySqlConnection connection, string apiKey)
    {
      SqlConnection = connection;
      ApiKey = apiKey;
    }

    public MySqlConnection SqlConnection { get; init; }

    public string ApiKey { get; init; }
  }
}
