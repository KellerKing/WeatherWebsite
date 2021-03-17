using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.DataAccess
{
  public class DatabaseConnector : IDatabaseConnector
  {
    public List<SearchResultDTO> GetOrteToRefresh(MySqlConnection connecton)
    {
      List<SearchResultDTO> searchResults = new List<SearchResultDTO>();

      var procedure = QueryCommands.commands[(int)CommandEnum.GetAllOrteInDb];
      var cmd = new MySqlCommand(procedure, connecton);
      cmd.CommandType = System.Data.CommandType.StoredProcedure;
      MySqlDataReader reader = null;

      try
      {
        connecton.Open();

        if (connecton.State != System.Data.ConnectionState.Open)
          return searchResults;

        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
          searchResults.Add(new SearchResultDTO
          {
            Ort = (string)reader[0],
            Gemeinde = (string)reader[1]
          });
        }
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); } 
      finally
      {
        reader?.Close();
        connecton?.Close();
      }
      return searchResults;
    }


    public void SaveWeatherToDatabase(WeatherDataFromApiDTO weatherData, MySqlConnection connecton)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.InsertSingleWeatherInDb];
      using var cmd = new MySqlCommand(procedure, connecton);
      cmd.CommandType = System.Data.CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@sTimeParam", DateTime.Now);
      cmd.Parameters.AddWithValue("@ortParam", weatherData.Name);
      cmd.Parameters.AddWithValue("@tempMaxParam", weatherData.Main.TempMax);
      cmd.Parameters.AddWithValue("@tempMinParam", weatherData.Main.TempMin);
      cmd.Parameters.AddWithValue("@tempCurrentParam", weatherData.Main.Temp);
      cmd.Parameters.AddWithValue("@descriptionParam", weatherData.Weather.First().Description);

      try
      {
        connecton.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("save");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        connecton.Close();
      }

      

      

    }
  }
}
