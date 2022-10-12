using SEDC.Lamazon.Services.Models;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IGeoTrackerService
    {
        Task<IpGeoInfo> GetIpGeoInfo(string ipAddress);
        Task<string> GetCountryFlag(string countryCode);
    }
}
