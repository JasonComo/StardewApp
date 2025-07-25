using StardewShared.DTOs;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface ISettingService
{
    Task<SettingResDto> UpdateSettingsAsync(SettingUpdateDto dto);

    Task<SettingResDto> GetSettingByIdAsync(int id);
    
}