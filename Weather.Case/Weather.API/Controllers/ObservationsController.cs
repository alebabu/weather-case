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
        /// <param name="period">last-hour|last-day (default=LastHour)</param>
        [HttpGet]
        [ProducesResponseType(typeof(ObservationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> Get([FromQuery] string? stationId, [FromQuery] string period = "last-hour")
        {
            try
            {
                var result = await _service.GetObservationsAsync(stationId, HttpContext.RequestAborted, period);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching observations");
                return StatusCode(502, new { message = "Failed to fetch data from SMHI." });
            }
        }

    }
}
