using Microsoft.EntityFrameworkCore;
using StardewApp.Models;

namespace StardewApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Crop> Crops { get; set; }
    public DbSet<UserCrop> UserCrops { get; set; }
    public DbSet<Setting> Settings { get; set; }
    
}