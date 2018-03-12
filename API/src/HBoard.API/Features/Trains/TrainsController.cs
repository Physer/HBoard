using System;
using System.Threading.Tasks;
using HBoard.Business.PublicTransport.Trains;
using Microsoft.AspNetCore.Mvc;

namespace HBoard.API.Features.Trains
{
    [Route("api/[controller]")]
    public class TrainsController : Controller
    {
        private readonly ITrainStationService _stationService;

        public TrainsController(ITrainStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("stations/{stationName}")]
        public async Task<IActionResult> GetStation(string stationName)
        {
            try
            {
                return Ok(await _stationService.SearchForStation(stationName));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("departures/{stationId}")]
        public async Task<IActionResult> GetDepartures(string stationId)
        {
            try
            {
                return Ok(await _stationService.GetDepartures(stationId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
