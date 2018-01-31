using System.Threading.Tasks;

namespace HBoard.Business.Maps
{
    public interface IMapsService
    {
        Task<string> GetDirections(string origin, string destination);
    }
}