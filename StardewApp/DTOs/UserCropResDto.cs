using StardewApp.Models;
namespace StardewApp.DTOs;

public class UserCropResDto
{
    public int Id { get; set; }                    
    public string CropName { get; set; }         
    public Season Season { get; set; }             
    public Fertilizer Fertilizer { get; set; }      
    public int Quantity { get; set; }
    public float Profit {get; set;}
}