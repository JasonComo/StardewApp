using StardewShared.DTOs;
using StardewShared.Enums;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface IUserCropService
{
    Task<UserCropResDto> AddUserCropAsync(UserCropCreateDto dto);
    
    Task<UserCropResDto> UpdateUserCropAsync(UserCropUpdateDto dto);
    
    Task<List<UserCropResDto>> GetAllUserCropsAsync();
    
    Task<bool> DeleteUserCropAsync(int id);
    
    Task<float> CalculateUserCropProfitAsync(int id, Fertilizer fertilizer, int quantity);

    Task<float> CalculateTotalUserCropProfitAsync();
}