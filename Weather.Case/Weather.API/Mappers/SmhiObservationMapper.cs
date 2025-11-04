using System.Reflection.Metadata;
using Weather.API.Dto;
using Weather.Integration.Models;

namespace Weather.API.Mappers
{
    public class SmhiObservationMapper
    {
        public WeatherStationDto MapStationObservation(
            long stationId,
            SmhiDataResponse? tempData,
            SmhiDataResponse? gustData)
        {
            // Get station name
            var stationName = string.Empty;

            if (!string.IsNullOrWhiteSpace(tempData?.Station?.Name))
            {
                stationName = tempData.Station.Name;
            }
            else if (!string.IsNullOrWhiteSpace(gustData?.Station?.Name))
            {
                stationName = gustData.Station.Name;
            }

            return new WeatherStationDto
            {
                StationId = stationId,
                StationName = stationName,
                AirTemperature = tempData != null ? MapWeatherParameter(tempData) : null,
                WindGust = gustData != null ? MapWeatherParameter(gustData) : null
            };
        }

        private WeatherParameter MapWeatherParameter(SmhiDataResponse data)
        {
            return new WeatherParameter
            {
                Parameter = new WeatherParameterInfo
                {
                    Summary = data.Parameter != null ? data.Parameter.Summary : string.Empty,
                    Unit = data.Parameter != null ? data.Parameter.Unit : string.Empty,
                },
                Owner = data.Station != null ? data.Station.Owner : string.Empty,
                OwnerCategory = data.Station != null ? data.Station.OwnerCategory : string.Empty,
                MeasuringStations = data.Station != null ? data.Station.MeasuringStations : string.Empty,
                Height = data.Station != null ? data.Station.Height : default!,
                Positions = data.Position is not null
                    ? GetWeatherPositions(data.Position!)
                    : default!,
                Values = data.Value is not null
                    ? GetWeatherValues(data.Value!)
                    : default!
            };
        }

        private List<WeatherPosition> GetWeatherPositions(List<SmhiPosition> positions)
        {
            return positions.Select(x => 
                new WeatherPosition
                {
                    From = DateTimeOffset.FromUnixTimeMilliseconds(x.From),
                    To = DateTimeOffset.FromUnixTimeMilliseconds(x.To),
                    Height = x.Height,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                }).ToList();
        }

        private List<WeatherValue> GetWeatherValues(List<SmhiValue> values)
        {
            return values.Select(x =>
            new WeatherValue
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(x.Date),
                Value = double.TryParse(x.Value, out var parsedValue) ? parsedValue : default,
                Quality = x.Quality
            }).ToList();
        }
    }
}
