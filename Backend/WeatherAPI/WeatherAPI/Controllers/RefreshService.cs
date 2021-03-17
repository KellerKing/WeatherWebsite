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

    private int _updatesInSeconds = 10;
    private Timer _dbUpdateTimer;

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

      _dbUpdateTimer = new Timer(async x => await WeatherUpdateBuisnessLogic.GetWeatherAndSave(_connection,
                                                                                      new DatabaseConnector(),
                                                                                      new ApiConnector(_apiKey)),
                                                                                      null,
                                                                                      TimeSpan.FromSeconds(0),
                                                                                      TimeSpan.FromSeconds(_updatesInSeconds));

      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _dbUpdateTimer.Dispose();
      Console.WriteLine("Timer verabschiedet sich !");
      return Task.CompletedTask;
    }
  }
}
