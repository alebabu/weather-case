using System.Text.Json.Serialization;

public class SmhiParameterResponse
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
    public List<SmhiLink> Link { get; set; } = default!;

    [JsonPropertyName("stationSet")]
    public List<SmhiStationSet> StationSet { get; set; } = default!;

    [JsonPropertyName("station")]
    public List<SmhiStation> Station { get; set; } = default!;
}

public class SmhiLink
{
    [JsonPropertyName("href")]
    public string Href { get; set; } = string.Empty;

    [JsonPropertyName("rel")]
    public string Rel { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

public class SmhiStationSet
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
    public List<SmhiLink> Link { get; set; } = default!;
}

public class SmhiStation
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
    public List<SmhiLink> Link { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty;

    [JsonPropertyName("ownerCategory")]
    public string OwnerCategory { get; set; } = string.Empty;

    [JsonPropertyName("measuringStations")]
    public string MeasuringStations { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("height")]
    public double Height { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; }

    [JsonPropertyName("from")]
    public long From { get; set; }

    [JsonPropertyName("to")]
    public long To { get; set; }
}