using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.ServiceLibrary.Entities;

namespace WeatherAPI.ServiceLibrary.Repos
{
 public class OpenWeatherRepo
  {
    public static async Task<WeatherDataFromApiDTO> TestAsync(string testString)
    {
      using(HttpResponseMessage responseMessage = await new HttpClient().GetAsync(testString))
      {
        if(responseMessage.IsSuccessStatusCode)
        {
          var result = JsonConvert.DeserializeObject<WeatherDataFromApiDTO>(await responseMessage.Content.ReadAsStringAsync());
          return result;
         
        }
        throw new Exception();
      }
    }
  }
}
