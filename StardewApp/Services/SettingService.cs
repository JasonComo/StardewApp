using StardewApp.Interfaces;
using StardewApp.Models;
using StardewShared.DTOs;
using StardewApp.Mappings;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StardewApp.Services;

public class SettingService : ISettingService
{
    private readonly ISettingRepository _settingRepo;
    private readonly IMapper _mapper;

    public SettingService(ISettingRepository settingRepo, IMapper mapper)
    {
        _settingRepo = settingRepo;
        _mapper  = mapper;
    }

    public async Task<SettingResDto> UpdateSettingsAsync(SettingUpdateDto dto)
    {
        if (dto == null || dto.Id <= 0)
        {
            return null;
        };

        if (dto.Level < 0 || dto.Level > 14)
        {
            return null;
        }
        
        var setting = await _settingRepo.GetByIdAsync(dto.Id);
        if (setting == null)
            return null;
        

        setting.Level = dto.Level;
        setting.IsTiller = dto.IsTiller;

        var updated = await _settingRepo.UpdateAsync(setting);
        return _mapper.Map<SettingResDto>(updated);
    }

    public async Task<SettingResDto> GetSettingByIdAsync(int id)
    {
        var setting = await _settingRepo.GetByIdAsync(id);
        return _mapper.Map<SettingResDto>(setting);
    }


}