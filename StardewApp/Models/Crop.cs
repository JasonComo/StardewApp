namespace StardewApp.Models;

public class Crop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GrowthTime { get; set; }
    public Season Season { get; set; }
    public int BasePrice  {get; set;}
    public int SilverPrice  {get; set;}
    public int GoldPrice  {get; set;}
    public int IridiumPrice  {get; set;}
}