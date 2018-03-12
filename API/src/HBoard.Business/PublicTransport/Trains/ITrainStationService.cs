using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBoard.Business.PublicTransport.Trains
{
    public interface ITrainStationService
    {
        Task<TrainLocationModel> SearchForStation(string query);
        Task<IEnumerable<TrainStationDepartureModel>> GetDepartures(string stationId);
    }
}
