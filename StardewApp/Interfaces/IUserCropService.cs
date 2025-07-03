using StardewApp.DTOs;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface IUserCropService
{
    Task<UserCropResDto> AddUserCropAsync(UserCropCreateDto dto);
    
    Task<UserCropResDto> UpdateUserCropAsync(UserCropUpdateDto dto);
    
    Task<List<UserCropResDto>> GetAllUserCropsAsync();
    
    Task<bool> DeleteUserCropAsync(int id);
}