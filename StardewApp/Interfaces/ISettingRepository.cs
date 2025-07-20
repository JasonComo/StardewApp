using StardewShared.DTOs;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface ISettingRepository
{
    Task<Setting> UpdateAsync(Setting setting);
    
    Task<Setting?> GetByIdAsync(int id);

}