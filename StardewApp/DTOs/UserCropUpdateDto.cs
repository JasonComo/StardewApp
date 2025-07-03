using StardewApp.Models;

namespace StardewApp.DTOs;

public class UserCropUpdateDto
{
    public int Id { get; set; }                    
    public Fertilizer Fertilizer { get; set; }    
    public int Quantity { get; set; }  
}