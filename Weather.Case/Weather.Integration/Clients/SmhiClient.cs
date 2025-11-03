using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<SmhiParameterResponse> GetAllStationsAsync(SmhiInputParameter parameter, CancellationToken token)
        {
            var path = $"{BASE_URL}/parameter/{parameter.ToString()}.json";

            var result = await _client.GetFromJsonAsync<SmhiParameterResponse>(path, token);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Could not get any data from the request.");
            }
        }

        public async Task<SmhiDataResponse> GetDataAsync(SmhiInputParameter parameter, int stationId, CancellationToken token, SmhiInputPeriod period = SmhiInputPeriod.LatestHour)
        {
            var path = $"{BASE_URL}/parameter/{parameter.ToString()}/station/{stationId}/period/{period.ToApiValue()}.json";

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
