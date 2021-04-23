using Newtonsoft.Json;
using Service.ApiConnector.DTOS;
using Service.ApiConnector.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI.DataAccess
{
  public class ApiConnector : IApiConnector
  {
    private string _apiKey;

    public ApiConnector(string apiKey)
    {
      _apiKey = apiKey;
    }


    private async Task<T> CallWeatherApi<T>(string query)
    {
      using (HttpResponseMessage responseMessage = await new HttpClient().GetAsync(query))
      {
        if (responseMessage.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
          return result;

        }
        throw new Exception();
      }
    }

    public async Task<ActualWeatherDTO> LoadWeatherActualAsync(ParameterDTO orte)
    {
      var queryString = $"https://api.openweathermap.org/data/2.5/weather?q={orte.Ort}&appid={_apiKey}";

      return await CallWeatherApi<ActualWeatherDTO>(queryString);
    }

    public async Task<WeatherDataFromApiModel> LoadWeatherForecastsAsync(ParameterDTO orte)
    {
      var queryString = $"https://api.openweathermap.org/data/2.5/onecall?lat={orte.Lat}&lon={orte.Lon}&exclude=current,daily,alerts,minutely&appid={_apiKey}";
      return await CallWeatherApi<WeatherDataFromApiModel>(queryString);
    }
  }
}
