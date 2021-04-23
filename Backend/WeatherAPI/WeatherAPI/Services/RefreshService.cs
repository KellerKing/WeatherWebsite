using Microsoft.Extensions.Hosting;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.DataAccess;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Domains;

namespace WeatherAPI.Controllers
{
  public class RefreshService : IHostedService
  {

    private int _updatesInSeconds = 10; // 360;
    private int _clearsInSeconds = 10; //86400;
    private int _actualWeatherInSeconds = 10; //360;
    private Timer _dbUpdateTimer;
    private Timer _dbClearOldEntriesTimer;
    private Timer _dbRefreshActualWeather;

    private MySqlConnection _connection;
    private string _apiKey;

    public RefreshService(ConnectionData connection)
    {
      _connection = connection.SqlConnection;
      _apiKey = connection.ApiKey;
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
      if (cancellationToken.IsCancellationRequested)
        cancellationToken.ThrowIfCancellationRequested();

      _dbUpdateTimer = new Timer(async x => await WeatherUpdateBuisnessLogic.GetWeatherForecastsAndSave(
                                                                                      new DatabaseConnector(_connection.Clone()),
                                                                                      new ApiConnector(_apiKey)),
                                                                                      null,
                                                                                      TimeSpan.FromSeconds(0),
                                                                                      TimeSpan.FromSeconds(_updatesInSeconds));

      _dbClearOldEntriesTimer = new Timer(async x => await WeatherUpdateBuisnessLogic.DeleteObsoleteWeather(new DatabaseConnector(_connection.Clone())),
                                                                                      null,
                                                                                      TimeSpan.FromSeconds(0),
                                                                                      TimeSpan.FromSeconds(_clearsInSeconds));

      _dbRefreshActualWeather = new Timer(async x => await WeatherUpdateBuisnessLogic.GetCurrentWeatherAndSave(
                                                                                new DatabaseConnector(_connection.Clone()),
                                                                                new ApiConnector(_apiKey)),
                                                                                null,
                                                                                TimeSpan.FromSeconds(0),
                                                                                TimeSpan.FromSeconds(_clearsInSeconds));

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _dbUpdateTimer.Dispose();
      _dbClearOldEntriesTimer.Dispose();
      Console.WriteLine("Timer verabschiedet sich !");
      return Task.CompletedTask;
    }
  }
}
