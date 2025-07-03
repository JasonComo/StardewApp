using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface IUserCropRepository
{
    Task<List<UserCrop>> GetAllAsync();
    Task<UserCrop> AddAsync(UserCrop userCrop);
    Task<UserCrop> GetByIdAsync(int id);
    Task<UserCrop> UpdateAsync(UserCrop userCrop);
    Task<bool> DeleteAsync(int id);
}