using StardewApp.Data;
using StardewApp.Interfaces;
using StardewApp.Models;

namespace StardewApp.Repositories;

public class SettingRepository : ISettingRepository
{
    private readonly AppDbContext _context;

    public SettingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Setting> UpdateAsync(Setting setting)
    {
         _context.Settings.Update(setting);
        await _context.SaveChangesAsync();
        return setting;
    }
    public async Task<Setting?> GetByIdAsync(int id)
    {
        return await _context.Settings.FindAsync(id);
    }
    
}