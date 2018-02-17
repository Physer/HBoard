using HBoard.Business.Settings;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System;
using Newtonsoft.Json.Linq;

namespace HBoard.Business.Maps
{
    public class GoogleMapsService : IMapsService
    {
        private readonly ApplicationSettings _appSettings;

        public GoogleMapsService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<TravelDetailsModel> GetDirections(string origin, string destination)
        {
            // This is a happy flow scenario now, also figure out a way
            // on how to properly parse both success and error messages from the Directions API
            // Preferably make this a generic way of reading those succesful and unsuccesful messages
            using(var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"{_appSettings.MapsSettings.BaseUrl}?origin={origin}&destination={destination}&key={_appSettings.MapsSettings.ApiKey}");
                    var mapsResponseString = await response.Content.ReadAsStringAsync();
                    var mapsResponseObject = JObject.Parse(mapsResponseString);
                    var distance = mapsResponseObject["routes"][0]["legs"][0]["distance"]["text"].ToString();
                    var duration = mapsResponseObject["routes"][0]["legs"][0]["duration"]["text"].ToString();
                    var startAddress = mapsResponseObject["routes"][0]["legs"][0]["start_address"].ToString();
                    var endAddress = mapsResponseObject["routes"][0]["legs"][0]["end_address"].ToString();
                    var detailsModel = new TravelDetailsModel
                    {
                        Distance = distance,
                        Duration = duration,
                        EndAddress = endAddress,
                        StartAddress = startAddress
                    };
                    return detailsModel;
                }
                catch(Exception e)
                {
                    // Log Exception
                    throw;
                }
            }
        }
    }
}
