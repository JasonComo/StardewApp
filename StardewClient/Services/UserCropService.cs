using System.Net.Http.Json;
using StardewShared.DTOs;

namespace StardewClient.Services;

public class UserCropService
{
    private readonly HttpClient _http;

    public UserCropService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<UserCropResDto>> GetUserCropsAsync()
    {
        return await _http.GetFromJsonAsync<List<UserCropResDto>>("api/UserCrop");
        
    }



    
}