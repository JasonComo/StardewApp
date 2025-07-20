using StardewShared.Enums;
namespace StardewApp.Models;

public class FertilizerMultiplier
{
    public int Id { get; set; }
    public Fertilizer Fertilizer { get; set; }
    public int Level { get; set; }
    public float Multiplier { get; set; }
}