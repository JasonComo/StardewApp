using StardewApp.DTOs;
using StardewApp.Models;

namespace StardewApp.Interfaces;

public interface ISettingService
{
    Task<SettingResDto> UpdateLevelAndIsTillerAsync(SettingUpdateLITDto dto);
}