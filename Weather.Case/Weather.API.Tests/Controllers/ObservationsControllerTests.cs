using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Net.Http.Json;
using Weather.API.Application.Interfaces;
using Weather.API.Dto;

namespace Weather.API.Tests.Controllers
{
    public class ObservationsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ObservationsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(b =>
            {
                b.ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        ["X-API-KEY"] = "Valid-Key",
                    });
                });

                b.ConfigureServices(services =>
                {
                    var mock = new Mock<IObservationService>();
                    mock.Setup(s => s.GetObservationsAsync("92410", It.IsAny<CancellationToken>(), "last-hour"))
                        .ReturnsAsync(new ObservationResponse
                        {
                            Period = "last-hour",
                            GeneratedAt = DateTime.UtcNow,
                            StationCount = 1,
                            Stations = new() { new WeatherStationDto { StationId = 92410 } }
                        });

                    services.AddSingleton(mock.Object);
                });
            });
        }

        [Fact]
        public async Task Swagger_Loads()
        {
            var client = _factory.CreateClient();
            var res = await client.GetAsync("/swagger/index.html");
            res.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_ByStation_Returns200_AndStation()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("X-API-Key", "Valid-Key");
            var res = await client.GetAsync("/api/observations?stationId=92410&period=last-hour");

            res.EnsureSuccessStatusCode();

            var observation = await res.Content.ReadFromJsonAsync<ObservationResponse>();

            Assert.Equal(92410, observation?.Stations.First().StationId);
        }
    }

}
