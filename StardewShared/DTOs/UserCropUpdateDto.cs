using StardewShared.Enums;

namespace StardewShared.DTOs;

public class UserCropUpdateDto
{
    public int Id { get; set; }                    
    public Fertilizer Fertilizer { get; set; }    
    public int Quantity { get; set; }  
}