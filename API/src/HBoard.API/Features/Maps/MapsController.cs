using Microsoft.AspNetCore.Mvc;

namespace HBoard.API.Features.Maps
{
    [Route("api/[controller]")]
    public class MapsController
    {
        public string Get()
        {
            return "Hello HBoard!";
        }
    }
}
