using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.DataAccess
{
  public interface IApiConnector
  {
    public Task<WeatherDataFromApiDTO> LoadWeatherFromApiByOrtAsync(SearchResultDTO orte);

   
  }
}
