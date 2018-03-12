using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HBoard.Business.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            catch (Exception e)
            {
                // Log error
                throw;
            }
        }

        public async Task<IEnumerable<TrainStationDepartureModel>> GetDepartures(string stationId)
        {
            if (string.IsNullOrWhiteSpace(stationId)) return new HashSet<TrainStationDepartureModel>();

            try
            {
                using(var client = new HttpClient())
                {
                    var response = await client.GetAsync($"{_appSettings.PublicTransportSettings.BaseUrl}{_appSettings.PublicTransportSettings.LocationsUrl}/{stationId}/{_appSettings.PublicTransportSettings.DeparturesUrl}?lang={_appSettings.PublicTransportSettings.Culture}");
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(responseData);
                    var tokens = jObject["tabs"].ToList();
                    var trainTab = tokens.FirstOrDefault(token => token["id"].ToString().Equals("trein", StringComparison.InvariantCultureIgnoreCase));
                    var departures = trainTab["departures"].ToList();
                    var model = departures.Select(departure => departure.ToObject<TrainStationDepartureModel>());
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
