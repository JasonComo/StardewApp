using StardewApp.Models;
namespace StardewApp.Interfaces;


public interface ICropRepository
{
    Task<List<Crop>> GetAllAsync();
    Task<Crop> GetByIdAsync(int cropId);
    
    Task<Crop> GetByNameAsync(string name);
}