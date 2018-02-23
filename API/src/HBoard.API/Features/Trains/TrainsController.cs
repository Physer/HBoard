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

        [Route("departures/{stationName}")]
        public async Task<IActionResult> Get(string stationName)
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
    }
}
