using StardewApp.Models;
namespace StardewApp.Interfaces;

public interface IFertilizerMultiplierRepository
{
    Task<float> GetMultiplier(Fertilizer fertilizer, int level);
}