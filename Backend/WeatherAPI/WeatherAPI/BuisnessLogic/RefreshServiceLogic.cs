using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Domains;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.Controllers
{
  public class WeatherUpdateService : IHostedService
  {

    private int _updatesInSeconds = 600;
    private readonly ILogger<WeatherUpdateService> _logger;
    private Timer _timer;
    private MySqlConnection _connection;
    private string _apiKey;

    public WeatherUpdateService(Connection connection)
    {
      _connection = connection.SqlConnection;
      _apiKey = connection.ApiKey;
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
      if(cancellationToken.IsCancellationRequested)
      {
       // _logger.LogError("Cancelation before start of the timer");
        cancellationToken.ThrowIfCancellationRequested();
      }
      //_timer = new Timer(async x => Console.WriteLine("timer"), null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));
      _timer = new Timer(async x => await WeatherUpdateDatabaseBuisnessLogic.GetWeatherAndSaveAsync(QueryString.weatherByOrt(,
                                                                                                    _connection), 
                                                                                                    null, 
                                                                                                    TimeSpan.FromSeconds(0), 
                                                                                                    TimeSpan.FromSeconds(_updatesInSeconds));
      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _timer.Dispose();
      Console.WriteLine("tschau");
      return Task.CompletedTask;
    }
  }
}
