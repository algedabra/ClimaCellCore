using Newtonsoft.Json;
using System;

namespace ClimaCellCore.Models
{
    public class Temp
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class FeelsLike
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class Dewpoint
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class WindSpeed
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class WindGust
    {

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class BaroPressure
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class Visibility
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class Humidity
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class WindDirection
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class Precipitation
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class PrecipitationType
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class CloudCover
    {

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }
    }

    public class Sunrise
    {

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class Sunset
    {

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class MoonPhase
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class WeatherCode
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class ObservationTime
    {

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class RealTime
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("temp")]
        public Temp Temp { get; set; }

        [JsonProperty("feels_like")]
        public FeelsLike FeelsLike { get; set; }

        [JsonProperty("dewpoint")]
        public Dewpoint Dewpoint { get; set; }

        [JsonProperty("wind_speed")]
        public WindSpeed WindSpeed { get; set; }

        [JsonProperty("wind_gust")]
        public WindGust WindGust { get; set; }

        [JsonProperty("baro_pressure")]
        public BaroPressure BaroPressure { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }

        [JsonProperty("humidity")]
        public Humidity Humidity { get; set; }

        [JsonProperty("wind_direction")]
        public WindDirection WindDirection { get; set; }

        [JsonProperty("precipitation")]
        public Precipitation Precipitation { get; set; }

        [JsonProperty("precipitation_type")]
        public PrecipitationType PrecipitationType { get; set; }

        [JsonProperty("cloud_cover")]
        public CloudCover CloudCover { get; set; }

        [JsonProperty("sunrise")]
        public Sunrise Sunrise { get; set; }

        [JsonProperty("sunset")]
        public Sunset Sunset { get; set; }

        [JsonProperty("moon_phase")]
        public MoonPhase MoonPhase { get; set; }

        [JsonProperty("weather_code")]
        public WeatherCode WeatherCode { get; set; }

        [JsonProperty("observation_time")]
        public ObservationTime ObservationTime { get; set; }
    }

}
