using Newtonsoft.Json;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Services.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class GeoTrackerService : BaseService, IGeoTrackerService
    {
        private readonly HttpClient _httpClient;
        public GeoTrackerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetCountryFlag(string countryCode)
        {
            return $"https://countryflagsapi.com/png/{countryCode}";
        }

        public async Task<IpGeoInfo> GetIpGeoInfo(string ipAddress)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"http://ip-api.com/json/{ipAddress}");
            var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IpGeoInfo>(jsonData);
        }
    }
}
