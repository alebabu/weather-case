using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using Weather.Integration.ClientInterfaces;
using Weather.Integration.Extensions;
using Weather.Integration.Models;

namespace Weather.Integration.Clients
{
    public class SmhiClient : ISmhiClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<SmhiClient> _logger;

        private const string BASE_URL = "https://opendata-download-metobs.smhi.se/api/version/latest";

        public SmhiClient(HttpClient client, ILogger<SmhiClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<SmhiStation>> GetAllStationsAsync(SmhiInputParameter parameter, CancellationToken token)
        {
            var path = $"{BASE_URL}/parameter/{(int) parameter}.json";

            var response = await _client.GetFromJsonAsync<SmhiParameterResponse>(path, token);

            if (response != null)
            {
                var stations = response.Station;

                return stations;
            }
            else
            {
                throw new KeyNotFoundException("Could not get any data from the request.");
            }
        }

        public async Task<SmhiDataResponse> GetDataAsync(SmhiInputParameter parameter, long stationId, CancellationToken token, SmhiInputPeriod period = SmhiInputPeriod.LatestHour)
        {
            var path = $"{BASE_URL}/parameter/{(int) parameter}/station/{stationId}/period/{period.ToApiValue()}/data.json";

            var result = await _client.GetFromJsonAsync<SmhiDataResponse>(path, token);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Could not get any data from the request.");
            }
        }
    }
}
