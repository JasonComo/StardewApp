using StardewShared.Enums;
namespace StardewApp.Interfaces;

public interface IFertilizerMultiplierRepository
{
    Task<float> GetMultiplier(Fertilizer fertilizer, int level);
}