using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Weather.Integration.Models
{
    public class SmhiSampleResponse
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = string.Empty;

        [JsonPropertyName("valueType")]
        public string ValueType { get; set; } = string.Empty;

        [JsonPropertyName("link")]
        public Link[] Link { get; set; } = default!;

        [JsonPropertyName("stationSet")]
        public Stationset[] StationSet { get; set; } = default!;

        [JsonPropertyName("station")]
        public Station[] Station { get; set; } = default!;
    }

    public class Link
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = string.Empty;

        [JsonPropertyName("rel")]
        public string Rel { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
    }

    public class Stationset
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("link")]
        public Link[] Link { get; set; } = default!;
    }

    public class Station
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;

        [JsonPropertyName("updated")]
        public long Updated { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = string.Empty;

        [JsonPropertyName("link")]
        public Link[] Link { get; set; } = default!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = string.Empty;

        [JsonPropertyName("ownerCategory")]
        public string OwnerCategory { get; set; } = string.Empty;

        [JsonPropertyName("measuringStations")]
        public string MeasuringStations { get; set; } = string.Empty;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("height")]
        public float Height { get; set; }

        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("to")]
        public long To { get; set; }
    }
}
