using System.Collections.Concurrent;
using System.Collections.Generic;
using Weather.API.Application.Interfaces;
using Weather.API.Dto;
using Weather.API.Mappers;
using Weather.Integration.ClientInterfaces;
using Weather.Integration.Models;

namespace Weather.API.Application.Services
{
    public class ObservationService : IObservationService
    {
        private readonly ISmhiClient _client;
        private readonly ILogger<ObservationService> _logger;
        private readonly SmhiObservationMapper _mapper;

        public ObservationService(
            ISmhiClient client,
            ILogger<ObservationService> logger,
            SmhiObservationMapper mapper)
        {
            _client = client;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ObservationResponse> GetObservationsAsync(string? stationId, CancellationToken token, string period = "last-hour")
        {
            var stationIds = await GetAllStationIds(token);

            if (!string.IsNullOrWhiteSpace(stationId) && long.TryParse(stationId, out var stationIdLong))
            {
                stationIds = stationIds.Where(x => x.Id == stationIdLong).ToList();
            }

            var results = new ConcurrentBag<WeatherStationDto>();
            var sem = new SemaphoreSlim(6);

            await Task.WhenAll(stationIds.Select(async station =>
            {
                await sem.WaitAsync(token);

                try
                {
                    SmhiDataResponse? tempData = null;
                    SmhiDataResponse? gustData = null;

                    if (station.IsTempStation)
                    {
                        tempData = await _client.GetDataAsync(SmhiInputParameter.AirTemperatureInstantHourly, station.Id, token, ParsePeriod(period));
                    }

                    if (station.IsGustStation)
                    {
                        gustData = await _client.GetDataAsync(SmhiInputParameter.WindGustMaxHourly, station.Id, token, ParsePeriod(period));
                    }

                     var mapped = _mapper.MapStationObservation(station.Id, tempData, gustData);
                     results.Add(mapped);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to fetch data for station {StationId}", station.Id);
                }
                finally
                {
                    sem.Release();
                }
            }));

            return new ObservationResponse
            {
                Period = period,
                GeneratedAt = DateTime.Now,
                StationCount = stationIds.Count,
                Stations = results.OrderBy(x => x.StationId).ToList()
            };
        }

        private async Task<List<(long Id, bool IsTempStation, bool IsGustStation)>> GetAllStationIds(CancellationToken token)
        {
            var stationIds = new List<(long Id, bool IsTempStation, bool IsGustStation)>();

            var tempStations = await _client.GetAllStationsAsync(SmhiInputParameter.AirTemperatureInstantHourly, token);
            var gustStations = await _client.GetAllStationsAsync(SmhiInputParameter.WindGustMaxHourly, token);

            stationIds.AddRange(tempStations.Select(x => (x.Id, true, false)));

            foreach (var item in gustStations)
            {
                if (!stationIds.Select(x => x.Id).Contains(item.Id))
                {
                    stationIds.Add((item.Id, false, true));
                }
                else
                {
                    int index = stationIds.FindIndex(i => i.Id == item.Id);

                    if (index >= 0)
                    {
                        stationIds[index] = (item.Id, true, true);
                    }
                }
            }

            return stationIds;
        }

        private static SmhiInputPeriod ParsePeriod(string p) =>
            p.ToLowerInvariant() switch
            {
                "last-hour" or "hour" => SmhiInputPeriod.LatestHour,
                _ => SmhiInputPeriod.LatestDay
            };
    }
}
