using Dapper;
using MySqlConnector;
using Service.Database;
using Service.Database.Contracts;
using Service.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.DataAccess
{
  public class DatabaseConnector : IDatabaseConnector
  {
    private MySqlConnection _connection;

    public DatabaseConnector(MySqlConnection connection)
    {
      _connection = connection;
    }


    public void ClearOldTempEntries(DateTime beforeDate)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.ClearOldEntrys];

      _connection.Clone().ExecuteAsync(procedure, new { beforeTimeparam = beforeDate }, commandType: System.Data.CommandType.StoredProcedure);
    }

    public int DeleteTempById(List<TempDTO> ids)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.ClearOldEntrys];
      var myParams = ids.ToArray();
      return _connection.Clone().Execute(procedure, myParams, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<List<TempDTO>> GetAllActualAsync()
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.GetActuals];

      var actuals = await _connection.Clone().QueryAsync<TempDTO>(procedure, null, commandType: System.Data.CommandType.StoredProcedure);
      return actuals.ToList();
    }

    public List<OrtModel> GetAlleOrte()
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.select_orte];
      var orte = _connection.Clone().Query<OrtModel>(procedure, null, commandType: System.Data.CommandType.StoredProcedure).ToList();
      return orte;
    }

    public async Task<List<TempDTO>> GetAllForecastsAsync()
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.GetForecasts];


      var forecasts = await _connection.Clone().QueryAsync<TempDTO>(procedure, null, commandType: System.Data.CommandType.StoredProcedure);
      return forecasts.ToList();
    }

    public async Task<List<GemeindeDTO>> GetOrteToRefreshAsync()
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.GetAllOrteInDb];
      IEnumerable<GemeindeDTO> orte;

      orte = await _connection.Clone().QueryAsync<GemeindeDTO>(procedure, null, commandType: System.Data.CommandType.StoredProcedure);

      return orte.ToList();
    }

    public void SaveWeatherToDatabaseAsync(TempDTO weatherData)
    {
      var procedure = QueryCommands.commands[(int)CommandEnum.UpdateSigngleTempForecast];

      var result = _connection.Clone().Execute(procedure,
       new
       {
         sTimeParam = weatherData.Time,
         gemeindeParam = weatherData.Gemeinde,
         tempMaxParam = weatherData.TempMax,
         tempMinParam = weatherData.TempMin,
         tempCurrentParam = weatherData.TempCurrent,
         descriptionParam = weatherData.Description,
         typeParam = weatherData.Type
       },
       commandType: System.Data.CommandType.StoredProcedure);
    }
  }
}
