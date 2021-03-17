
using MySqlConnector;
using System;
using System.Linq;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.ServiceLibrary.Repos
{
  public class DatabaseRepo
  {

    public static void SaveToDatabase(MySqlConnection connection, WeatherDataFromApiDTO entity, string storedProcedure)
    {
      try
      {
        connection.OpenAsync();

        using (var command = new MySqlCommand(storedProcedure, connection))
        {
          command.CommandType = System.Data.CommandType.StoredProcedure;
          command.Parameters.AddWithValue("@dateParam", DateTime.Today);
          command.Parameters.AddWithValue("@ortParam", entity.Name);
          command.Parameters.AddWithValue("@tempMaxParam", entity.Main.TempMax);
          command.Parameters.AddWithValue("@tempMinParam", entity.Main.TempMin);
          command.Parameters.AddWithValue("@tempCurrentParam", entity.Main.Temp);
          command.Parameters.AddWithValue("@descriptionParam", entity.Weather.First().Description);
          command.ExecuteNonQuery();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
        connection.CloseAsync();
        throw;
      }
    }


    //public static void SaveToDatabase(MySqlConnection connection, WeatherFetchEntity entity, string storedProcedure)
    //{
    //  try
    //  {
    //    connection.OpenAsync();

    //    using (var command = new MySqlCommand("INSERT INTO temp " +
    //                                        "(sTime, ort, tempMax, tempMin, tempCurrent)" +
    //                                        "VALUES (@date, @ort, @tempMax, @tempMin, @tempCurrent)", 
    //                                        connection))
    //    {
    //      command.Parameters.AddWithValue("@date", DateTime.Today);
    //      command.Parameters.AddWithValue("@ort", entity.Name);
    //      command.Parameters.AddWithValue("@tempMax", entity.Main.TempMax);
    //      command.Parameters.AddWithValue("@tempMin", entity.Main.TempMin);
    //      command.Parameters.AddWithValue("@tempCurrent", entity.Main.Temp);
    //      command.ExecuteNonQuery();
    //    }
    //  }
    //  catch (Exception e)
    //  {
    //    connection.CloseAsync();
    //    throw;
    //  }
    //}
  }
}
