using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Weather.API.Dto
{
    public class WeatherStationDto
    {
        [JsonPropertyName("stationId")]
        public long StationId { get; set; }

        [JsonPropertyName("stationName")]
        public string StationName { get; set; } = string.Empty;

        [JsonPropertyName("airTemperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WeatherParameter? AirTemperature { get; set; } = null;

        [JsonPropertyName("windGust")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WeatherParameter? WindGust { get; set; } = null;
    }

    public class WeatherParameter
    {
        [JsonPropertyName("parameter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WeatherParameterInfo? Parameter { get; set; } = null;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = string.Empty;

        [JsonPropertyName("ownerCategory")]
        public string OwnerCategory { get; set; } = string.Empty;

        [JsonPropertyName("measuringStations")]
        public string MeasuringStations { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("positions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<WeatherPosition> Positions { get; set; } = new List<WeatherPosition>();

        [JsonPropertyName("values")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<WeatherValue> Values { get; set; } = new List<WeatherValue>();
    }

    public class WeatherParameterInfo
    {
        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;
    }
    public class WeatherPosition
    {
        [JsonPropertyName("from")]
        public DateTimeOffset From { get; set; }

        [JsonPropertyName("to")]
        public DateTimeOffset To { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class WeatherValue
    {
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("quality")]
        public string Quality { get; set; }
    }

}
