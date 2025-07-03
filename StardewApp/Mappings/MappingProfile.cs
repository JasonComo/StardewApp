using AutoMapper;
using StardewApp.Models;
using StardewApp.DTOs;


namespace StardewApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserCrop, UserCropResDto>()
            .ForMember(dest => dest.CropName, opt => opt.MapFrom(src => src.Crop.Name))
            .ForMember(dest => dest.Season, opt => opt.MapFrom(src => src.Crop.Season));
        }
        
    }
}
