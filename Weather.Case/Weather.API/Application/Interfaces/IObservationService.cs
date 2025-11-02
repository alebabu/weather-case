using Weather.API.Dto;

namespace Weather.API.Application.Interfaces
{
    public interface IObservationService
    {
        public Task<ObservationResponse> GetObservation(string stationId, string range);
    }
}
