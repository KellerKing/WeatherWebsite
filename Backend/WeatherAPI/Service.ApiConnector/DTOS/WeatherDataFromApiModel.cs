using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ApiConnector.DTOS
{

  public class WeatherDataFromApiModel
  {
    [JsonProperty("lat")]
    public double Lat { get; set; }

    [JsonProperty("lon")]
    public double Lon { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("timezone_offset")]
    public int TimezoneOffset { get; set; }

    [JsonProperty("hourly")]
    public List<Hourly> Hourly { get; set; }
  }


  public class Weather
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("main")]
    public string Main { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }
  }

  public class Rain
  {
    [JsonProperty("1h")]
    public double _1h { get; set; }
  }

  public class Hourly
  {
    [JsonProperty("dt")]
    public int Dt { get; set; }

    [JsonProperty("temp")]
    public double Temp { get; set; }

    [JsonProperty("feels_like")]
    public double FeelsLike { get; set; }

    [JsonProperty("pressure")]
    public int Pressure { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }

    [JsonProperty("dew_point")]
    public double DewPoint { get; set; }

    [JsonProperty("uvi")]
    public double Uvi { get; set; }

    [JsonProperty("clouds")]
    public int Clouds { get; set; }

    [JsonProperty("visibility")]
    public int Visibility { get; set; }

    [JsonProperty("wind_speed")]
    public double WindSpeed { get; set; }

    [JsonProperty("wind_deg")]
    public int WindDeg { get; set; }

    [JsonProperty("wind_gust")]
    public double WindGust { get; set; }

    [JsonProperty("weather")]
    public List<Weather> Weather { get; set; }

    [JsonProperty("pop")]
    public double Pop { get; set; }

    [JsonProperty("rain")]
    public Rain Rain { get; set; }
  }

  

}
