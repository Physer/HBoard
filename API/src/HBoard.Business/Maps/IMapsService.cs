using System.Threading.Tasks;

namespace HBoard.Business.Maps
{
    public interface IMapsService
    {
        Task<TravelDetailsModel> GetDirections(string origin, string destination);
    }
}