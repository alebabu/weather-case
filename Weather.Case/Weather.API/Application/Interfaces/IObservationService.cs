using Weather.API.Dto;

namespace Weather.API.Application.Interfaces
{
    public interface IObservationService
    {
        public Task<ObservationResponse> GetObservationsAsync(string? stationId, CancellationToken token, string period = "last-hour");
    }
}
