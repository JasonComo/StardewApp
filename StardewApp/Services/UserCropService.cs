using StardewApp.Models;
using StardewApp.Interfaces;
using StardewApp.DTOs;

namespace StardewApp.Services;

public class UserCropService : IUserCropService
{
    private readonly IUserCropRepository _userCropRepo;
    private readonly ICropRepository _cropRepo;

    public UserCropService(IUserCropRepository userCropRepo, ICropRepository cropRepository)
    {
        _userCropRepo = userCropRepo;
        _cropRepo = cropRepository;
        
    }

    public async Task<UserCropResDto?> AddUserCropAsync(UserCropCreateDto dto)
    {
        var crop = await _cropRepo.GetByNameAsync(dto.CropName);
        if (crop == null)
            return null;

        if (dto.Quantity < 0)
            return null;

        var currentCrops = await _userCropRepo.GetAllAsync();
        bool isDuplicate = currentCrops.Any(uc => uc.CropId == crop.Id);
        if (isDuplicate)
            return null;

        var userCrop = new UserCrop
        {
            CropId = crop.Id,
            Fertilizer = dto.Fertilizer,
            Quantity = dto.Quantity
        };

        var created = await _userCropRepo.AddAsync(userCrop);

        return new UserCropResDto
        {
            Id = created.Id,
            CropName = crop.Name,
            Season = crop.Season,
            Fertilizer = created.Fertilizer,
            Quantity = created.Quantity
        };
    }
    public async Task<UserCropResDto?> UpdateUserCropAsync(UserCropUpdateDto dto)
    {
        
        var existing = await _userCropRepo.GetByIdAsync(dto.Id);
        if (existing == null)
            return null;

        existing.Fertilizer = dto.Fertilizer;
        existing.Quantity = dto.Quantity;

        var updated = await _userCropRepo.UpdateAsync(existing);
        
        updated.Crop = await _cropRepo.GetByIdAsync(updated.CropId);

        return new UserCropResDto
        {
            Id = updated.Id,
            CropName = updated.Crop.Name,
            Season = updated.Crop.Season,
            Fertilizer = updated.Fertilizer,
            Quantity = updated.Quantity
        }; 
        
    }

    public async Task<List<UserCropResDto>> GetAllUserCropsAsync()
    {
        var userCrops = await _userCropRepo.GetAllAsync();

        var userCropDtos = userCrops.Select(uc => new UserCropResDto
        {
            Id = uc.Id,
            CropName = uc.Crop.Name,
            Season = uc.Crop.Season,
            Fertilizer = uc.Fertilizer,
            Quantity = uc.Quantity
        }).ToList();
        return userCropDtos;
    }

    public async Task<bool> DeleteUserCropAsync(int id)
    {
       var result = await _userCropRepo.DeleteAsync(id);
       if (result) {return true;}
       return false;
    }
}