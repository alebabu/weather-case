using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Weather.Integration.Models
{
    public class SmhiDataResponse
    {
        [JsonPropertyName("value")]
        public List<SmhiValue> Value { get; set; } = default!;

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("parameter")]
        public SmhiParameterInfo Parameter { get; set; } = default!;

        [JsonPropertyName("station")]
        public SmhiStationInfo Station { get; set; } = default!;

        [JsonPropertyName("period")]
        public SmhiPeriod Period { get; set; }

        [JsonPropertyName("position")]
        public List<SmhiPosition> Position { get; set; } = default!;

        [JsonPropertyName("link")]
        public List<SmhiLink> Link { get; set; } = default!;
    }

    public class SmhiValue
    {
        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; } = string.Empty;

        [JsonPropertyName("quality")]
        public string Quality { get; set; } = string.Empty;
    }

    public class SmhiParameterInfo
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;
    }

    public class SmhiStationInfo
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = string.Empty;

        [JsonPropertyName("ownerCategory")]
        public string OwnerCategory { get; set; } = string.Empty;

        [JsonPropertyName("measuringStations")]
        public string MeasuringStations { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public double Height { get; set; }
    }

    public class SmhiPeriod
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("to")]
        public long To { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("sampling")]
        public string Sampling { get; set; } = string.Empty;
    }

    public class SmhiPosition
    {
        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("to")]
        public long To { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonIgnore]
        public DateTime FromDate => DateTimeOffset.FromUnixTimeMilliseconds(From).UtcDateTime;

        [JsonIgnore]
        public DateTime ToDate => DateTimeOffset.FromUnixTimeMilliseconds(To).UtcDateTime;
    }

    public class SmhiLink
    {
        [JsonPropertyName("rel")]
        public string Rel { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;

        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;
    }

}
