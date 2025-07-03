using Microsoft.EntityFrameworkCore;
using StardewApp.Interfaces;
using StardewApp.Data;
using StardewApp.Models;

namespace StardewApp.Repositories;

public class UserCropRepository : IUserCropRepository
{
    private readonly AppDbContext _context;

    public UserCropRepository(AppDbContext context)
        {
            _context = context;
        }

    public async Task<UserCrop> AddAsync(UserCrop userCrop)
    {
        _context.UserCrops.Add(userCrop);
        await _context.SaveChangesAsync();
        return userCrop;
    }

    public async Task<List<UserCrop>> GetAllAsync()
    {
        return await _context.UserCrops
            .Include(uc => uc.Crop) 
            .ToListAsync();

    }

    public async Task<UserCrop> GetByIdAsync(int id)
    {
        return await _context.UserCrops.FirstOrDefaultAsync(crop => crop.Id == id); 
    }

    public async Task<UserCrop> UpdateAsync(UserCrop userCrop)
    {
        _context.UserCrops.Update(userCrop);
        await _context.SaveChangesAsync();
        return userCrop;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _context.UserCrops.FindAsync(id);
        if (toDelete == null)
        {
            return false;
        }
        _context.UserCrops.Remove(toDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}