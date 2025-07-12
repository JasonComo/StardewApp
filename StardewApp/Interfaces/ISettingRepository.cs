using StardewApp.DTOs;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface ISettingRepository
{
    Task<Setting> UpdateLevelAndIsTillerAsync(Setting setting);
    
    Task<Setting?> GetByIdAsync(int id);

}