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
    private readonly IMapper _mapper;

    public UserCropService(IUserCropRepository userCropRepo, ICropRepository cropRepository, IMapper mapper)
    {
        _userCropRepo = userCropRepo;
        _cropRepo = cropRepository;
        _mapper = mapper;
        
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
            Crop = crop,
            CropId = crop.Id,
            Fertilizer = dto.Fertilizer,
            Quantity = dto.Quantity
        };

        var created = await _userCropRepo.AddAsync(userCrop);

        return _mapper.Map<UserCropResDto>(created);
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
}