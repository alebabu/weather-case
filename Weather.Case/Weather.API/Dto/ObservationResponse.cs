using System.Text.Json.Serialization;

namespace Weather.API.Dto
{
    public class ObservationResponse
    {
        [JsonPropertyName("period")]
        public string Period { get; set; } = string.Empty;

        [JsonPropertyName("generatedAt")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("stationCount")]
        public int StationCount { get; set; }

        [JsonPropertyName("stations")]
        public List<WeatherStationDto> Stations { get; set; } = new List<WeatherStationDto>();
    }
}
