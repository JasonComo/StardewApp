using StardewApp.Models;
using StardewApp.Interfaces;
using StardewApp.DTOs;
using StardewApp.Mappings;
using AutoMapper;
namespace StardewApp.Services;

public class UserCropService : IUserCropService
{
    private readonly IUserCropRepository _userCropRepo;
    private readonly ICropRepository _cropRepo;
    private readonly ISettingRepository _settingRepo;
    private readonly IFertilizerMultiplierRepository _fertilizerMultiplierRepo;
    private readonly IMapper _mapper;

    public UserCropService(IUserCropRepository userCropRepo, ICropRepository cropRepository, ISettingRepository settingRepo, IMapper mapper)
    {
        _userCropRepo = userCropRepo;
        _cropRepo = cropRepository;
        _settingRepo = settingRepo;
        _mapper = mapper;
        
    }

    public async Task<UserCropResDto?> AddUserCropAsync(UserCropCreateDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.CropName))
            return null;

        if (!Enum.IsDefined(typeof(Fertilizer), dto.Fertilizer))
            return null;

        if (dto.Quantity < 0 || dto.Quantity > 9999)
            return null;
        
        var crop = await _cropRepo.GetByNameAsync(dto.CropName);
        if (crop == null)
            return null;

        var currentCrops = await _userCropRepo.GetAllAsync();
        
        bool isDuplicate = currentCrops.Any(uc => uc.CropId == crop.Id);
        if (isDuplicate)
            return null;

        var userCrop = new UserCrop
        {
            Crop = crop,
            CropId = crop.Id,
            Fertilizer = dto.Fertilizer,
            Quantity = dto.Quantity,
           
        };
        userCrop.Profit = await CalculateUserCropProfitAsync(userCrop.CropId, userCrop.Fertilizer, userCrop.Quantity);
        Console.WriteLine($"Calculated Profit: {userCrop.Profit}");
        var created = await _userCropRepo.AddAsync(userCrop);

        return _mapper.Map<UserCropResDto>(created);
    }
    public async Task<UserCropResDto?> UpdateUserCropAsync(UserCropUpdateDto dto)
    {
        
        if (!Enum.IsDefined(typeof(Fertilizer), dto.Fertilizer))
            return null;

        if (dto.Quantity < 0 || dto.Quantity > 9999)
            return null;
        
        var existing = await _userCropRepo.GetByIdAsync(dto.Id);
        if (existing == null)
            return null;

        existing.Fertilizer = dto.Fertilizer;
        existing.Quantity = dto.Quantity;
        existing.Profit = await CalculateUserCropProfitAsync(existing.CropId, existing.Fertilizer, existing.Quantity);

        var updated = await _userCropRepo.UpdateAsync(existing);
        
        updated.Crop = await _cropRepo.GetByIdAsync(updated.CropId);
        return _mapper.Map<UserCropResDto>(updated);

    }

    public async Task<List<UserCropResDto>> GetAllUserCropsAsync()
    {
        var userCrops = await _userCropRepo.GetAllAsync();

        return _mapper.Map<List<UserCropResDto>>(userCrops);

    }

    public async Task<bool> DeleteUserCropAsync(int id)
    {
       var result = await _userCropRepo.DeleteAsync(id);
       if (result) {return true;}
       return false;
    }

    public async Task<float> CalculateUserCropProfitAsync(int id, Fertilizer fertilizer, int quantity)
    {
        if (quantity < 0 || !Enum.IsDefined(typeof(Fertilizer), fertilizer))
            return 0;

        var setting = await _settingRepo.GetByIdAsync(1);
        if (setting == null)
            return 0;

        var multiplier = await _fertilizerMultiplierRepo.GetMultiplier(fertilizer, setting.Level);
        if (multiplier <= 0)
            return 0;

        var crop = await _cropRepo.GetByIdAsync(id);
        if (crop == null)
            return 0;
        
        if (setting.IsTiller)
        {
            return 1.1f * crop.BasePrice * quantity * multiplier;
        }
        
        return crop.BasePrice * quantity * multiplier;
    }
}