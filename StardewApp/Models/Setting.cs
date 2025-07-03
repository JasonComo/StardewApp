namespace StardewApp.Models;

public class Setting
{
    public int Id { get; set; }
    public List<UserCrop> UserCrops { get; set; }
    public bool IsTiller {get; set;}
    public float TotalProfit {get; set;}
}