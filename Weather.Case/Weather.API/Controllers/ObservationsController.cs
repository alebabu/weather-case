using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.API.Application.Interfaces;
using Weather.API.Dto;

namespace Weather.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationsController : ControllerBase
    {
        private readonly IObservationService _service;
        private readonly ILogger<ObservationsController> _logger;

        public ObservationsController(
            IObservationService service,
            ILogger<ObservationsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Returns merged temperature and wind gust data.
        /// </summary>
        /// <param name="stationId">Optional station ID</param>
        /// <param name="range">hour|day (default=hour)</param>
        [HttpGet]
        [ProducesResponseType(typeof(ObservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Get([FromQuery] string? stationId, [FromQuery] string? range = "hour")
        {
            //var result = await _service.GetObservation(stationId, range);

            var resultTemp = new ObservationResponse();

            return Ok(resultTemp);
        }

    }
}
