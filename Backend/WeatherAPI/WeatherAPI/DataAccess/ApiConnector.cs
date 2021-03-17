using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.Models;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.DataAccess
{
  public class ApiConnector : IApiConnector
  {
    //f3de9af35f786230cdfa898028003eee
    private string _apiKey;

    public ApiConnector(string apiKey)
    {
      _apiKey = apiKey;
    }

    public async Task<WeatherDataFromApiDTO> LoadWeatherFromApiByOrtAsync(SearchResultDTO orte)
    {
      //string ortToSearch = GetSingleDataFromOrteDTO(orte);
      var queryString = $"https://api.openweathermap.org/data/2.5/weather?q={GetSingleDataFromOrteDTO(orte)}&appid={_apiKey}";

      using (HttpResponseMessage responseMessage = await new HttpClient().GetAsync(queryString))
      {
        if (responseMessage.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<WeatherDataFromApiDTO>(await responseMessage.Content.ReadAsStringAsync());
          return result;

        }
        throw new Exception();
      }



    }


    private string GetSingleDataFromOrteDTO(SearchResultDTO dto)
    {
      return dto.Ort;
    }
  }
}
