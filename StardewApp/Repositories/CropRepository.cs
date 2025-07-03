using Microsoft.EntityFrameworkCore;
using StardewApp.Data;
using StardewApp.Interfaces;
using StardewApp.Models;

namespace StardewApp.Repositories;

public class CropRepository : ICropRepository
{
    private readonly AppDbContext _context;

    public CropRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Crop>> GetAllAsync()
    {
        return await _context.Crops.ToListAsync();
    }

    public async Task<Crop> GetByIdAsync(int cropId)
    {
        return await _context.Crops.FirstOrDefaultAsync(crop => crop.Id == cropId);
    }

    public async Task<Crop> GetByNameAsync(string name)
    {
        return await _context.Crops.FirstOrDefaultAsync(crop => crop.Name == name);
    }
}