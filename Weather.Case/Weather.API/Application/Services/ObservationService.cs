using Weather.API.Application.Interfaces;
using Weather.API.Dto;

namespace Weather.API.Application.Services
{
    public class ObservationService : IObservationService
    {
        public Task<ObservationResponse> GetObservation(string stationId, string range)
        {
            throw new NotImplementedException();
        }
    }
}
