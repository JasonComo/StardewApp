using System.Net.Http.Json;
using StardewShared.DTOs;
namespace StardewClient.Services
{
    public class CropService
    {
        private readonly HttpClient _http;

        public CropService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CropResDto>> GetCropsAsync()
        {
            return await _http.GetFromJsonAsync<List<CropResDto>>("api/Crop");
        }
    }
}
