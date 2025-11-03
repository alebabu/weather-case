using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Integration.Models;

namespace Weather.Integration.ClientInterfaces
{
    public interface ISmhiClient
    {
        public Task<SmhiParameterResponse> GetAllStationsAsync(SmhiInputParameter parameter, CancellationToken token);

        public Task<SmhiDataResponse> GetDataAsync(SmhiInputParameter parameter, int stationId, CancellationToken token, SmhiInputPeriod period = SmhiInputPeriod.LatestHour);
    }
}
