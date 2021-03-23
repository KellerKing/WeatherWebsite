using Dapper;
using MySqlConnector;
using Service.Database;
using Service.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.DataAccess
{
  public class DatabaseConnector : IDatabaseConnector
  {
    public void ClearOldTempEntries(MySqlConnection connecton, DateTime beforeDate)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.ClearOldEntrys];

      using (connecton)
      {
        //beforeTimeParam
        connecton.ExecuteAsync(procedure, new { beforeTimeparam = beforeDate }, commandType: System.Data.CommandType.StoredProcedure);
      }

      //var cmd = new MySqlCommand(procedure, connecton);
      //cmd.CommandType = System.Data.CommandType.StoredProcedure;

      //try
      //{
      //  connecton.Open();
      //  cmd.ExecuteNonQuery();
      //  Console.WriteLine("Delete");
      //}
      //catch (Exception ex)
      //{
      //  Console.WriteLine(ex.Message);
      //}
      //finally
      //{
      //  connecton.Close();
      //}
    }

    public List<SearchResultDTO> GetOrteToRefresh(MySqlConnection connecton) //TODO: Löschen
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


    public async Task<List<GemeindeDTO>> GetOrteToRefreshAsync(MySqlConnection connecton)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.GetAllOrteInDb];
      IEnumerable<GemeindeDTO> orte;


      using (var cnn = new MySqlConnection("server=127.0.0.1;user=root;password=1234;database=test"))
      {
        orte = await cnn.QueryAsync<GemeindeDTO>(procedure, null, commandType: System.Data.CommandType.StoredProcedure);
      }

      return orte.ToList();
    }

    public Task SaveWeatherToDatabaseAsync(TempDTO weatherData, MySqlConnection connecton)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.InsertSingleWeatherInDb];

      using (connecton)
      {
        return connecton.ExecuteAsync(procedure,
          new
          {
            sTimeparam        = weatherData.Time,
            ortParam          = weatherData.Ort,
            tempMaxParam      = weatherData.TempMax,
            tempMinParam      = weatherData.TempMin,
            tempCurrentParam  = weatherData.TempCurrent,
            descriptionParam  = weatherData.Description
          },
          commandType: System.Data.CommandType.StoredProcedure);
      }
    }
  }
}
