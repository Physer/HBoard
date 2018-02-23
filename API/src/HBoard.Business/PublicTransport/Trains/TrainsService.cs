using System;
using System.Net.Http;
using System.Threading.Tasks;
using HBoard.Business.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HBoard.Business.PublicTransport.Trains
{
    public class TrainsService : ITrainStationService
    {
        private readonly ApplicationSettings _appSettings;

        public TrainsService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<TrainLocationModel> SearchForStation(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return new TrainLocationModel();

            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{_appSettings.PublicTransportSettings.BaseUrl}{_appSettings.PublicTransportSettings.LocationsUrl}?lang={_appSettings.PublicTransportSettings.Culture}&q={query}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<TrainLocationModel>(responseData);
                    return model;
                }
            }
            catch(Exception e)
            {
                // Log error
                throw;
            }
        }
    }
}
