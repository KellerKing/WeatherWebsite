using Service.ApiConnector.DTOS;
using System.Threading.Tasks;


namespace Service.ApiConnector.Interface
{
  public interface IApiConnector
  {
    public Task<WeatherDataFromApiModel> LoadWeatherForecastsAsync(ParameterDTO orte);
    public Task<ActualWeatherDTO> LoadWeatherActualAsync(ParameterDTO orte);

  }
}
