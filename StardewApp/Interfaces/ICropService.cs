using StardewShared.DTOs;

namespace StardewApp.Interfaces
{
    public interface ICropService
    {

        Task<List<CropResDto>> GetAllCropsAsync();

        
    }
}
