using HBoard.Business.Settings;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace HBoard.Business.Maps
{
    public class GoogleMapsService : IMapsService
    {
        private readonly ApplicationSettings _appSettings;

        public GoogleMapsService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<string> GetDirections(string origin, string destination)
        {
            origin = "Houten";
            destination = "Utrecht";
            using(var client = new HttpClient())
            {
                //TODO: Encode parameters
                var response = await client.GetAsync($"{_appSettings.MapsSettings.BaseUrl}?origin={origin}&destination={destination}&key={_appSettings.MapsSettings.ApiKey}");
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
