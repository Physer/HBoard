using HBoard.Business.Maps;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HBoard.API.Features.Maps
{
    [Route("api/[controller]")]
    public class MapsController
    {
        private readonly IMapsService _mapsService;

        public MapsController(IMapsService mapsService)
        {
            _mapsService = mapsService;
        }

        public async Task<string> Get() => await _mapsService.GetDirections(string.Empty, string.Empty);
    }
}
