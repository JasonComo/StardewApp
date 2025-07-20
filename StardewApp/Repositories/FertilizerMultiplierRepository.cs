using Microsoft.EntityFrameworkCore;
using StardewApp.Data;
using StardewApp.Interfaces;
using StardewShared.Enums;

namespace StardewApp.Repositories;

public class FertilizerMultiplierRepository : IFertilizerMultiplierRepository
{
    private readonly AppDbContext _context;

    public FertilizerMultiplierRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<float> GetMultiplier(Fertilizer fertilizer, int level)
    {
       var row = await _context.FertilizerMultipliers.FirstOrDefaultAsync(fm => fm.Fertilizer == fertilizer && fm.Level == level);
       return row.Multiplier;
    }
    
}