using StardewApp.Interfaces;
using StardewApp.Models;
using StardewApp.DTOs;
using StardewApp.Mappings;
using AutoMapper;

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

    public async Task<SettingResDto> UpdateLevelAndIsTillerAsync(SettingUpdateLITDto dto)
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

        var updated = await _settingRepo.UpdateLevelAndIsTillerAsync(setting);
        return _mapper.Map<SettingResDto>(updated);
    }
}