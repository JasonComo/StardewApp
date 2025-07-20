using AutoMapper;
using StardewApp.Interfaces;
using StardewApp.Models;
using StardewShared.DTOs;

namespace StardewApp.Services
{
    public class CropService : ICropService
    {
        private readonly ICropRepository _cropRepo;
        private readonly IMapper _mapper;

        public CropService(ICropRepository cropRepo, IMapper mapper)
        {
            _cropRepo = cropRepo;
            _mapper = mapper;
        }

        public async Task<List<CropResDto>> GetAllCropsAsync()
        {
            var crops = await _cropRepo.GetAllAsync();
            return _mapper.Map<List<CropResDto>>(crops);
        }

    }
}
