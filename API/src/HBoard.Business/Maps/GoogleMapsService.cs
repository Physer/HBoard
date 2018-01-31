using System.Net.Http;
using System.Threading.Tasks;

namespace HBoard.Business.Maps
{
    public class GoogleMapsService : IMapsService
    {
        public async Task<string> GetDirections(string origin, string destination)
        {
            using(var client = new HttpClient())
            {
                //TODO: Put Maps URL here, configurable and of course with API key
                var response = await client.GetAsync("");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
