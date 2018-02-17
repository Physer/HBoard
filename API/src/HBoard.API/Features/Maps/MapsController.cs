using HBoard.Business.Maps;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HBoard.API.Features.Maps
{
    [Route("api/[controller]")]
    public class MapsController : Controller
    {
        private readonly IMapsService _mapsService;

        public MapsController(IMapsService mapsService)
        {
            _mapsService = mapsService;
        }

        public async Task<IActionResult> Get(string origin, string destination)
        {
            try
            {
                return Ok(await _mapsService.GetDirections(WebUtility.UrlEncode(origin), WebUtility.UrlEncode(destination)));
            }
            catch(Exception e)
            {
                // Log error
                return BadRequest($"Something went wrong: {e.Message}");
            }
        }
    }
}
